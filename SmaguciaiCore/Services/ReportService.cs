using AutoMapper;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Report;
using SmaguciaiCore.Responses.Report;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Services;

public class ReportService : IReportService
{
    private readonly IReportRepository _reportRepository;
    private readonly IReviewRepository _reviewRepository;
    private readonly IMapper _mapper;
    
    public ReportService(IReportRepository reportRepository, IMapper mapper, IReviewRepository reviewRepository)
    {
        _reportRepository = reportRepository;
        _reviewRepository = reviewRepository;
        _mapper = mapper;
    }
    
    public bool AddNewReport(ReportRequest request)
    {
        var report = _mapper.Map<Report>(request);
        var review = _reviewRepository.GetById(request.ReviewId);
        var res = _reportRepository.AddNewReport(report, review);
        return res;
    }

    public ReportResponse GetById(Guid id)
    {
        var report = _reportRepository.GetById(id);
        var response = _mapper.Map<ReportResponse>(report);
        return response;
    }

    public List<ReportResponse> GetReportsByReviewId(Guid reviewId)
    {
        var reports = _reportRepository.GetReportsByReviewId(reviewId);
        return _mapper.Map<List<ReportResponse>>(reports);
    }

    public bool DeleteReport(Guid id)
    {
        try
        {
            _reportRepository.DeleteReport(id);
            return true;
        }
        catch
        {
            return false;
        }
    }
}