using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day4 {
    class Program {
        static void Main(string[] args) {
            var input = File.ReadAllLines("input.txt");
            long count = 0;
            for(int i=0; i < input.Length; i++) {
                var rs = Regex.Match(input[i], @"(?:(\w+)\-)+(\d+)\[(\w+)\]");
                var cnt = rs.Groups[1].Captures.Count;
                var dict = new Dictionary<char, int>();
                var crs = new StringBuilder();
                for(int j=0; j < cnt; j++) {
                    var ss = rs.Groups[1].Captures[j].Value;
                    for (int k=0; k < ss.Length; k++) {
                        if (!dict.ContainsKey(ss[k])) {
                            dict.Add(ss[k], 1);
                        } else {
                            dict[ss[k]]++;
                        }
                    }
                    crs.Append(ss).Append("-");
                }
                var sp = String.Join("", dict.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Select(x => x.Key).Take(5));
                if (sp == rs.Groups[3].Value) {
                    long rc = long.Parse(rs.Groups[2].Value);

                    var cr = crs.ToString().ToCharArray();
                    //Console.WriteLine(cr);
                    for (int j = 0; j < cr.Length; j++) {
                        if (cr[j] == '-') cr[j] = ' ';
                        else {
                            for(int k=0; k < rc; k++) {
                                cr[j] = (char)((int)cr[j]+1);
                                if (cr[j] > 'z') cr[j] = 'a';
                            }
                        }
                    }
                    var sssd = string.Join("", cr);
                    if(sssd.IndexOf("north") >= 0) {

                        Console.WriteLine(rc);
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
