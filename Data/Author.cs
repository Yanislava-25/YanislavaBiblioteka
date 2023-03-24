namespace Biblioteka.Data
{
    public class Author
    {
        public int Id { get; set; }
        public string FirsrName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        
        public DateTime RegisterOn { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
