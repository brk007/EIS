using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EISS.Models
{
    public class User
    {
        [Required(ErrorMessage = "Ad alanı gerekiyor")]
        [Display(Name = "Ad :")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Ad alanı gerekiyor")]
        [Display(Name = "Ad :")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ad alanı gerekiyor")]
        [Display(Name = "Ad :")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Ad alanı gerekiyor")]
        [Display(Name = "Ad :")]
        public string Password { get; set; }


    }
}
