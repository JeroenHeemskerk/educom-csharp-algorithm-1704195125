using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Organizer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Hoeveel elementen moet de lijst bezitten? ");
            if(int.TryParse(Console.ReadLine(), out int numberOfElements))
            {
                ShiftHighestSort shiftSorter = new ShiftHighestSort();
                RotatePivotSort rotateSorter = new RotatePivotSort();

                // UnsortedList with random numbers
                Stopwatch unsortedStopwatch = Stopwatch.StartNew();
                List <int> randomNumbers = MakeList(numberOfElements);
                unsortedStopwatch.Stop();
                ShowList("Unsorted List", randomNumbers);
                Console.WriteLine($"UnsortedList Time: {unsortedStopwatch.ElapsedTicks} ticks");

                // ShiftHigestSort
                Stopwatch shiftStopwatch = Stopwatch.StartNew();
                List<int> shiftSortedNumbers = shiftSorter.ShiftSort(randomNumbers);
                shiftStopwatch.Stop();
                ShowList("Sorted List ShiftHighestSort", shiftSortedNumbers);
                bool isShiftSorted = ValidateSortedArray(shiftSortedNumbers);
                Console.WriteLine($"Is the list correctly sorted? {isShiftSorted}");    
                Console.WriteLine($"ShiftHighestSort Time: {shiftStopwatch.ElapsedTicks} ticks");

                // RotateSort
                Stopwatch rotateStopwatch = Stopwatch.StartNew();
                List<int> rotateSortedNumbers = rotateSorter.RotateSort(randomNumbers);
                rotateStopwatch.Stop();
                ShowList("Sorted List RotateSort", rotateSortedNumbers);
                bool isRotateSorted = ValidateSortedArray(rotateSortedNumbers);
                Console.WriteLine($"Is the list correctly sorted? {isRotateSorted}");
                Console.WriteLine($"RotateSort Time: {rotateStopwatch.ElapsedTicks} ticks");
            } else {
                Console.WriteLine("Je kunt alleen een positief getal invullen.");            }
        }

        public static void ShowList(string label, List<int> theList)
        {
            int count = theList.Count;
            if (count > 100)
            {
                count = 200; // Do not show more than 200 numbers
            }
            Console.WriteLine();
            Console.Write(label);
            Console.Write(':');
            for (int index = 0; index < count; index++)
            {
                if (index % 20 == 0) // when index can be divided by 20 exactly, start a new line
                {
                    Console.WriteLine();
                }
                Console.Write(string.Format("{0,3}, ", theList[index]));  // Show each number right aligned within 3 characters, with a comma and a space
            }
            Console.WriteLine();
        }

        static List<int> MakeList(int N)
        {
           List<int> numbers = new List<int>();
            var random = new Random ();
            for (int i = 0; i < N; i++) 
            {
                numbers.Add(random.Next(-99, 99));
            }
            return numbers;
        }

        static bool ValidateSortedArray(List<int> array)
        {
            for (int i = 1; i < array.Count; i++)
            {
                if (array[i] < array[i - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
