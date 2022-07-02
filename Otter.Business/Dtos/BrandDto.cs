using System.Collections.Generic;

namespace Otter.Business.Dtos
{
    public class BrandDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<ModelDto> Models { get; set; }
    }
}