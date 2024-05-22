using DVar.PList.Api.Requests.Pricelists;
using DVar.PList.Api.Responses.Pricelists;
using DVar.PList.Domain.Entities;
using DVar.PList.Domain.Params;
using DVar.PList.Domain.Persistence;
using DVar.PList.Domain.RepositoryInterfaces;
using DVar.PList.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace DVar.PList.Api.Endpoints;

public static class PricelistEndpoints
{
    public static void MapPricelistEndpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder group = app.MapGroup("api/v1/PriceLists");
        group.MapPost("", CreatePricelistAsync);
        group.MapGet("", ListPricelistsAsync);
        group.MapGet("/{id}", GetPricelistAsync);
        group.MapPatch("/AddProduct/{id}", AddProductToPricelist);
    }

    private static async Task<IResult> CreatePricelistAsync([FromBody] CreatePricelistRequest request,
        IPricelistRepository pricelistRepository, IUnitOfWork unitOfWork)
    {
        var pricelist = new Pricelist
        {
            Name = request.Name,
            CustomColumns = request.CustomColumns,
        };

        pricelistRepository.Create(pricelist);
        if (await unitOfWork.CompleteAsync()) return Results.Ok(pricelist.Id);

        return Results.BadRequest("Requst is bad");
    }

    private static async Task<IResult> ListPricelistsAsync([AsParameters] PaginationParams paginationParams,
        IPricelistRepository pricelistRepository)
    {
        var pricelists = await pricelistRepository.ListAsync(paginationParams);

        var response = pricelists.Select(p => new ListPricelistsResponse
        {
            Id = p.Id,
            Name = p.Name
        }).ToList();

        if (response.Count != 0) return Results.Ok(response);

        return Results.NoContent();
    }

    private static async Task<IResult> GetPricelistAsync(Guid id, IPricelistRepository pricelistRepository)
    {
        var pricelist = await pricelistRepository.GetAsync(id);
        if (pricelist != null)
        {
            return Results.Ok(pricelist);
        }

        return Results.NotFound();
    }

    private static async Task<IResult> AddProductToPricelist(Guid id, [FromBody] Product product,
        IPricelistRepository pricelistRepository, IUnitOfWork unitOfWork)
    {
        var pricelst = await pricelistRepository.GetAsync(id);

        if (pricelst != null)
        {

            /*updatedPricelist.Products.Add(new()
            {
                Code = product.Code,
                Name = product.Name
            });
            */

            var products = new List<Product>
            {
                new()
            };

            pricelst.Products = products;
            
            if (await unitOfWork.CompleteAsync())
                return Results.Ok(id);
        }

        return Results.BadRequest("Requst is bad");
    }
}