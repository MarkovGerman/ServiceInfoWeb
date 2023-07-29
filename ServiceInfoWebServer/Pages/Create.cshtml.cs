using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceInfoWebServer.DTO;
using ServiceInfoWebServer.Managers;
using ServiceInfoWebServer.Models;

namespace ServiceInfoWebServer.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IServiceInfoManager serviceInfoManager;
        private readonly IMapper mapper;


        public CreateModel(IServiceInfoManager serviceInfoManager, IMapper mapper)
        {
            this.serviceInfoManager = serviceInfoManager;
            this.mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public ServiceInfo ServiceInfo { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            serviceInfoManager.Create(mapper.Map<AddServiceInfoRequest>(ServiceInfo));
            return RedirectToPage("./Index");
        }
    }
}