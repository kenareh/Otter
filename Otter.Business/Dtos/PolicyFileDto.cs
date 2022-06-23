using Otter.Common.Enums;

namespace Otter.Business.Dtos
{
    public class PolicyFileDto
    {
        public BaseEnumDto PolicyFileType { get; set; }
        public string Base64 { get; set; }

        public long PolicyId { get; set; }
    }
}