using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChallengeApi.Entities.Configs
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FullName).IsRequired();

            builder.OwnsMany<ServiceTime>(p =>
            p.ServiceTimes, (a) =>
            {
                a.WithOwner().HasForeignKey(st=>st.CarId);
                a.ToTable("ServiceTimes");
                a.HasKey("Id");
                a.Property(st => st.ServiceDate).IsRequired();
                a.Property(st => st.Servicer).IsRequired();
            });
        
        }
    }
}
