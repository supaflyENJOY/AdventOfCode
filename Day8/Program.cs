using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day8 {
    class Program {
        static void Main(string[] args) {
            var input = File.ReadAllLines("input.txt");
            var display = new int[100, 12];
            for (int i=0; i < input.Length; i++) {
                if(input[i].IndexOf("rect") >= 0) {
                    Console.WriteLine("rect");
                    var nums = input[i].Split(' ')[1].Split('x').Select(x => int.Parse(x)).ToArray();
                    for(int j=0; j < nums[0]; j++) {
                        for(int k=0; k < nums[1]; k++) {
                            display[j, k] = 1;
                        }
                    }
                } else if (input[i].IndexOf("rotate row") == 0) {
                    Console.WriteLine("rotate row");
                    var nums = Regex.Match(input[i], @"rotate row y=(\d+) by (\d+)");
                    var a = int.Parse(nums.Groups[1].Value);
                    var b = int.Parse(nums.Groups[2].Value);
                    for (int j = 49; j >= 0; j--) {
                        display[j + b, a] = display[j, a];
                    }
                    for (int j = b - 1; j >= 0; j--) {
                        display[j, a] = display[j + 50, a];
                    }
                } else if (input[i].IndexOf("rotate column") == 0) {
                    Console.WriteLine("rotate column");
                    var nums = Regex.Match(input[i], @"rotate column x=(\d+) by (\d+)");
                    var a = int.Parse(nums.Groups[1].Value);
                    var b = int.Parse(nums.Groups[2].Value);
                    for (int j = 5; j >= 0; j--) {
                        display[a, j + b] = display[a, j];
                    }
                    for (int j = b - 1; j >= 0; j--) {
                        display[a, j] = display[a, j + 6];
                    }
                }
            }
            for (int j = 0; j < 6; j++) {
                for (int k = 0; k < 50; k++) {
                    Console.Write(display[k, j]==1?'#':'.');
                }
                Console.WriteLine();
            }
        }
    }
}
