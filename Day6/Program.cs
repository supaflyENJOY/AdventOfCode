using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6 {
    class Program {
        static void Main(string[] args) {
            var input = File.ReadAllLines("input.txt");
            var len = input[0].Length;
            var p = new Dictionary<char, int>[len];
            for(int i=0; i < len; i++) {
                p[i] = new Dictionary<char, int>();
            }
            for(int i=0; i < input.Length; i++) {
                for(int j=0; j < len; j++) {
                    if (p[j].ContainsKey(input[i][j])) {
                        p[j][input[i][j]]++;
                    } else {
                        p[j].Add(input[i][j], 1);
                    }
                }
            }
            for(int i=0; i < len; i++) {
                Console.Write(p[i].OrderBy(x => x.Value).First().Key);
            }
            Console.WriteLine();
        }
    }
}
