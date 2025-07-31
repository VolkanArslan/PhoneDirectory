using Directory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Directory.Infrastructure.Persistence.Configurations;

public class ContactInformationConfiguration : IEntityTypeConfiguration<ContactInformation>
{
    public void Configure(EntityTypeBuilder<ContactInformation> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Type)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(c => c.Value)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasOne(c => c.Person)
            .WithMany(p => p.ContactInformations)
            .HasForeignKey(c => c.PersonId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}