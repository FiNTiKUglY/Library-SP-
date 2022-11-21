using Microsoft.AspNetCore.Builder;
using Library.Models;
namespace Library.Database
{
	public class DBObject
	{
		public static void Initial(AppDBContent content)
		{ 
			content.SaveChanges();
		}
	}
}