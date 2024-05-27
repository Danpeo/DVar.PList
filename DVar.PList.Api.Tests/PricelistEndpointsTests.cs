using DVar.PList.Api.Endpoints;
using DVar.PList.Api.Requests.Pricelists;
using DVar.PList.Api.Responses.Pricelists;
using DVar.PList.Domain.Entities;
using DVar.PList.Domain.Params;
using DVar.PList.Domain.Persistence;
using DVar.PList.Domain.RepositoryInterfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DVar.PList.Api.Tests;

public class PricelistEndpointsTests
{
    private readonly Mock<IPricelistRepository> _pricelistRepositoryMock = new();
    private readonly Mock<IProductRepository> _productRepositoryMock = new();
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<IValidator<Pricelist>> _validatorMock = new();

    [Fact]
    public async Task CreatePricelistAsync_ValidRequest_ReturnsOk()
    {
        // Arrange
        var request = new CreatePricelistRequest
        {
            Name = "Test Pricelist",
            CustomColumns = new List<CustomColumn>()
        };

        var pricelist = new Pricelist
        {
            PricelistName = request.Name,
            CustomColumns = request.CustomColumns
        };

        _validatorMock.Setup(v => v.ValidateAsync(It.IsAny<Pricelist>(), default))
            .ReturnsAsync(new ValidationResult());

        _pricelistRepositoryMock.Setup(r => r.Create(It.IsAny<Pricelist>()));
        _unitOfWorkMock.Setup(u => u.CompleteAsync()).ReturnsAsync(true);

        // Act
        var result = await PricelistEndpoints.CreatePricelistAsync(request, _pricelistRepositoryMock.Object,
            _unitOfWorkMock.Object, _validatorMock.Object);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(pricelist.Id, okResult.Value);
    }

    [Fact]
    public void ListPricelistsAsync_ValidRequest_ReturnsOk()
    {
        // Arrange
        var paginationParams = new PaginationParams(0, 0);
        var pricelists = new List<Pricelist>
        {
            new() { PricelistName = "Pricelist 1" },
            new() { PricelistName = "Pricelist 2" }
        };

        _pricelistRepositoryMock.Setup(r => r.List(paginationParams)).Returns(pricelists);

        // Act
        var result = PricelistEndpoints.ListPricelistsAsync(paginationParams, _pricelistRepositoryMock.Object);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<List<ListPricelistsResponse>>(okResult.Value);
        Assert.Equal(pricelists.Count, response.Count);
    }
}