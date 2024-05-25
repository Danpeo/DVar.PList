using System.Data;
using DVar.PList.Api.Requests.Pricelists;
using DVar.PList.Api.Responses.Pricelists;
using DVar.PList.Domain.Entities;
using DVar.PList.Domain.Params;
using DVar.PList.Domain.Persistence;
using DVar.PList.Domain.RepositoryInterfaces;
using DVar.PList.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DVar.PList.Api.Endpoints;

public static class PricelistEndpoints
{
    public static void MapPricelistEndpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder group = app.MapGroup("api/v1/PriceLists");
        group.MapPost("", CreatePricelistAsync);
        group.MapGet("", ListPricelistsAsync);
        group.MapGet("/{id:guid}", GetPricelistAsync);
        group.MapGet("/Columns/{pricelistId:guid}", ListCustomColumnsAsync);
        group.MapPatch("/AddProduct/{pricelistId}", AddProductToPricelist);
    }

    private static async Task<IResult> CreatePricelistAsync([FromBody] CreatePricelistRequest request,
        IPricelistRepository pricelistRepository, IUnitOfWork unitOfWork)
    {
        var pricelist = new Pricelist
        {
            PricelistName = request.Name,
            CustomColumns = request.CustomColumns,
        };

        pricelistRepository.Create(pricelist);
        if (await unitOfWork.CompleteAsync()) return Results.Ok(pricelist.Id);

        return Results.BadRequest("Requst is bad");
    }

    private static IResult ListPricelistsAsync([AsParameters] PaginationParams paginationParams,
        IPricelistRepository pricelistRepository)
    {
        var pricelists = pricelistRepository.List(paginationParams);

        var response = pricelists.Select(p => new ListPricelistsResponse
        {
            Id = p.Id,
            Name = p.PricelistName
        }).ToList();

        if (response.Count != 0) return Results.Ok(response);

        return Results.NoContent();
    }

    private static async Task<IResult> GetPricelistAsync(Guid id, IPricelistRepository pricelistRepository,
        IProductRepository productRepository)
    {
        Pricelist? pricelist = await pricelistRepository.GetAsync(id);
        if (pricelist != null)
        {
            var response = new GetPricelistResponse(pricelist.Id, pricelist.PricelistName, pricelist.CustomColumns,
                pricelist.Products);

            return Results.Ok(response);
        }

        return Results.NotFound();
    }

    private static async Task<IResult> AddProductToPricelist(Guid pricelistId, [FromBody] Product product,
        IPricelistRepository pricelistRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        Pricelist? pricelist = await pricelistRepository.GetAsync(pricelistId);

        if (pricelist != null)
        {
            var addedProduct = productRepository.Create(product);
            pricelist.Products.Add(addedProduct);

            if (await unitOfWork.CompleteAsync())
                return Results.Ok(pricelistId);
        }

        return Results.BadRequest("Requst is bad");
    }

    private static async Task<IResult> ListCustomColumnsAsync(Guid pricelistId,
        [AsParameters] PaginationParams paginationParams, IPricelistRepository pricelistRepository,
        ICustomColumnRepository customColumnRepository)
    {
        Pricelist? pricelist = await pricelistRepository.GetAsync(pricelistId);

        if (pricelist != null)
        {
            var columns = customColumnRepository.ListForPricelist(pricelist, paginationParams);
            return Results.Ok(columns);
        }

        return Results.NotFound();
    }
}