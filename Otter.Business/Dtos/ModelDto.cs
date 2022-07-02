using Otter.Common.Entities;

namespace Otter.Business.Dtos
{
    public class ModelDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long BrandId { get; set; }
    }
}