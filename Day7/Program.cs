using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day7 {
    class Program {
        static void Main(string[] args) {
            var input = File.ReadAllLines("input.txt");
            int count = 0;
            for (int i = 0; i < input.Length; i++) {
                //Console.WriteLine("---" + input[i]);
                var ps = Regex.Matches(input[i], @"(?:\b|\])\w*(\w)(\w)\1\w*(?:\b|\[)",RegexOptions.Singleline);
                if (ps.Count == 0) continue;
                //Console.WriteLine("--" + input[i]);
                var f = false;
                for (int j = 0; j < ps.Count; j++) {
                    string a = ps[j].Groups[1].Value;
                    string b = ps[j].Groups[2].Value;
                   // Console.WriteLine(a + " " + b);
                    if (a == b) continue;
                    var ps2 = Regex.Matches(input[i], @"" + b + a + b);
                    if (ps2.Count == 0) continue;
                    for(int k=0; k < ps2.Count; k++) {
                        if(ps2[k].Index+3 <= ps[j].Index || ps2[k].Index-3 >= ps[j].Index) {
                            f = true;
                            break;
                        }
                    }
                    if(f == true)
                        break;
                }
                if (f == false) continue;
                count++;
                Console.WriteLine(input[i]);

            }
            Console.WriteLine(count);
        }
    }
}