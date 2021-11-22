using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jacoby_seidel
{
    class Program
    {
        static double[,] mtx = { { 8.2, 0.037, 0.0451, 0.0532 }, { 0.234, 7.3, 0.0396, 0.0477 }, { 0.0179, 0.0260, 6.4, 0.0422 }, { 0.0124, 0.0205, 0.0286, 5.5 } };
        static double[] b = { 7.5591, 8.1741, 8.4281, 8.3210 };
        static int size = b.Length;
        static double[] x = { 0, 0, 0, 0 };
        static double eps = 0.001;

        static void Main(string[] args)
        {
            while (true)
            {
                switch (Menu())
                {
                    case 1: 
                    {
                        JacobiMethod.Jacobi();
                        Check();
                        break;
                    }
                    case 2:
                    {
                        SeidelMethod.Seidel();
                            Check();
                            break;
                    }
                    case 0: {
                            return;
                        }
                    default: {
                            Console.WriteLine("Retry input");
                            break;
                        }
                }
                
                
            }
        }

        public static int Menu() {
            Console.WriteLine("1 - Jacobi Method\n"+
                "2 - Seidel Method\n\n"+"0 - Exit");
            return int.Parse(Console.ReadLine());
        }

        public static void Check(){
            Console.WriteLine("Check");
            double[] c = { 0, 0, 0, 0 }; 
           for(int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    c[i] += mtx[i, j] * x[i];
                }
                Console.WriteLine("{0} = {1}", c[i], b[i]);
           }
            Console.WriteLine();
        }

        public class SeidelMethod {
            public static void Seidel()
            {
                Output.OutMtx(mtx, b);
                Iteration();
                Output.OutXs(x);
            }
            public static void Iteration()
            {
                while (true)
                {
                    double[] c = new double[size];
                    for (int i = 0; i < size; i++)
                    {
                        c[i] = b[i];

                    }
                    int count = 0;
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            if (i == j) { }
                            else
                            {
                                c[i] -= mtx[i, j] * x[i];
                            }                            
                        }
                        c[i] /= mtx[i, i];
                        if (Math.Abs(c[i] - x[i]) < eps)
                            count++;
                        x[i] = c[i];
                    }                                    
                    
                    if (count == size)
                    {                        
                        break;
                    }
                   
                }
            }
        }
        public class JacobiMethod
        {
            public static void Jacobi() {
                Output.OutMtx(mtx,b);
                Iteration();
                Output.OutXs(x);
            }
            public static void Iteration()
            {
                while (true)
                {
                double[] c = new double[size];
                for (int i = 0; i < size; i++) {
                    c[i] = b[i];
                    
                }               
                    for (int i = 0; i < size; i++) {
                        for (int j = 0; j < size; j++) {
                            if (i == j) { }
                            else {
                                c[i] -= mtx[i, j] * x[i];
                                        }
                        }
                        c[i] /= mtx[i, i];
                    }
                    
                    int count = 0;
                    for (int i = 0; i < size; i++) {
                        if (Math.Abs(c[i] - x[i]) < eps)
                            count++;
                    }
                    if(count == size)
                    {
                        for (int i = 0; i < size; i++)
                        {
                            x[i] = c[i];
                        }
                        break;
                    }
                    else {
                        for (int i = 0; i < size; i++)
                        {
                            x[i] = c[i];
                        }
                    }
                }
            }

        }
        public class Output
        {
            public static void OutXs(double[] arr) {
                for(int i = 0; i<arr.Length;i++) {
                    Console.WriteLine("x[{0}] = {1}",i+1,arr[i]);
                }
                Console.WriteLine();
            }
                      
            public static void OutMtx(double [,] arr, double[] elem)
            {
                for (int i = 0; i < size; i++) {
                    for (int j = 0; j < size; j++) {
                        Console.Write(arr[i, j] + "\t");
                    }
                    Console.Write("||{0} \n",elem[i]);
                }
                Console.WriteLine();
            }
            

        }

        
    }
}
