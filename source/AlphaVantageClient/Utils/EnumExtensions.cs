using System;
using System.Reflection;

namespace AlphaVantageClient.Utils
{
    internal static class EnumExtensions
    {
        public static T GetAttribute<T>(this Enum @enum) where T : Attribute
        {
            var type = @enum.GetType();
            var name = Enum.GetName(type, @enum);
            var field = type.GetField(name);
            var attribute = field.GetCustomAttribute<T>();
            return attribute;
        }
    }
}