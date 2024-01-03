using System;
using System.Collections.Generic;

namespace Organizer
{
	public class RotatePivotSort
	{

        private List<int> array = new List<int>();

        public List<int> RotateSort(List<int> input)
        {
            array = new List<int>(input);
            RotateSortFunction(0, array.Count - 1);
            return array;
        }

        private void RotateSortFunction(int low, int high)
        {
            if (low < high)
            {
                int splitPoint = Partitioning(low, high);
                RotateSortFunction(low, splitPoint - 1);
                RotateSortFunction(splitPoint + 1, high);
            }
        }

        private int Partitioning(int low, int high)
        {
            int pivot = array[high];
            int splitPoint = low - 1;
            for (int i = low; i < high; i++)
            {
                if (array[i] <= pivot)
                {
                    splitPoint++;
                    Swap(i, splitPoint);
                }
            }
            Swap(splitPoint + 1, high);
            return splitPoint + 1;
        }

        private void Swap(int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
