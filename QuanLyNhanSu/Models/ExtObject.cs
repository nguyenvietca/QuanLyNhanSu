using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Models
{
    public static class ExtObject
    {
        /**
               * copy thuộc tính từ Source to TDestination
               */
        public static void CopyPropertiesTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            var sourceProperties = typeof(TSource).GetProperties();
            var destinationProperties = typeof(TDestination).GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                var destinationProperty = destinationProperties.FirstOrDefault(x => x.Name == sourceProperty.Name && x.PropertyType == sourceProperty.PropertyType);

                if (destinationProperty != null && destinationProperty.CanWrite)
                {
                    destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
                }
            }
        }
    }
}