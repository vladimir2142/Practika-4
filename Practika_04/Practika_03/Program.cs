using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika_04

{
   
    class Program
    {
        public static double Mas = 10;
        public static double last = 0;
        public static double count = 0;
        public static double Rastoinie(double x1, double y1, double x2, double y2, out double rast)
        {
            rast = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return rast;
        }
        public static double Chek(out double doub)
        {
            bool ok = false;
            do
            {
                string buf = Console.ReadLine();
                ok = double.TryParse(buf, out doub);
                if (!ok) Console.WriteLine("Нужно вводить действительные числа");


            } while (!ok);
            return doub;
        }
        public static double Create(double[,] ar, out double[,] ur)
        {
            int i = 10;
            int j = 2;
            for (i = 0; i < 10; i++)
            {
                j = 0;
                i = i + 1;
                Console.WriteLine("Введите координаты точки Х" + i.ToString());
                i = i - 1;
                ar[i, j] = Chek(out double x);
                j = j + 1;
                i = i + 1;
                Console.WriteLine("Введите координаты точки Y" + i.ToString());
                i = i - 1;
                ar[i, j] = Chek(out double y);
            }
            ur = ar;
            return i;
        }
        public static void Show(double[,] ur)
        {
            for (int i = 0; i < Mas; i++)
            {

                for (int j = 0; j < 2; j++)
                {
                    Console.Write(ur[i, j] + ";");
                }
                Console.WriteLine();
            }
        }
        public static double Perimtr(double[,] ar, out double Pirim)
        {
            
            Pirim = 0;
            double Rast = 0;
            int start = 0;
            int finish = 0;
            double[,] fa = new double[10, 2];
            for (int k = 0; k < 10; k++)
                
            {
                bool f = false;
                double min = 1000000;
                for (int i = 1; i < Mas; i++)
                {
                    Rast = Rastoinie(ar[start, 0], ar[start, 1], ar[i, 0], ar[i, 1], out double da);
                    if (Rast < min)
                    {
                        min = Rast;
                        finish = i;
                    }
                    f = true;
                }
                count++;
                start = finish - 1;
                if (min != 1000000) Pirim =Pirim+min;
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                Mas--;
                if (start == 0)
                {
                    for (int i = 0; i < Mas; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            ar[i, j] = ar[i + 1, j];
                        }
                    }
                }
                if (start != 0 && start != Mas)
                {
                    for (int i = 0; i < start; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            ar[i, j] = ar[i, j];
                        }

                    }
                    for (int i = start; i < Mas; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            ar[i, j] = ar[i + 1, j];
                        }
                    }
                }
                if (start - 1 == Mas)
                {
                    for (int i = 0; i < Mas; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            ar[i, j] = ar[i, j];
                        }
                    }
                }
            }
            Rastoinie(ar[0, 0], ar[0, 1], fa[0, 0], fa[0, 1], out double fun);
            Pirim = Pirim + fun;
            return Pirim;
        }

        static void Main(string[] args)
        {
            double[,] ar = new double[10,2];
            Create(ar, out ar);
            Show(ar);
            Perimtr(ar, out double Perim);
            Console.WriteLine(Perim);
            Console.Read();
        }

    }
}
