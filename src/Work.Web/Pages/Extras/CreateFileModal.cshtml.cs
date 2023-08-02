using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Work.Extras;
using Work.Files;

namespace Work.Web.Pages.Extras
{
    public class CreateFileModalModel : WorkPageModel
    {

        [BindProperty]
        public UploadFileDto UploadFileDtos { get; set; }
        [BindProperty]
        public CreateUpdateExtraFileIndex createUpdateExtra { get; set; }
        private readonly IWebHostEnvironment _env;
        private readonly IExtraFileAppService _extraFileAppService;
        public int result { get; set; }
        public CreateFileModalModel(IWebHostEnvironment env, IExtraFileAppService extraFileAppService) {
            _env = env;
            _extraFileAppService = extraFileAppService;
        }
        public void OnGet()
        {
           
        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                Guid id;
                id = GuidGenerator.Create();
                string fullpath = Path.Combine(@"Pages\upload", id.ToString() + UploadFileDtos.File.FileName);

                using (var stream = new FileStream(fullpath, FileMode.Create))
                {
                    await UploadFileDtos.File.CopyToAsync(stream);
                }

                createUpdateExtra.Url = fullpath;
                createUpdateExtra.Name = UploadFileDtos.File.FileName;
                var dtos = ObjectMapper.Map<CreateUpdateExtraFileIndex, CreateUpdateExtraFile>(createUpdateExtra);
                var rec = await _extraFileAppService.CreateAsync(dtos);

                return NoContent();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


    public class UploadFileDto
    {
        [Display(Name = "Logo")]
        public IFormFile File { get; set; }

        [HiddenInput]
        public string Name { get; set; }
    }

    public class CreateUpdateExtraFileIndex
    {
        [HiddenInput]
        public string Name { get; set; }
        [HiddenInput]
        public string Url { get; set; }
        public FileEnum FileEnum { get; set; }
    }
}
