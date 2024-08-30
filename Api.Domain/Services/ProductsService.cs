using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Services;
public class ProductsService : IProductstService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> SaveReportAsync(Products model)
    {
        var report = new Products
        {
            Description = string.IsNullOrWhiteSpace(model.Description) ? null : model.Description,
            Status = model.Status,
            CustomerName = string.IsNullOrWhiteSpace(model.CustomerName) ? null : model.CustomerName,
            CustomerNumber = string.IsNullOrWhiteSpace(model.CustomerNumber) ? null : model.CustomerNumber
        };

        await _unitOfWork.Reports.AddAsync(report);
        await _unitOfWork.CompleteAsync();

        return report.Id;
    }
}
