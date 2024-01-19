using Microsoft.EntityFrameworkCore;

namespace ChallengeApi.Entities
{
    [Owned]
    public class ServiceTime
    {
        public int Id { get; set; }
        public string Servicer { get; set; }
        public DateTime ServiceDate { get; set; }
        public int CarId { get; set; } // Foreign        
    }
}