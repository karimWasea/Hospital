
using Microsoft.AspNetCore.Mvc;

using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
namespace hospitalUtilities
{

    public static class EnumExtensions
    {
        public static string GetDisplayName<TEnum>(this TEnum enumValue)
            where TEnum : Enum
        {
            DisplayAttribute displayAttribute = enumValue.GetType()
                .GetField(enumValue.ToString())
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .SingleOrDefault() as DisplayAttribute;

            return displayAttribute?.Name ?? enumValue.ToString();
        }
    }




}
