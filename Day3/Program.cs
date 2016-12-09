using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3 {
    class Program {
        static void Main(string[] args) {
            var f = File.ReadAllLines("input.txt");
            int count = 0;
            for(int i=0; i < f.Length; i += 3) {
                var ps0 = f[i].Replace("  ", " ").Trim().Replace("  ", " ").Split(' ');
                var ps1 = f[i+1].Replace("  ", " ").Trim().Replace("  ", " ").Split(' ');
                var ps2 = f[i+2].Replace("  ", " ").Trim().Replace("  ", " ").Split(' ');
                for (int j=0; j < 3; j++) {
                    int a = int.Parse(ps0[j]);
                    int b = int.Parse(ps1[j]);
                    int c = int.Parse(ps2[j]);
                    if (a + b > c && a + c > b && b + c > a) count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
