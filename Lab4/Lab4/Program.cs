using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Owner
    {

        static int id;
        int ID;
        string name;
        string organization;

        public Owner()
        {
            id++;
            ID = id;
        }

        public Owner(string name, string organization) : this()
        {
            this.name = name;
            this.organization = organization;
        }

        public void OwnerInfo()
        {
            Console.WriteLine(ID);
            Console.WriteLine(name);
            Console.WriteLine(organization);
        }
    }
    public class Matrix
    {
        Owner me = new Owner("Lenya", "Lenya corp.");

        class Date
        {
            public DateTime date = new DateTime();

            public Date()
            {
                date = DateTime.Now;
            }
        }

        Date date = new Date();

        public int[,] myArr = new int[3, 3];

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            Matrix plusResult = new Matrix();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    plusResult.myArr[i, j] = matrix1.myArr[i, j] + matrix2.myArr[i, j];
                }
            }
            return plusResult;
        }

        public static Matrix operator -(Matrix matrix, int q)
        {
            q--;
            int i = q;
            for (int j = 0; j < 3; j++)
            {
                matrix.myArr[i, j] = 0;
            }
            return matrix;
        }

        public static bool operator <(Matrix matrix1, Matrix matrix2)
        {
            bool boolResult = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Math.Abs(matrix1.myArr[i, j]) > Math.Abs(matrix2.myArr[i, j]))
                    {
                        boolResult = false;
                        break;
                    }

                }
            }
            return boolResult;
        }

        public static bool operator >(Matrix matrix1, Matrix matrix2)
        {
            bool boolResult = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Math.Abs(matrix1.myArr[i, j]) < Math.Abs(matrix2.myArr[i, j]))
                    {
                        boolResult = false;
                        break;
                    }

                }
            }
            return boolResult;
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix1.myArr[i, j] = matrix2.myArr[i, j];
                }
            }
            return matrix2;
        }

        public void matrixCreation()
        {
            Random rand = new Random();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    myArr[i, j] = rand.Next(100);
                }
            }
        }

        public void info()
        {
            Console.WriteLine(date.date);
            me.OwnerInfo();
        }

        public void show()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("{0}\t", myArr[i, j]);
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("\n");
        }
    }
    public static class MathOperation
    {
        public static int Max(this Matrix matrix)
        {
            int maxElem = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (maxElem < matrix.myArr[i, j])
                    {
                        maxElem = matrix.myArr[i, j];
                    }
                }
                Console.WriteLine("\n");
            }
            return maxElem;
        }

        public static int Min(this Matrix matrix)
        {
            int minElem = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (minElem > matrix.myArr[i, j])
                    {
                        minElem = matrix.myArr[i, j];
                    }
                }
                Console.WriteLine("\n");
            }
            return minElem;
        }

        public static int NumberOfElements(this Matrix matrix)
        {
            int numberOfElements = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    numberOfElements++;
                }
                Console.WriteLine("\n");
            }
            return numberOfElements;
        }

        public static int Sum(this Matrix matrix)
        {
            int sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += matrix.myArr[i, i];
                Console.WriteLine("\n");
            }
            return sum;
        }

        public static void FindNum(this Matrix matrix, int findThisNum)
        {
            int num = findThisNum;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (num == matrix.myArr[i, j])
                    {
                        Console.WriteLine("Число найдено");
                    }
                }
                Console.WriteLine("\n");
            }


        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Matrix matr1 = new Matrix();
            Matrix matr2 = new Matrix();
            Matrix result = new Matrix();

            matr1.info();

            matr1.matrixCreation();
            matr2.matrixCreation();

            matr1.show();
            matr2.show();

            result = matr1 + matr2;
            Console.WriteLine("Сложение матриц : ");
            result.show();

            Console.WriteLine("Убираем 1 строку");
            result = matr1 - 1;

            result.show();

            Console.WriteLine("Максимальное число : " + result.Max());
            Console.WriteLine("Минимальное число : " + result.Min());
            Console.WriteLine("Сумма главной диагонали : " + result.Sum());
            Console.WriteLine("Количество элементов : " + result.NumberOfElements());
            Console.WriteLine("\n");
            Console.Write("\nВведите номер: ");
            int num = int.Parse(Console.ReadLine());
            result.FindNum(num);
        }
    }
}

