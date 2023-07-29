using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceInfoWebServer.Managers;
using ServiceInfoWebServer.Models;

namespace ServiceInfoWebServer.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IServiceInfoManager serviceInfoManager;

        public DeleteModel(IServiceInfoManager serviceInfoManager)
        {
            this.serviceInfoManager = serviceInfoManager;
        }

        [BindProperty] public ServiceInfo ServiceInfo { get; set; } = default!;

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

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            serviceInfoManager.Delete(id.Value);
            return RedirectToPage("./Index");
        }
    }
}