using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ServiceInfoWebServer.Contexts;
using ServiceInfoWebServer.DTO;
using ServiceInfoWebServer.Enums;
using ServiceInfoWebServer.Models;

namespace ServiceInfoWebServer.Managers
{
    public class ServiceInfoManager : IServiceInfoManager
    {
        private readonly ServiceInfoContext serviceInfoContext;
        private readonly IMapper mapper;

        public ServiceInfoManager(ServiceInfoContext serviceInfoContext, IMapper mapper)
        {
            this.serviceInfoContext = serviceInfoContext;
            this.mapper = mapper;
        }

        public IList<GetServiceInfoResponse> GetAll()
        {
            return mapper.Map<IList<GetServiceInfoResponse>>(serviceInfoContext.ServiceInfo);
        }

        public GetServiceInfoResponse Get(int id)
        {
            var serviceInfo = serviceInfoContext.ServiceInfo.FirstOrDefault(u => u.Id == id);
            return mapper.Map<GetServiceInfoResponse>(serviceInfo);
        }

        public void Create(AddServiceInfoRequest request)
        {
            serviceInfoContext.ServiceInfo.Add(mapper.Map<ServiceInfo>(request));
            serviceInfoContext.SaveChanges();
        }

        public void Update(UpdateServiceInfoRequest updateService)
        {
            var serviceInfo = mapper.Map<ServiceInfo>(updateService);
            var serviceInfoEntityEntry = serviceInfoContext.ServiceInfo.Update(serviceInfo);
            serviceInfoContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var serviceInfo = serviceInfoContext.ServiceInfo.FirstOrDefault(u => u.Id == id);
            if (serviceInfo == null) return;
            serviceInfoContext.ServiceInfo.Remove(serviceInfo);
            serviceInfoContext.SaveChanges();
        }

        public IQueryable<ServiceInfo> FilterHost(string host)
        {
            return serviceInfoContext.ServiceInfo.Where(serviceInfo => serviceInfo.Host.Contains(host));
        }

        public IQueryable<ServiceInfo> FilterEnvironment(ServiceEnvironment environment)
        {
            return serviceInfoContext.ServiceInfo.Where(serviceInfo => serviceInfo.ServiceEnvironment == environment);
        }
    }
}