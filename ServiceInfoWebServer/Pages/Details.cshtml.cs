using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceInfoWebServer.Managers;
using ServiceInfoWebServer.Models;

namespace ServiceInfoWebServer.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IServiceInfoManager serviceInfoManager;

        public DetailsModel(IServiceInfoManager serviceInfoManager)
        {
            this.serviceInfoManager = serviceInfoManager;
        }

        public ServiceInfo ServiceInfo { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceinfo = serviceInfoManager.Get(id.Value);
            if (serviceinfo == null)
            {
                return NotFound();
            }
            else
            {
                ServiceInfo = serviceinfo;
            }

            return Page();
        }
    }
}