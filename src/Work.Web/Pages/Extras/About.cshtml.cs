using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Work.Extras;

namespace Work.Web.Pages.Extras
{
    public class AboutModel : WorkPageModel
    {
        [BindProperty]
        public ExtraAboutDtoIndex _extraAbout { get; set; }
        public IExtraAboutAppService _extraAboutAppService;
        public AboutModel(IExtraAboutAppService extraAboutAppService) {
            _extraAboutAppService = extraAboutAppService;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var extraAbout  = await _extraAboutAppService.GetOnCurrenUserAsync();
                if (extraAbout != null)
                    _extraAbout = ObjectMapper.Map<ExtraAboutDto, ExtraAboutDtoIndex>(extraAbout);
                return Page();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {

                if (_extraAbout.Id != null)
                    await _extraAboutAppService.UpdateAsync(Guid.Parse(_extraAbout.Id.ToString()),
              ObjectMapper.Map<ExtraAboutDtoIndex, CreateUpdateExtraAbout>(_extraAbout));
                else
                    await _extraAboutAppService.CreateAsync(ObjectMapper.Map<ExtraAboutDtoIndex, CreateUpdateExtraAbout>(_extraAbout));


                return Page();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public class ExtraAboutDtoIndex
        {
            [HiddenInput]
            public Guid? Id { get; set; }
            public string Instagram { get; set; }
            [DisplayName("Detaylar")]
            public string Details { get; set; }
            [DisplayName("Açýklama")]
            public string Info { get; set; }
            [DisplayName("Profosyonel Eðitim Aldý Mý?")]
            public bool IsProffesionalTrained { get; set; }
            [DisplayName("Görüþme No")]
            public Int64 InterviewNumber { get; set; }
            public int puan { get; set; }
            [DisplayName("Yetiþkin Rollerde Oynayabilir Mi?")]
            public bool PlaysAdultRoles { get; set; }
        }
    }
}
