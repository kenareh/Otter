using Otter.Common.Entities;

namespace Otter.Business.Dtos
{
    public class ModelDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string EnName { get; set; }

        public int Index { get; set; }
        public long BrandId { get; set; }
    }
}