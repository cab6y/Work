using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Work.Files;

namespace Work.Web.Pages.Extras
{
    public class FilesModel : WorkPageModel
    {
        private readonly IExtraFileAppService _extraAppService;
        [BindProperty]
        public List<ExtraFileDto> List { get; set; }
        public FilesModel(IExtraFileAppService extraAppService) {
            _extraAppService = extraAppService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
               
                return Page();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
