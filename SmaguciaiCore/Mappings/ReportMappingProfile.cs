using AutoMapper;
using SmaguciaiCore.Requests.Report;
using SmaguciaiCore.Responses.Report;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Mappings;

public class ReportMappingProfile : Profile
{
    public ReportMappingProfile()
    {
        CreateMap<ReportRequest, Report>();
        CreateMap<Report, ReportResponse>();
    }

}