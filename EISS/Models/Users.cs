using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EISS.Models
{
    public class Users
    {
        [Required(ErrorMessage = "Kullanıcı Adı gerekiyor")]
        [Display(Name = "Kullanıcı Adı :")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Ad gerekiyor")]
        [Display(Name = "Ad :")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad gerekiyor")]
        [Display(Name = "Soyad :")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Parola gerekiyor")]
        [Display(Name = "Parola :")]
        public string Password { get; set; }

    }
}
