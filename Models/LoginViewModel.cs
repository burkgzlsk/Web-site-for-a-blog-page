using System.ComponentModel.DataAnnotations;

namespace BBloGer.Models
{
    public class LoginViewModel
	{

        [Required(ErrorMessage = "{0} alanı boş geçilemez"),
            StringLength(30, ErrorMessage = "{0} alanı Maksimum {1} karakter olabilir."),
            Display(Name = "Kullanıcı Adı")]   //parantez içindeki 0 displaydeki name i alır 1 ise o şartın özelliğini yazar önr. 30 yazıcak burada.
        public string Username { get; set; }

        [Required(ErrorMessage = "{0} alanı boş geçilemez"),
            StringLength(16, MinimumLength = 6, ErrorMessage = "{0} alanı Maksimum {1} Minumum {2} karakter olabilir."),
            Display(Name = "Şifre")]
        public string Password { get; set; }

    }
}
