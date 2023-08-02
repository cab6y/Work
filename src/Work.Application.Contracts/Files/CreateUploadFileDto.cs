using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Work.Files
{
    public class CreateUploadFileDto
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile File { get; set; }

        [Required]
        [Display(Name = "Filename")]
        public string Name { get; set; }
    }
}
