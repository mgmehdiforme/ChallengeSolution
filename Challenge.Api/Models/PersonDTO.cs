using ChallengeApi.Entities;

namespace ChallengeApi.Models
{
    public class PersonDTO
    {        
        public string FullName { get; set; }
        public List<AddressDTO> Addresses { get; set; } = new List<AddressDTO>();
    }
}
