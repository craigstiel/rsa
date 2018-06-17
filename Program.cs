using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            UInt64 n = 471120228690799;
            UInt64 e = 17731;
            string c = "898475641513401,877496897694523,462669843696523,910141737577126,4912762521964";
            UInt64 m = M(n);
            //UInt64 d = D(n, e);
            string decode = Decode(c, e, n);
            //string encode = Encode(c, e, n);

            Console.ReadLine();
        }

        static UInt64 M(UInt64 n)
        {
            UInt64 p = 1;
            List<UInt64> Dividers = new List<UInt64>();
            for (UInt64 i = 2; i <= Math.Floor(Math.Sqrt(n)); i++)
            {
                if (n % i == 0)
                {
                    bool IsPrime = true;
                    foreach (UInt64 j in Dividers)
                        if (i % j == 0) { IsPrime = false; break; }
                    if (IsPrime)
                        Dividers.Add(i); p *= i;
                }
            }
            if (p == 1) { Dividers.Add(n); }
            else
            {
                Dividers.AddRange(Dividers);
                UInt64 next = n / p;
            }
            UInt64 q = n / p;
            UInt64 Mp = Convert.ToUInt64(p - 1);
            UInt64 Mq = Convert.ToUInt64(q - 1);
            UInt64 M = Mp * Mq;
            //Console.WriteLine(M);
            return M;
        }

        static UInt64 NOD(UInt64 x, UInt64 y)
        {
            UInt64 g;
            g = y;
            while (x > 0)
            {
                g = x;
                x = y % x;
                y = g;
            }
            return g;
        }

        static UInt64 D(UInt64 n, UInt64 e)
        {
            UInt64 m = M(n);
            UInt64 d, check, dd;
            dd = 0;
            for (d = 3; d < n; d++)
            {
                check = NOD(m, d);
                if (check == 1)
                    {
                    if (Convert.ToUInt64((d * e) % m) == 1)
                    {
                        dd = d;
                    }
                }
            }
            return dd;            
        }

        static string Decode(string c, UInt64 n, UInt64 e)
        {
            //UInt64 d = ;
            UInt64 d = 1223;
            string res = "";

            Char delimiter = ',';
            String[] substrings = c.Split(delimiter);

            BigInteger shifr = 0;

            foreach (string str in substrings)
            {
                shifr = Convert.ToUInt64(str);
                BigInteger shifr1 = BigInteger.ModPow(shifr, d, n);
                res += shifr1;
            }
            //Console.WriteLine(res);
            return res;
        }

        /*static string Encode(string c, UInt64 n, UInt64 e)
        {
            string res = Decode(c, n, e);
            //сюда вставить получившуюся в декаде последовательность
            string rsa = "";

            BigInteger obrshifr = 0;

            res = Convert.ToString(res);

            foreach (string obrstr in res)
            {
                obrshifr = Convert.ToUInt64(obrstr);
                BigInteger obrshifr1 = BigInteger.ModPow(obrshifr, e, n);
                rsa += obrshifr1;
            }

            return rsa;
        }*/
    }
}

