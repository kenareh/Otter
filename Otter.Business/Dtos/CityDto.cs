namespace Otter.Business.Dtos
{
    public class CityDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string EnName { get; set; }

        public int Index { get; set; }
        public long ProvinceId { get; set; }
    }
}