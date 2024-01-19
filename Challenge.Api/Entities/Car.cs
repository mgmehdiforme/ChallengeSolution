namespace ChallengeApi.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<ServiceTime> ServiceTimes { get; set; } = new List<ServiceTime>();
    }

}