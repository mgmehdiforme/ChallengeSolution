using Microsoft.EntityFrameworkCore;

namespace ChallengeApi.Entities
{    
    public class Address
    {
        public int Id { get; set; } // Added a primary key for Address
        public string Street { get; set; }
        public string City { get; set; }
        public int PersonId { get; set; } // Foreign key
        public Person Person { get; set; } // Navigation property
    }
}