using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_kol2cf_rev1.Entities.Configs;

public class ClientCategoryEfConfig : IEntityTypeConfiguration<ClientCategory>
{
    public void Configure(EntityTypeBuilder<ClientCategory> builder)
    {
        builder.HasKey(cc => cc.IdClientCategory);
        builder.Property(cc => cc.IdClientCategory).ValueGeneratedNever();
        builder.Property(cc => cc.Name).HasMaxLength(100).IsRequired();
        builder.Property(cc => cc.Name).IsRequired();

        builder.HasData(
            new ClientCategory
            {
                IdClientCategory = 1,
                Name = "VIP"
            },
            new ClientCategory
            {
                IdClientCategory = 2,
                Name = "Regular"
            },
            new ClientCategory
            {
                IdClientCategory = 3,
                Name = "Poor"
            }
            );
        
        builder.ToTable("ClientCategory");
    }
}