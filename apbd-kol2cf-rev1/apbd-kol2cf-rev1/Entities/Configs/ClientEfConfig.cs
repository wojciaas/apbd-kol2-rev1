using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_kol2cf_rev1.Entities.Configs
{
    public class ClientEfConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.IdClient);
            builder.Property(c => c.IdClient).ValueGeneratedNever();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Birthday).HasColumnType("datetime").IsRequired();
            builder.Property(c => c.Pesel).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(100).IsRequired();
            builder.HasOne(c => c.ClientCategoryNavigation)
                .WithMany(cc => cc.Clients)
                .HasForeignKey(c => c.IdClientCategory)
                .HasConstraintName("Client_ClientCategory")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Client
                {
                    IdClient = 1,
                    Name = "Jan",
                    LastName = "Kowalski",
                    Birthday = new System.DateTime(1990, 1, 1),
                    Pesel = "12345678901",
                    Email = "jkowal@ex.com",
                    IdClientCategory = 2
                },
                new Client
                {
                    IdClient = 2,
                    Name = "Anna",
                    LastName = "Nowak",
                    Birthday = new DateTime(1995, 1, 1),
                    Pesel = "12345678902",
                    Email = "nowakA@ex.com",
                    IdClientCategory = 3
                },
                new Client
                {
                    IdClient = 3,
                    Name = "Piotr",
                    LastName = "Wiśniewski",
                    Birthday = new DateTime(1985, 1, 1),
                    Pesel = "12345678903",
                    Email = "pwis@ex.com",
                    IdClientCategory = 1
                }
                );
            
            builder.ToTable("Client");
        }
    }
}