using System;

namespace Falsi2
{
    class Program
       
    {        
        public static int s;
        static int[] step;
        static double[] power;
        public static double a;
        public static double b;
        static double Function(double v)
        {            
            double p = 1;
            double f = step[0];
            power = new double[s];
            for (int i = 0; i <= s - 1; i++)
            {
                p = v * p;
                power[i] = p;
            }

            for (int j = 1; j <= s; j++)
            {
                f = step[j] * power[j - 1] + f;
            }
            return f;
        }
        static double Falsi()
        {
            double n = 1;
            double x = 1;
            double xk = (a * Function(a) - b * Function(b)) / (Function(b) - Function(a));
            if (Function(xk) == 0)
            {
                Console.WriteLine("Miejsce zerowe przechodzi przez x= " + a);
            }
            else
            {                
                for (double m = a; m <= b || Function(m)<0  ; m = m + 0.001)
                {
                    xk = (m * Function(m) - b * Function(m)) / (Function(b) - Function(m));

                    if (Math.Abs(xk) < n)
                    {
                        n = xk;
                        x = m;
                    }
                }                                
            }
            return x;            
        }
        static double Secant()
        {
            double x = 1;
            double x0 = a;
            double x1 = b;
            double xk1 = -1 * ((x1 - x0 )/ (Function(x1) - Function(x0)));
            int i = 0;
            while (Function(xk1) != 0 && i < 60 || Math.Abs(x0-x1)> 0.0000000001 && i < 60 )
            {
                x0 = x1;
                x1 = xk1;
                xk1 = -1 * ((x1 - x0) / (Function(x1) - Function(x0)));                
                
                if (Math.Abs(Function(xk1)) < x)
                {

                    x = xk1;
                }

                i++;
            }

            return x;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Popdaj stopien wielomianu");
            s = Convert.ToInt32(Console.ReadLine());
            step = new int[s + 1];
            if (s<2)
            {
                Console.WriteLine("Funkcja musi byc nieliniowa!");
            }
            Console.WriteLine("Podaj wartosc wspolczynnikow funkcji, wypisz od najmniejszej potegi do najwiekszej");
            for(int k=0;k<=s;k++ )
            {
                step[k] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Podaj poczatek przedzialu a");
            a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Podaj koniec przedzialu b");
            b = Convert.ToDouble(Console.ReadLine());
            
            if (Function(a) * Function(b) > 0)
            {
                Console.WriteLine("Poczatek i koniec przedzialu musza miec przeciwne znaki");               
            }
            else
            {
                Console.WriteLine("Wybierz metode obliczen: falsi czy sieczna");
                string z=Console.ReadLine();
                if (z == "falsi")
                {
                    Falsi();
                    if (Math.Round(Function(Falsi()), 2) == 0)
                    {
                        Console.WriteLine("Miejsce zerowe przechodzi przez x= {0:N2}", Falsi());
                    }
                    else
                    {
                        Console.WriteLine("Nie udalo się znaleźć miejsca zerowego w danym przedziale");
                        Console.WriteLine(Falsi());
                    }
                }
                else if (z=="sieczna")
                {
                    Secant();
                    if (Math.Round(Function(Secant()), 2) == 0)
                    {
                        Console.WriteLine("Miejsce zerowe przechodzi przez x= {0:N2}", Secant());
                    }
                    else
                    {
                        Console.WriteLine("Nie udalo się znaleźć miejsca zerowego w danym przedziale");
                    }
                }
                else
                {
                    Console.WriteLine("Wybierz poprawna metode");
                }


            }
            
        }
    }
}
