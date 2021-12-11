using System;
using System.Linq;

namespace Tema3
{
    class Program
    {
        static void Main(string[] args)
        {
            int poz = 0;
            int nbToWorkWIth;
            int[] arr, arr2;
            int[,] matrix1, matrix2;


            Console.WriteLine("1. Write a method to create an array of 5 integers and display the array items. Access individual elements and display them through indexes.");
            arr = CreateArray(5);
            DisplayArray(arr);
            Console.WriteLine();

            Console.WriteLine("2. Write a method to reverse the order of the items in the array.");
            DisplayArray(ReverseArray(arr));
            Console.WriteLine();

            Console.WriteLine("3. Write a method to get the number of occurrences of a specified element in an array");
            Console.WriteLine("Numarul de aparitii este: {0}", CountElement(arr, GetSearchedElement()));
            Console.WriteLine();

            Console.WriteLine("4. Write a method to insert a new item before the second element in an existing array");
            nbToWorkWIth = GetElementToInsert();
            DisplayArray(InsertArrayElemenet(arr, poz, nbToWorkWIth));
            Console.WriteLine();

            Console.WriteLine("5. Write a method to remove a specified item using the index from an array.");
            nbToWorkWIth = GetElementToInsert();
            DisplayArray(RemoveElement(arr, nbToWorkWIth));
            Console.WriteLine();

            Console.WriteLine("6. Write a program to find the sum of all elements of the array");
            Console.WriteLine($"Suma este: {SumArray(arr)}");
            Console.WriteLine();

            Console.WriteLine("7. Write a program to print all unique elements in an array.");
            DisplayArray(UniqueElements(arr));
            Console.WriteLine();

            Console.WriteLine("8.Write a program to merge two arrays of same size sorted in ascending order.");
            arr2 = CreateArray(5);
            DisplayArray(JoinArray(arr, arr2));
            Console.WriteLine();

            Console.WriteLine("9. Write a program to find maximum and minimum element in an array.");
            Console.WriteLine("Elementul maxim din array este: {0}", arr.Max());
            Console.WriteLine("Elementul minim din array este: {0}", arr.Min());
            Console.WriteLine();

            Console.WriteLine("10. Write a program to separate odd and even integers in separate arrays");
            SeparateOddEvenNumbers(arr);
            Console.WriteLine();

            Console.WriteLine("11. Write a program to sort elements of array in ascending order.");
            Array.Sort(arr);
            DisplayArray(arr);
            Console.WriteLine();

            Console.WriteLine("12. Write a program to sort elements of the array in descending order.");
            Array.Sort(arr);
            Array.Reverse(arr);
            DisplayArray(arr);
            Console.WriteLine();

            Console.WriteLine("13. Write a program to find the second largest element in an array.");
            Console.WriteLine("The second largest element is: {0}", SecondLargestElement(arr));
            Console.WriteLine();

            Console.WriteLine("14. Write a program to find the second smallest element in an array..");
            Console.WriteLine("The second smallest element is: {0}", SecondSmallestElement(arr));
            Console.WriteLine();

            Console.WriteLine("15. Write a program for a 2D array of size 3x3 and print the matrix.");
            matrix1 = ReadMatrix(3, 3);
            PrintMatrix(matrix1);

            Console.WriteLine("16. Write a program in C# Sharp for addition of two Matrices of same size");
            matrix2 = ReadMatrix(3, 3);
            PrintMatrix(AddMatrix(matrix1, matrix2));

        }



        static int[] CreateArray(int n)
        {
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Introduceti elementul {0} al vectorului:", i);
                array[i] = int.Parse(Console.ReadLine());
            }

            return array;
        }


