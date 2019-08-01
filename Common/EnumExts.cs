﻿using System;
using System.Collections.Generic;

namespace Common
{
    /// <summary>
    /// Represents extension methods on Enum objects
    /// </summary>
    public static class EnumExts
    {
        /// <summary>
        /// Returns the name of current/selected enum
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enum">Current/Selected enum</param>
        /// <returns>Name of enum</returns>
        public static string GetName<TEnum>(this TEnum @enum) where TEnum : Enum
        {
            if (@enum == null)
                throw new ArgumentNullException(nameof(@enum));
            
            return Enum.GetName(typeof(TEnum), @enum);
        }
        /// <summary>
        /// Returns all the items defined in an <see cref="Enum"/> as a 
        /// dictionary collection of key value pairs.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enum">Current enum value</param>
        /// <returns>Dictionary of enumeration.</returns>
        public static Dictionary<string, int> GetEnumPairs<TEnum>(this TEnum @enum)
            where TEnum : Enum {
            return GetEnumPairs<TEnum>();
        }
        /// <summary>
        /// Returns all the items defined in an <see cref="Enum"/> as a 
        /// dictionary collection of key value pairs.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns>Dictionary of enumeration.</returns>
        public static Dictionary<string, int> GetEnumPairs<TEnum>()
            where TEnum : Enum {
            return GetEnumPairs(typeof(TEnum));
        }
        /// <summary>
        /// Returns all the items defined in an <see cref="Enum"/> as a 
        /// dictionary collection of key value pairs.
        /// </summary>
        /// <param name="enumType">Enumeration <see cref="Type"/></param>
        /// <returns>Dictionary of enumeration.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="enumType"/> if null.</exception>
        /// <exception cref="ArgumentException">If <paramref name="enumType"/> is not of type enumeration.
        /// </exception>
        public static Dictionary<string,int> GetEnumPairs(Type enumType) {
            if (enumType == null)
                throw new ArgumentNullException(nameof(enumType));

            if (!enumType.IsEnum)
                throw new ArgumentException("The specified Type is not of type enumeration.", nameof(enumType));

            Dictionary<string, int> pairs = new Dictionary<string, int>();
            string[] names = Enum.GetNames(enumType);
            Array array = Enum.GetValues(enumType);

            for (int i = 0; i < names.Length; i++) {
                pairs.Add(names[i], (int)array.GetValue(i));
            }
            return pairs;
        }
    }
}