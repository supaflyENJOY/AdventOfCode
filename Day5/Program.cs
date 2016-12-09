using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day5 {
    class Program {
        static void Main(string[] args) {
            var key = "ffykfhsq";
            MD5 md5 = new MD5CryptoServiceProvider();
            char[] result = new char[8];
            int found = 0;
            for (int i = 0; found < 8; i++) {
                byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(key+i));
                var str = BitConverter.ToString(checkSum);
                if (str.IndexOf("00-00-0") == 0) {
                    str = str.Replace("-", string.Empty);
                    if (str[5] >= '0' && str[5] <= '7' && result[str[5] - '0'] == 0) {
                        result[str[5]-'0'] = Char.ToLower(str[6]);
                        Console.WriteLine(result);
                        found++;
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
