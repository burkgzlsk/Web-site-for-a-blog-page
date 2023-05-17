﻿using System.ComponentModel.DataAnnotations;

namespace BBloGer.Models.Entiteis
{
	public class Note : EntityLogBase
    {
        [Key]
        public int Id { get; set; }

		[Required, StringLength(80), Display(Name = "Başlık")]
		public string Title { get; set; }

		[Required, StringLength(250), Display(Name = "Özet")]
		public string Summary { get; set; }

		[Display(Name = "Detay")]
		public string Details { get; set; }

		[Display(Name = "Taslak")]
		public bool IsDraft { get; set; }

		[Display(Name = "Kategori")]
		public int CategoryId { get; set; }

		[Display(Name = "Yazar")]
		public int OwnerId { get; set; }

		public virtual User Owner { get; set; }
        public virtual Category Category { get; set; }   //buradaki virtual sanal olarak işaretlemek oluyor , Category yi başka bi classı işaret eden properties olduğu için koymalıyız .
        public virtual List<Comment> Comments { get; set; }
        public virtual List<LikedNote> Likes { get; set; }
    }
}
