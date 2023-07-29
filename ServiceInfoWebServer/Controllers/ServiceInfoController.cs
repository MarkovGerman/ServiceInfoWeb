using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceInfoWebServer.DTO;
using ServiceInfoWebServer.Managers;
using ServiceInfoWebServer.Models;

namespace ServiceInfoWebServer.Controllers
{
    namespace ServiceInfoWebServer
    {
        [ApiController]
        [Route("[controller]/[action]")]
        public class ServiceInfoController : ControllerBase
        {
            private IServiceInfoManager infoManager;

            public ServiceInfoController(IServiceInfoManager infoManager)
            {
                this.infoManager = infoManager;
            }

            [HttpGet]
            public IList<GetServiceInfoResponse> GetAll()
            {
                return infoManager.GetAll();
            }

            [HttpGet("{id}")]
            public GetServiceInfoResponse Get(int id)
            {
                return infoManager.Get(id);
            }
            
            [HttpPost]
            public void Post(AddServiceInfoRequest request)
            {
                infoManager.Create(request);
            }

            [HttpPut("{id}")]
            public void UpdateServiceInfo(UpdateServiceInfoRequest request)
            {
                infoManager.Update(request);
            }

            [HttpDelete]
            public void Delete(DeleteServiceInfoRequest request)
            {
                infoManager.Delete(request.Id);
            }
        }
    }
}