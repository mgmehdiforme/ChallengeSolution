using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChallengeApi.Entities.Configs
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Street).IsRequired();
            builder.Property(a => a.City).IsRequired();
            // تعریف رابطه
            builder.HasOne(a => a.Person)
                   .WithMany(p => p.Addresses)
                   .HasForeignKey(a => a.PersonId);
            
        }
    }
}
