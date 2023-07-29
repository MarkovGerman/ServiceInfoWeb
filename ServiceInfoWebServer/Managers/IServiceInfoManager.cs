using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceInfoWebServer.DTO;
using ServiceInfoWebServer.Enums;
using ServiceInfoWebServer.Models;

namespace ServiceInfoWebServer.Managers
{
    public interface IServiceInfoManager
    {
        IList<GetServiceInfoResponse> GetAll();
        GetServiceInfoResponse Get(int id);
        void Create(AddServiceInfoRequest request);
        void Update(UpdateServiceInfoRequest updateService);
        void Delete(int id);
        IQueryable<ServiceInfo> FilterHost(string host);
        IQueryable<ServiceInfo> FilterEnvironment(ServiceEnvironment environment);
    }
}