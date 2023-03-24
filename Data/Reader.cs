using Microsoft.AspNetCore.Identity;

namespace Biblioteka.Data
{
    public class Reader:IdentityUser
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public DateTime RegisterOn { get; set; }

        //1:M
        public ICollection<Card> Cards { get; set; }
    }
}
