﻿using Common.Attributes;
using System.ComponentModel;
using System.Reflection;

namespace Common
{
    /// <summary>
    /// Collection of extension methods for class property attributes.
    /// </summary>
    public static class AttributesExts
    {
        /// <summary>
        /// Gets the value of <see cref="SymbolAttribute"/> for the specified property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">Property</param>
        /// <returns>Value of symbol.</returns>
        public static string GetSymbolAttribute<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            SymbolAttribute[] attributes = (SymbolAttribute[])fi.GetCustomAttributes(
                typeof(SymbolAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Symbol;
            else return source.ToString();
        }
        /// <summary>
        /// Gets the description text of <see cref="DescriptionAttribute"/> for the specified property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">Property</param>
        /// <returns>Value of Description</returns>
        public static string DescriptionAttr<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }
    }
}