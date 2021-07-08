using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EIS.Models
{
    public class LoginViewModel
    {
        [Display(Name ="Kullanıcı Adı:")]
        [Required(ErrorMessage="Kullanıcı adı boş bırakılamaz")]
        public string UserName { get; set; }
        [Display(Name = "Şifre:")]
        [Required(ErrorMessage = "Şifre boş bırakılamaz")]
        public string Password { get; set; }

        public bool CookieRemember { get; set; }
    }
}
