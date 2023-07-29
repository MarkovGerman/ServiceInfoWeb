using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceInfoWebServer.DTO;
using ServiceInfoWebServer.Managers;
using ServiceInfoWebServer.Models;

namespace ServiceInfoWebServer.Pages
{
    public class EditModel : PageModel
    {
        private readonly IServiceInfoManager serviceInfoManager;
        private readonly IMapper mapper;


        public EditModel(IServiceInfoManager serviceInfoManager, IMapper mapper)
        {
            this.serviceInfoManager = serviceInfoManager;
            this.mapper = mapper;
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

            ServiceInfo = serviceinfo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            serviceInfoManager.Update(mapper.Map<UpdateServiceInfoRequest>(ServiceInfo));
            return RedirectToPage("./Index");
        }
    }
}