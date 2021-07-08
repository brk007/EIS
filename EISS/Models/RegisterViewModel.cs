using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EIS.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "Kullanıcı Adı:")]
        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz")]
        public string UserName { get; set; }
        [Display(Name = "Parola:")]
        [Required(ErrorMessage = "Parola boş bırakılamaz")]
        public string Password { get; set; }
        [Display(Name = "Parolanızı doğrulayın:")]
        [Compare ("Password",ErrorMessage="Parolalar eşleşmiyor")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "İsim:")]
        [Required(ErrorMessage = "İsim boş bırakılamaz")]
        public string Name { get; set; }
        [Display(Name = "Soyisim:")]
        [Required(ErrorMessage = "Soyisim boş bırakılamaz")]
        public string SurName { get; set; }
        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Email boş bırakılamaz")]
        public string Email { get; set; }
    }
}
