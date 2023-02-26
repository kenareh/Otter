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

                new Configuration() { Id = 1, Key = "PremiumRate", Value = "0.04" },
                new Configuration() { Id = 2, Key = "IPGTerminalId", Value = "08069161" },
                new Configuration() { Id = 3, Key = "IPGAcceptorId", Value = "992180008069161" },
                new Configuration() { Id = 4, Key = "IPGPassPhrase", Value = "76FEB0F316883B83" },
                new Configuration() { Id = 5, Key = "IPGAccountNumber", Value = "0000113939400" },
                new Configuration() { Id = 6, Key = "IPGRsaPublicKey", Value = @"-----BEGIN PUBLIC KEY-----
MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDfA/K5iF5s7GqNpBm+mRdZQvmA
mSMpO+65h4jrIEEbS+HoMGWVZsBz+Kmh7PUZX48bqSqIUcIOlF0glxLENGwCaQU2
lMrw1CNODqhEKbP4j2VjZisGgUSGv8fmBEpqBjwT1us6r+z0JwlCXeJ46BLAIyzg
003PX0iRNjhnzSOx7QIDAQAB
-----END PUBLIC KEY-----" }

            );
        }
    }
}