using System;
using System.Collections.Generic;
using System.Linq;
using Otter.Common.Enums;
using Sample.Common.Tools;

namespace Otter.Common.Tools
{
    public static class EnumFactory
    {
        public static List<BaseEnumDto> CastEnumToObject<T>()
        where T : Enum
        {
            var baseEnumDtos = Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(t => new BaseEnumDto()
                {
                    Id = (Convert.ToInt32(t)),
                    Title = t.ToString(),
                    Description = t.GetDescription()
                }).ToList();
            return baseEnumDtos;
        }

        public static BaseEnumDto ToBaseEnumDto<T>(this T e)
            where T : Enum
        {
            var baseEnumDtos = new BaseEnumDto()
            {
                Id = (Convert.ToInt32(e)),
                Title = e.ToString(),
                Description = e.GetDescription()
            };
            return baseEnumDtos;
        }
    }
}