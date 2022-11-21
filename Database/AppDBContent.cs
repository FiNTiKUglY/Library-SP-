using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.Database
{
	public class AppDBContent : DbContext
	{
		public DbSet<Book> Books { get; set; }
		public DbSet<User> Users { get; set; }
		public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
		{

		}
	}
}
