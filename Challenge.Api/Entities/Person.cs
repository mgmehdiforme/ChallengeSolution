namespace ChallengeApi.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }

}