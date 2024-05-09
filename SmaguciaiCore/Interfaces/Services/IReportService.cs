using SmaguciaiCore.Requests.Report;
using SmaguciaiCore.Responses.Report;

namespace SmaguciaiCore.Interfaces.Services;

public interface IReportService
{
    bool AddNewReport(ReportRequest request);
    ReportResponse GetById(Guid id);
    List<ReportResponse> GetReportsByReviewId(Guid reviewId);
    bool DeleteReport(Guid id);
}