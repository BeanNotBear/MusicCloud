using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MusicCloud.API.Data
{
	public class SoundCloudAuthDbContext : IdentityDbContext
	{
		public SoundCloudAuthDbContext(DbContextOptions<SoundCloudAuthDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			const string ADMIN = "675924dc-ee02-47f0-9745-b4c5f585b26c";
			const string MUSICIAN = "c8505ff5-0440-4547-a3cd-77a73623cb3e";
			const string LISTENER = "6f7de6e3-f437-42e4-a02b-d49a37d024e3";

			var roles = new List<IdentityRole>
			{
				new IdentityRole
				{
					Id = ADMIN,
					ConcurrencyStamp = ADMIN,
					Name = "Admin",
					NormalizedName = "Admin".ToUpper()
				},
				new IdentityRole
				{
					Id = MUSICIAN,
					ConcurrencyStamp = MUSICIAN,
					Name = "Musician",
					NormalizedName = "Musician".ToUpper()
				},
				new IdentityRole
				{
					Id = LISTENER,
					ConcurrencyStamp =LISTENER,
					Name = "Listener",
					NormalizedName = "Listener".ToUpper()
				},
			};

			builder.Entity<IdentityRole>().HasData(roles);
		}
	}
}
