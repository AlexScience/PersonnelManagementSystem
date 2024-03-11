using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using PersonnelManagementSystem.API.Infrastructure;

namespace PersonnelManagementSystem.API.Services;

public interface IReportService
{
    public Task<byte[]> GenerateReport();
}