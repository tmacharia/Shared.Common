﻿using System;
using System.IO;

namespace Common.Structs
{
    /// <summary>
    /// Represents extension methods on byte arrays.
    /// </summary>
    public static class BytesExts
    {
        /// <summary>
        /// Converts a byte[] to its equivalent <see cref="string"/> of
        /// text using UTF encoding.
        /// </summary>
        /// <param name="bytes">byte array</param>
        /// <returns>
        /// <see cref="string"/> of text
        /// </returns>
        public static string ConvertToString(this byte[] bytes) => Constants.Encoding.GetString(bytes);
        /// <summary>
        /// Converts a stream of byte[] to a Base64 encoded
        /// <see cref="string"/> of text.
        /// </summary>
        /// <param name="bytes">Byte array</param>
        /// <returns>Base64 encoded <see cref="string"/></returns>
        public static string ToBase64String(this byte[] bytes) => Convert.ToBase64String(bytes);
        /// <summary>
        /// Converts a byte[] to a <see cref="Stream"/>
        /// </summary>
        /// <param name="bytes">Array of bytes to convert</param>
        /// <returns>A stream</returns>
        public static Stream ToStream(this byte[] bytes) => bytes.IsNotNull() ? new MemoryStream(bytes) : null;
    }
}