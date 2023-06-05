using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Uebung1
{
    enum PrimeType
    {
        Prim = 1,
        NotPrim = 0
    }

    class Program
    {
        static void Main(string[] args)
        {
            int size = getUserInput();
            PrimeType[] Sieb = Eratosthenes(size);
            outputResultExerciseOne(Sieb);
            int[] resultExerciseTwo = exerciseTwo(Sieb, size);
            List<int> resultExeciseThree = exerciseThree(Sieb, size);
            Dictionary<int, int> resultExerciseFour = exerciseFour(Sieb, size);
        }

        public static PrimeType[] Eratosthenes(int size)
        {
            PrimeType[] Sieb = initaliseSieb(size);
            int startnumber = 2;

            for (int i = getArrayIndexOfNumber(startnumber); Math.Pow(getNumberOfArrayIndex(i), 2) < size; i++)
            {
                if (Sieb[i] == PrimeType.Prim)
                {
                    int number = getNumberOfArrayIndex(i);
                    Sieb = setAllMulplikatedNumbersNotPrim(Sieb, number, size);
                }
            }

            return Sieb;
        }

        public static int[] exerciseTwo(PrimeType[] Sieb, int size)
        {
            System.Console.WriteLine("Aufgabe 2:");

            int startnumber = 2;
            int countPrimNumbers = 0;
            for (int i = getArrayIndexOfNumber(startnumber); i < size; i++)
            {
                if (Sieb[i] == PrimeType.Prim)
                {
                    countPrimNumbers++;
                }
            }

            int[] primNumbers = new int[countPrimNumbers];
            int indexOfArray = 0;
            for (int i = getArrayIndexOfNumber(startnumber); i < size; i++)
            {
                if (Sieb[i] == PrimeType.Prim)
                {
                    System.Console.WriteLine(indexOfArray + "->" + getNumberOfArrayIndex(i));
                    primNumbers[indexOfArray] = getNumberOfArrayIndex(i);
                    indexOfArray++;
                }
            }
            return primNumbers;
        }

        public static List<int> exerciseThree(PrimeType[] Sieb, int size)
        {
            System.Console.WriteLine("Aufgabe 3:");

            int startnumber = 2;
            List<int> primNumbers = new List<int>();
            for (int i = getArrayIndexOfNumber(startnumber); i < size; i++)
            {
                if (Sieb[i] == PrimeType.Prim)
                {
                    int number = getNumberOfArrayIndex(i);
                    primNumbers.Add(number);
                    int indexOfItem = primNumbers.IndexOf(number);
                    System.Console.WriteLine( indexOfItem + "->" + primNumbers[indexOfItem]);
                }
            }
            return primNumbers;
        }

        public static Dictionary<int, int> exerciseFour(PrimeType[] Sieb, int size)
        {
            System.Console.WriteLine("Aufgabe 4:");

            int startnumber = 2;
            Dictionary<int, int> primNumbers = new Dictionary<int, int>();
            int dictionaryIndex = 0;
            for (int i = getArrayIndexOfNumber(startnumber); i < size; i++)
            {
                if (Sieb[i] == PrimeType.Prim)
                {
                    int number = getNumberOfArrayIndex(i);
                    primNumbers.Add(dictionaryIndex, number);
                    System.Console.WriteLine(dictionaryIndex + "->" + primNumbers[dictionaryIndex]);
                    dictionaryIndex++;
                }
            }
            return primNumbers;
        }

        private static void outputResultExerciseOne(PrimeType[] Sieb)
        {
            System.Console.WriteLine("");
            System.Console.WriteLine("Aufgabe 1: ");

            int number = 1;
            foreach (PrimeType prime in Sieb)
            {
                if(number%10 == 0)
                {
                    System.Console.WriteLine(number + "->" + prime);
                } else
                {
                    System.Console.Write(number + "->" + prime + " ");
                }
                number++;
            }
        }

        private static int getUserInput() 
        {
            string userInput;
            Console.WriteLine("Wie gross ist das Sieb?");
            userInput = Console.ReadLine();
            return Int32.Parse(userInput);
        }

        private static PrimeType[] setAllMulplikatedNumbersNotPrim(PrimeType[] Sieb, int number, int size)
        {
            for(int multiplikator = 2; getArrayIndexOfNumber(multiplikator * number) < size; multiplikator++)
            {
                int notPrimeIndex = getArrayIndexOfNumber(multiplikator * number);
                Sieb[notPrimeIndex] = PrimeType.NotPrim;
            }
            return Sieb;
        }

        private static PrimeType[] initaliseSieb(int size)
        {
            PrimeType[] Sieb = new PrimeType[size];
            for (int i = 0; i < size; i++)
            {
                Sieb[i] = PrimeType.Prim;
            }
            return Sieb;
        }

        private static int getArrayIndexOfNumber(int number)
        {
            return number - 1;
        }

        private static int getNumberOfArrayIndex(int arrayIndex)
        {
            return arrayIndex + 1;
        }
    }
}
