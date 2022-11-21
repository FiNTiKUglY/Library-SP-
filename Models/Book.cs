namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int Year { get; set; }
        public string? File { get; set; }
        
		public override string ToString()
        {
            return $"{Title} - {Author}, {Year.ToString()}";
        }
    }
}