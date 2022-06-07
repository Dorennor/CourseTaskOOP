using System;
using System.Security.Cryptography;

namespace CourseTaskOOP.PL.Extensions;

public static class StringExtension
{
    public static string GeneratePasswordHash(this string password)
    {
        using (var sha512 = SHA512.Create())
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] hashCode = sha512.ComputeHash(bytes);
            return BitConverter.ToString(hashCode);
        }
    }
}