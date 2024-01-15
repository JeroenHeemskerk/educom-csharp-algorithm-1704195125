using System;
using System.Collections.Generic;

namespace Organizer
{
	public class ShiftHighestSort
    {
        private List<int> array = new List<int>();
        public List<int> ShiftSort(List<int> input)
        {
            array = new List<int>(input);
            ShiftSortFunction(0, array.Count - 1);
            return array;
        }

        private void ShiftSortFunction(int low, int high)
        {
            int i, j;
            for (i = low; i<= high; i++)
            {
                for (j = low; j<= high - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }    
    }
}
