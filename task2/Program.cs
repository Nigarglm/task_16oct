using System.Diagnostics.Tracing;

namespace _16oct_taskk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 5;
            Console.WriteLine($" {num} tek ededdir ? {Utility.IsOdd(num)}");
            Console.WriteLine($" {num} cut ededdir? {Utility.IsEven(num)}");

            string str = "Nigar123";
            Console.WriteLine($" {str} reqem qebul edib? {Utility.HasDigit(str)}");

            string password = "Nigar1010";
            Console.WriteLine($" {password} duzgun paroldur? {Utility.CheckPassword(password)}");

            string text = "nIgAr";
            Console.WriteLine($"Capitalized text: {text.Capitalize()}");
        }
    }
    

public static class Extensions
    {
        public static string Capitalize(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            return char.ToUpper(input[0])+input.Substring(1).ToLower();
        }
    }

    public static class Utility
    {
        public static bool IsOdd(int number)
        {
            return number % 2 != 0;
        }

        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public static bool HasDigit(string input)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                    return true;
            }
            return false;
        }

        public static bool CheckPassword(string password)
        {
            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;

            if (password.Length < 8)
                return false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                    hasUpper = true;

                if (char.IsLower(c))
                    hasLower = true;

                if (char.IsDigit(c))
                    hasDigit = true;
            }

            return hasUpper && hasLower && hasDigit;
        }
    }

}