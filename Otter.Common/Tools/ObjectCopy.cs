using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Otter.Common.Tools
{
    public class ObjectCopy
    {
        public static TResult ShallowCopy<TResult, TSource>(TSource source)
        {
            if (source == null)
                return default(TResult);
            var sourceProperties = typeof(TSource)
                .GetProperties()
                .Where(p => p.CanRead && p.CanWrite);
            var targetProperties = typeof(TResult)
                .GetProperties()
                .Where(p => p.CanRead && p.CanWrite);
            var resultObj = Activator.CreateInstance<TResult>();
            foreach (var sourceProperty in sourceProperties)
            {
                try
                {
                    var property = targetProperties.FirstOrDefault(p => p.Name == sourceProperty.Name);

                    if (property != null && property.PropertyType.IsEquivalentTo(sourceProperty.PropertyType))
                    {
                        property.SetValue(resultObj, sourceProperty.GetValue(source, null), null);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            return resultObj;
        }

        public static List<TResult> ShallowCopy<TResult, TSource>(IEnumerable<TSource> sourceList)
        {
            var res = new List<TResult>();
            foreach (var source in sourceList)
            {
                res.Add(ShallowCopy<TResult, TSource>(source));
            }
            return res;
        }

        public static void Patch(object target, object source)
        {
            // Get properties from EF that are read/write and not marked witht he NotMappedAttribute
            var sourceProperties = source.GetType()
                .GetProperties()
                .Where(p => p.CanRead && p.CanWrite);
            //&&  p.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute), true).Length == 0);
            //var newObj = new TResult();
            var targetProperties = target.GetType().GetProperties()
                .Where(p => p.CanRead && p.CanWrite);

            foreach (var property in sourceProperties)
            {
                // Copy value
                try
                {
                    var prop = targetProperties.FirstOrDefault(p => p.Name == property.Name);

                    if (prop != null && prop.PropertyType.IsEquivalentTo(property.PropertyType))
                        prop.SetValue(target, property.GetValue(source, null), null);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}