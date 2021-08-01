using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    public class MaGiamGia
    {
        public int Id { get; set; }
        private string Code;

        public string MyCode
        {
            get { return Code; }
            set { Code =RandomString(5); }
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public decimal SoTienGiam { get; set; }

    }
}
