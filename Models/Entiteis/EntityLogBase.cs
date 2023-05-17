using System.ComponentModel.DataAnnotations;

namespace BBloGer.Models.Entiteis
{
	public class EntityLogBase
    {
		[Required, StringLength(50)]
		public string CreateUser { get; set; }
		public DateTime CreatedAt { get; set; }
		[StringLength(50)]
		public string ModifiedUser { get; set; }
		public DateTime ModifiedAt { get; set; }

	}
}
