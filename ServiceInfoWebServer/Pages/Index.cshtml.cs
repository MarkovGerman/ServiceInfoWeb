using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceInfoWebServer.DTO;
using ServiceInfoWebServer.Managers;

namespace ServiceInfoWebServer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IServiceInfoManager serviceInfoManager;
        private readonly IMapper mapper;

        public IndexModel(IServiceInfoManager serviceInfoManager, IMapper mapper)
        {
            this.serviceInfoManager = serviceInfoManager;
            this.mapper = mapper;
        }
        
        public IList<GetServiceInfoResponse> ServiceInfo { get; set; } = default!;

        public void OnGet()
        {
            ServiceInfo = mapper.Map<IList<GetServiceInfoResponse>>(serviceInfoManager.GetAll());
        }
    }
}