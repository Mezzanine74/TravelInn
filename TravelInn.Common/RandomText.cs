using System;
using System.Linq;
using System.Text;

namespace TravelInn.Common
{
    public class RandomText
    {
        private static Random random = new Random();

        public static string String(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var str = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            var _return = new StringBuilder(str);

            var index = random.Next(4, 10);

            while (index <= length - 1)
            {
                _return[index] = ' ';
                index += random.Next(4, 10);
            }

            return _return.ToString();
        }

        public static string Telephone()
        {
            const string chars = "0123456789";

            var ulkeKodu = new string(Enumerable.Repeat(chars, 1)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            var sehirKodu = new string(Enumerable.Repeat(chars, 3)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            var telefon = new string(Enumerable.Repeat(chars, 7)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return $"+{ulkeKodu} ({sehirKodu}) {telefon}";
        }

        public static string Email()
        {
            const string chars = "abcdefghijklmnoprstxvwyz";

            var oncesi = new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            var sonrasi = new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return $"{oncesi}@{sonrasi}.com";
        }

        public static int Fiyat()
        {
            const string chars = "0123456789";

            return Convert.ToInt32(new string(Enumerable.Repeat(chars, random.Next(3, 6))
              .Select(s => s[random.Next(s.Length)]).ToArray()));
        }

    }
}
