using System;

namespace _2DV610FikaApi.Models
{
    public static class Extensions
    {
        public static bool IsWithin(this int ? value, int minimum, int maximum)
        {
            return  value >= minimum && value <= maximum;
        }
    }
}