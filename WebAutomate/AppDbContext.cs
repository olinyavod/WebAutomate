using Microsoft.EntityFrameworkCore;
using WebAutomate.Models;

namespace WebAutomate
{
	public class AppDbContext : DbContext
	{
		#region Properties

		public DbSet<Product> Products { get; set; }

		public DbSet<Coin> Coins { get; set; }

		#endregion

		#region ctor

		public AppDbContext(DbContextOptions options)
			: base(options)
		{

		}

		#endregion

		#region Protected methods

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>()
				.HasData(new Product
					{
						Id = 1,
						Name = "Coca-Cola",
						Count = 10,
						ImageUrl = "images\\coca-cola.svg",
						Price = 60
					},
					new Product
					{
						Id = 2,
						Name = "Sprite",
						Count = 20,
						ImageUrl = "images\\sprite.svg",
						Price = 50
					},
					new Product
					{
						Id = 3,
						Name = "Fanta",
						Count = 5,
						ImageUrl = "images\\fanta.svg",
						Price = 55
					},
					new Product
					{
						Id = 4,
						Name = "7-up",
						Count = 0,
						ImageUrl = "images\\7-Up.svg"
					});

			modelBuilder.Entity<Coin>()
				.HasData(new Coin
					{
						Id = 1,
						Nominal = 1,
						Count = 100,
						IsBlocked = false
					},
					new Coin
					{
						Id = 2,
						Nominal = 2,
						Count = 100,
						IsBlocked = false
					},
					new Coin
					{
						Id = 3,
						Nominal = 5,
						Count = 50,
						IsBlocked = false
					},
					new Coin
					{
						Id = 4,
						Nominal = 10,
						Count = 30,
						IsBlocked = false
					});
		}

		#endregion
	}
}
