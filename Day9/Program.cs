using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day9 {
    class Program {
        static long explode(string chars, long n) {
            long count = 0;
            for (int i = 0; i < chars.Length; i++) {
                if (chars[i] == '(') {
                    var marker = new String(chars.Skip(i + 1).TakeWhile(ch => ch != ')').ToArray());
                    var arr = marker.Split('x');
                    int nchars = Int32.Parse(arr[0]);
                    int skip = i + marker.Length + 2;
                    count += explode(new string(chars.Skip(skip).Take(nchars).ToArray()), Int32.Parse(arr[1]));
                    i = skip + nchars - 1;
                } else
                    count++;
            }
            return count * n;
        }

        static void Main(string[] args) {
            var lines = File.ReadAllText("input.txt");
            Console.WriteLine(explode(lines, 1));
        }
    }
}
