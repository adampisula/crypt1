using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace crypt1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (;;)
            {
                MD5 md5hash = MD5.Create();
                Console.Write("Insert some text: ");
                string t = Console.ReadLine();
                Console.Write("Repetitions: ");
                int count = Int32.Parse(Console.ReadLine());
                Console.WriteLine();

                string end = toend(t);
                Console.WriteLine("END: " + end);
                string beg = tobeg(end);
                Console.WriteLine("BEG: " + beg);

                for(int i = 0; i < count; i++)
                {
                    beg = GetMd5Hash(md5hash, beg);
                    Console.WriteLine("MD5: " + beg);
                    end = toend(beg);
                    Console.WriteLine("END: " + end);
                    beg = tobeg(end);
                    Console.WriteLine("BEG: " + beg);
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        static string toend(string t)
        {
            t += '#';
            string s = "";
            int tv = 0;

            for (int i = 0; i < t.Length - 1; i++)
            {
                tv = (int)t[i] * (int)t[i + 1];
                if (tv > 126)
                    tv %= 126;
                if (tv < 32)
                    tv += 32;

                s += (char)tv;
            }

            return s;
        }

        static string tobeg(string t)
        {
            t = '#' + t;
            string s = "";
            int tv = 0;

            for (int i = t.Length - 1; i > 0; i--)
            {
                tv = (int)t[i] * (int)t[i - 1];
                if (tv > 126)
                    tv %= 126;
                if (tv < 32)
                    tv += 32;

                s += (char)tv;
            }

            return s;
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
