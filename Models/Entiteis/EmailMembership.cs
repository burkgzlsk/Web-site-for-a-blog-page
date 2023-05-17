using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBloGer.Models.Entiteis
{
	[Table("EmailMemberships")]
    public class EmailMembership : EntityLogBase
	{
        [Key]
        public int Id { get; set; }
		[Required, StringLength(40),EmailAddress, Display(Name = "E-posta")]
		public string EmailAddress { get; set; }
    }
}
