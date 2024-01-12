using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Organizer
{
	public class RotatePivotSort<T>
	{

        private List<T> array;
        private IComparer<T> Comparer;  

        public List<T> RotateSort(List<T> input, IComparer<T> comparer)
        {
            array = new List<T>(input);
            Comparer = comparer;
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
            T pivot = array[high];
            int splitPoint = low - 1;
            for (int i = low; i < high; i++)
            {
                if (Comparer.Compare(array[i], pivot) <= 0)
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
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}