using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Otter.Common.Entities;

namespace Otter.DataAccess.SQLServer.Configurations
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.Property(p => p.Title).IsRequired();
            builder.HasData(

                new Currency() { Id = 1, LatinName = "Rial", Title = "ریال" },
                new Currency() { Id = 2, LatinName = "Dollar", Title = "دلار" },
                new Currency() { Id = 3, LatinName = "Euro", Title = "یورو" },
                new Currency() { Id = 4, LatinName = "Dirham", Title = "درهم" }
            );
        }
    }
}