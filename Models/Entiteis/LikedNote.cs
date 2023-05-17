﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBloGer.Models.Entiteis
{
	[Table("LikedNotes")]
    public class LikedNote
    {
        public int Id { get; set; }
        [Display(Name = "Kullanıcı")]
		public int UserId { get; set; }
        [Display(Name = "Yazı")]
		public int NoteId { get; set; }

		public virtual User User { get; set; }
        public virtual Note Note { get; set; }
    }
}
