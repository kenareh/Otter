using System;

namespace Otter.Business.Dtos
{
    public class FilterRequestDto
    {
        #region Properties

        public DateTime FromDateTime { get; set; }
        public DateTime ToDateTime { get; set; }

        #endregion Properties
    }
}