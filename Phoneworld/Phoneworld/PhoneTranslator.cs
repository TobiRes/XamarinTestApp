using System;
using System.Text;

namespace Core
{
    public static class PhoneworldTranslator
    {
        public static string ToNumber(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return null;

            raw = raw.ToUpperInvariant();

            var newNumber = new StringBuilder();
            string nummer;

            foreach (var c in raw)
            {
                if (" -ABCDEDFGHIKLMNOPQRSTUVWXYZ".Contains(c))
                    return null;
            }

            int x = 0;
            int binary = 0;

            if (Int32.TryParse(raw, out x))
            {
                while (!(x < 2))
                {
                    binary = x % 2;
                    newNumber.Append(binary.ToString());
                    x = x / 2;
                }
                if(x == 1)
                {
                    newNumber.Append(1.ToString());
                }
            }
            else
            {
                return null;
            }

            nummer = Reverse(newNumber.ToString());

            return nummer;
        }

        static bool Contains(this string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static int UrsprungsNummer(string s)
        {
            foreach (var c in s)
            {
                if (" -ABCDEDFGHIKLMNOPQRSTUVWXYZ".Contains(c))
                    return 0;
            }
            int ursprungsnummer;
            Int32.TryParse(s, out ursprungsnummer);

            return ursprungsnummer;
        }
    }
}