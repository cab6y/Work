using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Work.Extras;

namespace Work.Web.Pages.Extras
{
    public class IndexModel : WorkPageModel
    {
        [BindProperty]
        public ExtraDtoIndex _extra { get; set; }
       
        public IExtraAppService _extraAppService;
       

        public IndexModel(IExtraAppService extraAppService)
        {
            _extraAppService = extraAppService;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var extra = await _extraAppService.GetOnCurrenUserAsync();
                if (extra != null)
                    _extra = ObjectMapper.Map<ExtraDto, ExtraDtoIndex>(extra);
                
                return Page();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
           
                if (_extra.Id != null)
                    await _extraAppService.UpdateAsync(Guid.Parse(_extra.Id.ToString()),
              ObjectMapper.Map<ExtraDtoIndex, CreateUpdateExtra>(_extra));
                else
                    await _extraAppService.CreateAsync(ObjectMapper.Map<ExtraDtoIndex, CreateUpdateExtra>(_extra));
            
         
                return Page();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public class ExtraDtoIndex
        {
            [HiddenInput]
            public Guid? Id { get; set; }
            [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{5})$", ErrorMessage = "Bu Do�ru Bir TCKN De�il")]
            public string TCKimlikNo { get; set; }
            [DisplayName("Cinsiyet")]
            public ExtraGenderEnum ExtraGenderEnum { get; set; }
            [DisplayName("Do�um Tarihi")]
            public DateTime DateOfBirth { get; set; }
            [DisplayName("Do�um Yeri")]
            public string DateOfPlace { get; set; }
            [DisplayName("Veli Ad� Soyad�")]
            public string NameSurnameOfCustodian { get; set; }
            [Required(ErrorMessage = "You must provide a phone number")]
            [DataType(DataType.PhoneNumber)]
            [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Bu Do�ru Bir Telefon Adresi De�il")]
            [DisplayName("Veli Telefon")]
            public string PhoneOfCustodian { get; set; }
            [DisplayName("Ev Adresi")]
            public string HomeAddress { get; set; }
            [DisplayName("�ehir")]
            public string City { get; set; }
            [DisplayName("Boy")]
            public int Size { get; set; }
            public int Kilo { get; set; }
            [DisplayName("Ten Rengi")]
            public string SkinColor { get; set; }
            [DisplayName("Sa� Rengi")]
            public string HairColor { get; set; }
            [DisplayName("G�z Rengi")]
            public string EyeColor { get; set; }
            [DisplayName("Elbise Beden")]
            public ExtraGenderSize DressSize { get; set; }
            [DisplayName("Ayak Numaras�")]
            public int ShoeSize { get; set; }
        }
       
    }
}
