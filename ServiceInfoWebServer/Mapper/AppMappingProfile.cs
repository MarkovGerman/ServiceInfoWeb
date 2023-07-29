using AutoMapper;
using ServiceInfoWebServer.DTO;
using ServiceInfoWebServer.Models;

namespace ServiceInfoWebServer.Mapper
{
    public class AppMappingProfile: Profile
    {
        public AppMappingProfile()
        {
            CreateMap<ServiceInfo, GetServiceInfoResponse>().ReverseMap();
            CreateMap<UpdateServiceInfoRequest, ServiceInfo>().ReverseMap();
            CreateMap<AddServiceInfoRequest, ServiceInfo>().ReverseMap();
        }
    }
}