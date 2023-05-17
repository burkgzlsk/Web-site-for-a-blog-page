using BBloGer.Models.Entiteis;
using Microsoft.EntityFrameworkCore;

namespace BBloGer.Models.Context
{
	public class DatabaseContext : DbContext
	{
        public DbSet<User> Users { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Note> Notes { get; set; }
		public DbSet<LikedNote> LikedNote { get; set; }
		public DbSet<EmailMembership> EmailMembership { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (optionsBuilder.IsConfigured == false)
			{
				optionsBuilder.UseSqlServer("Server=localhost;Database=NoteDB; Trusted_Connection=true");  // sql e nasıl bağlanacağını (Veri tabanı)söylüyoruz parantez içinde.
				optionsBuilder.UseLazyLoadingProxies();  //lazy loadingi aktifleştirmiş olduk.
			}
		}
	}
}
