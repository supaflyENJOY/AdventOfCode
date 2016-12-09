using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2 {
    class Program {
        static char getNum(int x, int y) {
            if (x == 2 && y == 0) return '1';
            if (x == 1 && y == 1) return '2';
            if (x == 2 && y == 1) return '3';
            if (x == 3 && y == 1) return '4';
            if (x == 0 && y == 2) return '5';
            if (x == 1 && y == 2) return '6';
            if (x == 2 && y == 2) return '7';
            if (x == 3 && y == 2) return '8';
            if (x == 4 && y == 2) return '9';
            if (x == 1 && y == 3) return 'A';
            if (x == 2 && y == 3) return 'B';
            if (x == 3 && y == 3) return 'C';
            if (x == 2 && y == 4) return 'D';
            return '0';
        }
        static void Main(string[] args) {
            var p = File.ReadAllLines("input.txt");
            int x = 0, y = 2,mx,my;
            for(int i=0; i < p.GetLength(0); i++) {
                for (int j=0; j < p[i].Length; j++) {
                    mx = x;
                    my = y;
                    if (p[i][j] == 'U') my--;
                    else if (p[i][j] == 'D') my++;
                    else if (p[i][j] == 'L') mx--;
                    else if (p[i][j] == 'R') mx++;
                    if(Math.Abs(mx-2)+Math.Abs(my-2) <= 2) {
                        x = mx;
                        y = my;
                    }
                }
                Console.Write(getNum(x,y));
            }
        }
    }
}
