using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizLive.DTO.RegisterDto
{
    public class RegisterDto
    {
            [Required(ErrorMessage = "E-posta adresi boş bırakılamaz.")]
            [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz.")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "Ad Soyad boş bırakılamaz.")]
            public string FullName { get; set; }

            [Required(ErrorMessage = "Şifre boş bırakılamaz.")]
            [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
            public string Password { get; set; }

            [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
            public string ConfirmPassword { get; set; }
        }

    }