        static void DisplayArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Elementul [{i}] = {arr[i]}");
            }
        }

        static int GetElementToInsert()
        {
            Console.WriteLine("Introduceti elementul pe care vreti sa-l inserati/stergeti:");
            return int.Parse(Console.ReadLine());
        }
      
        static int[] ReverseArray(int[] arr)
        {
            int[] arrReversed = new int[arr.Length];

            for (int i = arr.Length-1; i >= 0; i--)
            {
                arrReversed[arr.Length - i - 1] = arr[i];
            }

            return arrReversed;
        }

        static int GetSearchedElement()
        {
            Console.WriteLine("Introduceti elementul de cautat in array:");
            return int.Parse(Console.ReadLine());
        }

        static int CountElement(int[] arr, int nbToSearch)
        {
            int count = 0;
          
            int i = Array.IndexOf(arr, nbToSearch, 0);
            while (i != -1)
            {
                count++;
                i = Array.IndexOf(arr, nbToSearch, ++i);   //nu i++ nu functioneaza corect!!!
            }

            return count;
        }


        static int[] InsertArrayElemenet(int[] arr, int poz, int nb)
        {
            //nu am inteles cerinta, inaintea celui de-al doilea element inseamna index 0, daca fac insert pe index 0, fostul element de pe indexul 0 devine index 1 si practic nu se mai respecta
            //cerinta de insert inaintea celui de-al 2-lea element...daca doar inlocuiesc valoarea elementului de pe indexul 0 cu noua valoare nu se mai cheama ca am facut insert
            //codul insereaza la o pozitie data un element nou
            int[] arrCopy = new int[arr.Length+1];

            for (int i = 0; i <= arr.Length; i++)
            {
                if (i < poz)
                {
                    arrCopy[i] = arr[i];
                }
                else
                {
                    if (i == poz)
                        arrCopy[i] = nb;
                    else
                        arrCopy[i] = arr[i-1];
                }      
            }
            return arrCopy;   
        }


        static int[] RemoveElement(int[] arr, int elem)
        {
            int nb = Array.IndexOf(arr, elem);
            Array.Clear(arr, nb, 1);
            return arr;
        }

        static int SumArray(int[] arr)
        {
            return arr.Sum();

            ////prin parcurgerea array-ului
            //int sum=0

            //for (int i = 0; i < length; i++)
            //{
            //    sum += arr[i];
            //}
            //return sum;
        }

        static int[] UniqueElements(int[] arr)
        {
            int[] uniqueArray = new int[arr.Length];
            int pos = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (Array.IndexOf(arr, arr[i]) == Array.LastIndexOf(arr, arr[i]))  //daca sunt egale inseamna ca elementul e unic
                {
                    uniqueArray[pos] = arr[i];
                    pos++;
                }
            }

            Array.Resize(ref uniqueArray, pos);
            return uniqueArray;
        }


        static int[] JoinArray(int[] arr, int[] arr2)
        {
            int[] mergedArray = new int[arr.Length+arr2.Length];

            mergedArray = arr.Concat(arr2).ToArray();

            Array.Sort(mergedArray);
            // return (int[])mergedArray;
            return mergedArray;
        }


        static void SeparateOddEvenNumbers(int[] arr)
        {
            int[] odd = new int[arr.Length];
            int[] even = new int[arr.Length];
            int j=0, k=0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]%2 ==0)
                {
                    //odd
                    odd[j] = arr[i];
                    j++;
                }
                else
                {
                    //even
                    even[k] = arr[i];
                    k++;
                }
            }

            Array.Resize(ref odd, j);
            Array.Resize(ref even, k );


            Console.WriteLine("Odd elements are: ");
            DisplayArray(odd);
            Console.WriteLine("Even elements are: ");
            DisplayArray(even);
        }

        static int SecondLargestElement(int[] arr)
        {
            Array.Sort(arr);
            return arr[arr.Length - 2];
                
        }

        static int SecondSmallestElement(int[] arr)
        {
            Array.Sort(arr);
            return arr[1];
        }


        static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.WriteLine($"Introduceti elementul [{i},{j}] al matricei:");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


        static int[,] AddMatrix(int[,] matrix1, int[,] matrix2)
        {
            //matricile au aceeasi dimensiune, deci si cea rezultata are la fel
            int[,] matrix3 = new int[matrix1.GetLength(0), matrix1.GetLength(1)];

            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    matrix3[i,j] = matrix1[i,j] + matrix2[i,j];
                }
            }
            return matrix3;
        }


    }
}
