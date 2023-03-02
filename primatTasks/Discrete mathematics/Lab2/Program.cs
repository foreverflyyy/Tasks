using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;

namespace Lab2
{
    class Program
    {
        static void Main()
        {

        }

        static void DistanceHemminga()
        {
            char[] m = new char[] {' ', 'и', 'к', 'л', 'м', 'н', 'о', 'п', 'р'};
            string[] n = new string[] { "00000", "00011", "00101", "00110", "01001", "01010", "10001", "11000" };
            var table = new List<List<string>>[100];

            for (int i = 0; i < n.Length; i++)
            {
                var line = new List<string>(m[i + 1]);

                for (int l = 0; l < i; l++)
                    line.Add("");

                line.Add("-");

                for (int j = i + 1; j < n.Length; j++)
                {
                    var num = 0;
                    for (int k = 0; k < n[i].Length; k++)
                        if (n[i][k] != n[j][k])
                            num++;
                    line.Add(num.ToString());
                }
                table.Add(line);
            }
            Console.WriteLine(tabulate(table, m, tablefmt = "psql", numalign = 'center'))
        }

        static void CodingRLE()
        {
            // aaaaaaaaaaaaadghtttttttttttyiklooooooop 

            string input = "aaaaaaaaaaaaadghtttttttttttyiklooooooop";

            int amount = 2;
            string final_string = "";

            for(int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                    amount++;
                else
                {
                    var a = input[i];
                    final_string = final_string + amount.ToString() + input[i]
                        + " ";
                    amount = 1;
                }

                
            }

            if(input[input.Length - 1] != input[input.Length - 2])
                final_string += amount.ToString() + 
                    input[input.Length - 1] + " ";

            Console.WriteLine(final_string);
        }

        static void ArithmeticCoding()
        {
            string alphabet = "aecdfb";
            float[] p = new float[] { 0.10f, 0.10f, 0.05f, 0.55f, 0.10f, 0.10f };
            string word = "eacdbf";
            var code = Coding(word, alphabet, p);
            Console.WriteLine(code);
            Console.WriteLine(Decoding(code, word.Length, alphabet, p));
        }

        static string Float2Bin(int x, double eps = 1e-9)
        {
            string res = "";
            while(x > eps)
            {
                x *= 2;
                res += (int)x;
                x -= (int)x;
            }

            return res;
        }

        static int Bin2Float(int x)
        {
            var result = Math.Pow(2, (-1 * i - 1));
            return result;
        }

        static string FindCode(string a, string b)
        {
            int i = 0;
            a += '0' * (b.Length - a.Length);

            while (a[i] == b[i])
                i++;

            var res = a[:i] +'0';
            var cnt = 0;

            while (a[i] == 1)
            {
                i++;
                cnt++;
            }
            res += "1" * (cnt + 1);
            return res;
        }

        static string Coding(string word, string certainChar, float[] p)
        {
            int left = 0;
            int right = 1;

            foreach(var letter in word)
            {
                var i = certainChar.IndexOf(letter);
                left, right = (left + (left - right) * sum(p[:i]),
                    left + (right - left) * sum(p[: i + 1]));
            }

            return FindCode(*map(Float2Bin, (left, right)));
        }

        static void Decoding(int code, int length, char alphabet, int p)
        {
            code = Bin2Float(code);
            string word = "";

            int left = 0;
            int right = 1;

            for(int j = 0; j < length; j++)
                for(int i = 0; )
        }
    }
}