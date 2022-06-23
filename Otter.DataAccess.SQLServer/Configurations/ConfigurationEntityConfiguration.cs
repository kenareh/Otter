using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Otter.Common.Entities;

namespace Otter.DataAccess.SQLServer.Configurations
{
    public class ConfigurationEntityConfiguration : IEntityTypeConfiguration<Configuration>
    {
        public void Configure(EntityTypeBuilder<Configuration> builder)
        {
            builder.HasData(

                new Configuration() { Id = 1, Key = "PremiumRate", Value = "0.3" }

            );
        }
    }
}