using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1 {
    class Program {
        struct xy {
            public int x;
           public  int y;
        }
        static void Main(string[] args) {
            var l = new List<xy>();
            string s = "L1,L3,L5,L3,R1,L4,L5,R1,R3,L5,R1,L3,L2,L3,R2,R2,L3,L3,R1,L2,R1,L3,L2,R4,R2,L5,R4,L5,R4,L2,R3,L2,R4,R1,L5,L4,R1,L2,R3,R1,R2,L4,R1,L2,R3,L2,L3,R5,L192,R4,L5,R4,L1,R4,L4,R2,L5,R45,L2,L5,R4,R5,L3,R5,R77,R2,R5,L5,R1,R4,L4,L4,R2,L4,L1,R191,R1,L1,L2,L2,L4,L3,R1,L3,R1,R5,R3,L1,L4,L2,L3,L1,L1,R5,L4,R1,L3,R1,L2,R1,R4,R5,L4,L2,R4,R5,L1,L2,R3,L4,R2,R2,R3,L2,L3,L5,R3,R1,L4,L3,R4,R2,R2,R2,R1,L4,R4,R1,R2,R1,L2,L2,R4,L1,L2,R3,L3,L5,L4,R4,L3,L1,L5,L3,L5,R5,L5,L4,L2,R1,L2,L4,L2,L4,L1,R4,R4,R5,R1,L4,R2,L4,L2,L4,R2,L4,L1,L2,R1,R4,R3,R2,R2,R5,L1,L2";
            var ps = s.Split(',');
            int x = 0, y = 0,f=0;
            for (int i = 0; i < ps.Length; i++) {
                if (ps[i][0] == 'L') {
                    f -= 1;
                } else f += 1;
                if (f < 0) f += 4;
                if (f > 3) f -= 4;
                var p = int.Parse(ps[i].Substring(1));
                for(int j=0; j < p; j++) {
                    xy my = new xy { x = x, y = y };
                    if (l.Contains(my)) {
                        break;
                    }
                    l.Add(my);
                    if (f == 0) x -= 1;
                    else if (f == 1) y -= 1;
                    else if (f == 2) x += 1;
                    else if (f == 3) y += 1;

                }
            }
            Console.WriteLine(x+" "+y);
        }
    }
}
