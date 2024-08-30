using Api.Domain.Entities;

namespace Api.Domain.Interfaces;

public interface IProductstService
{
    Task<int> SaveReportAsync(Products model);
}
