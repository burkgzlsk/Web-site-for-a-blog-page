using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BBloGer.Models
{
    public class RegisterViewModel
	{
		[Required(ErrorMessage ="{0} alanı boş geçilemez"),
			StringLength(30,ErrorMessage = "{0} alanı Maksimum {1} karakter olabilir."),
			Display(Name = "Kullanıcı Adı")]   //parantez içindeki 0 displaydeki name i alır 1 ise o şartın özelliğini yazar önr. 30 yazıcak burada.
		public string Username { get; set; }

		[Required(ErrorMessage = "{0} alanı boş geçilemez"),
			StringLength(60, ErrorMessage = "{0} alanı Maksimum {1} karakter olabilir."), 
			EmailAddress(ErrorMessage = "{0} alanınıa geçerli bir e-posta adresi giriniz."),
			Display(Name = "E-posta")]
		public string Email { get; set; }

		[Required(ErrorMessage = "{0} alanı boş geçilemez"), 
			StringLength(16,MinimumLength =6, ErrorMessage = "{0} alanı Maksimum {1} Minumum {2} karakter olabilir."), 
			Display(Name = "Şifre")]
		public string Password { get; set; }

		[Required(ErrorMessage = "{0} alanı boş geçilemez"),
			StringLength(16, MinimumLength = 6, ErrorMessage = "{0} alanı Maksimum {1} Minumum {2} karakter olabilir."),
			Display(Name = "Şifre Tekrar"),
			Compare(nameof(Password),ErrorMessage = "{0} alanı şifrenizle uyuşmuyor.")]
		public string RePassword { get; set; }
    }
}
