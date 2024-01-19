using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChallengeApi.Entities.Configs
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FullName).IsRequired();
            
        }
    }
}
