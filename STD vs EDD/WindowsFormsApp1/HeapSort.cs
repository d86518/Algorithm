using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class HeapSort
    {
        private int heapSize;

        private void BuildHeap(int[] arr ,int[] arr2)
        {
            heapSize = arr.Length - 1;
            for (int i = heapSize / 2; i >= 0; i--)
            {
                Heapify(arr, i, arr2);
            }
        }

        private void Swap(int[] arr, int x, int y)//function to swap elements
        {
            int temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }
        private void Heapify(int[] arr, int index,int[] arr2)
        {
            int left = 2 * index;
            int right = 2 * index + 1;
            int largest = index;

            if (left <= heapSize && arr[left] > arr[index])
            {
                largest = left;
            }

            if (right <= heapSize && arr[right] > arr[largest])
            {
                largest = right;
            }

            if (largest != index)
            {
                Swap(arr, index, largest);
                Swap(arr2, index, largest);
                Heapify(arr, largest,arr2);
            }
        }
        public void PerformHeapSort(int[] arr,int[] arr2)
        {
            BuildHeap(arr,arr2);
            
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Swap(arr, 0, i);
                Swap(arr2, 0, i);
                heapSize--;
                Heapify(arr, 0,arr2);
            }

        }

    }
}
