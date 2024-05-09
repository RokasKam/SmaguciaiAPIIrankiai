using SmaguciaiDomain.Entities;
namespace SmaguciaiCore.Interfaces.Repositories;

public interface IReportRepository
{
    bool AddNewReport(Report report, Review review);
    Report GetById(Guid id);
    List<Report> GetReportsByReviewId(Guid reviewId);
    bool DeleteReport(Guid id);
}