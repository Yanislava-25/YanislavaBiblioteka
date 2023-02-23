namespace Biblioteka.Data
{
    public class Press
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
