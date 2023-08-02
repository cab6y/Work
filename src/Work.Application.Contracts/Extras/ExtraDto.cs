using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Work.Extras
{
    public class ExtraDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCKimlikNo { get; set; }
        public ExtraGenderEnum ExtraGenderEnum { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DateOfPlace { get; set; }
        public string NameSurnameOfCustodian { get; set; }
        public string PhoneOfCustodian { get; set; }
        public string HomeAddress { get; set; }
        public string City { get; set; }
        public int Size { get; set; }
        public int Kilo { get; set; }
        public string SkinColor { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public ExtraGenderSize DressSize { get; set; }
        public int ShoeSize { get; set; }
        public string ImgUrl { get; set; }
        public string VideoUrl { get; set; }
    }
}
