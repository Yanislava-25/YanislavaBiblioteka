namespace Biblioteka.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Title{ get; set; }
        //M:1
        public int AuthorId { get; set; }
        public Author Authors { get; set; }

        //M:1
        public int PressId { get; set; }
        public Press Presses { get; set; }       
        
        //M:1
        public string GenreId { get; set; }
        public Genre Genres { get; set; }   

        public int YearPublish { get; set; }    

        public DateTime RegisterOn { get; set; }

        public ICollection<Card> Cards { get; set; }
    }
}
