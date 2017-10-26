using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int[] temp = new int[100000];//total
        int[] DL = new int[50000];//EDD
        int[] WorkTime = new int[50000];//STD
        public Form1() { InitializeComponent();}

        string TurnStr(int[] array, int length)
        {      
            string temp = "";
            try
            {
                for (int i = 0; i < length; i++)
                {
                    temp = temp + " " + array[i];
                }
            }
            catch (Exception e) { }
            return temp;    
        }       
        private void button2_Click(object sender, EventArgs e)//STD
        {
            int[] AcArray1 = new int[temp[0]]; int[] AcArray2 = new int[temp[0]];
            int Psum = 0;int fal = 0;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < temp[0]; i++)
            {
                AcArray1[i] = WorkTime[i];
                AcArray2[i] = DL[i];
            }
            HeapSort(AcArray1);
            HeapSort(AcArray2);
            for (int i = 0; i < AcArray1.Length; i++)
            {
                if (AcArray1[i] > AcArray2[i])
                {
                    fal++;                   
                    List<int> list1 = AcArray1.ToList();
                    list1.RemoveAt(i);
                    AcArray1 = list1.ToArray();
                    List<int> list2 = AcArray2.ToList();
                    list2.RemoveAt(i);
                    AcArray2 = list2.ToArray();
                    i--;
                }

            }

            for (int i = 0; i < AcArray1.Length; i++)
            {
                HeapSort(AcArray2);
                HeapSort(AcArray1);
                for (int j = 0; j <= i; j++)
                {
                    Psum = STPSum(AcArray1, j + 1);
                    if (Psum > AcArray2[j])
                    {
                        HeapSort(AcArray1);
                        HeapSort(AcArray2);
                        fal++;                       
                        List<int> list1 = AcArray1.ToList();
                        list1.RemoveAt(i);
                        AcArray1 = list1.ToArray();

                        List<int> list2 = AcArray2.ToList();
                        list2.RemoveAt(i);
                        AcArray2 = list2.ToArray();
                        i--;
                        break;
                    }
                }
            }
            HeapSort(AcArray2);
            HeapSort(AcArray1);
            string tmparr = "";
            for (int i = 0; i < AcArray1.Length; i++)
            {
                tmparr = tmparr + "(" + " " + AcArray1[i] + "," + AcArray2[i] + ")";
            }
            listBox1.Items.Add("STD");
            listBox1.Items.Add("" + tmparr); watch.Stop();
            var ms = watch.ElapsedMilliseconds;
            listBox1.Items.Add("Running time: " + ms +" milliseconds");
            listBox1.Items.Add("Number of Tardy Jobs: "+fal); listBox1.Items.Add("");
        }
            private void button3_Click(object sender, EventArgs e)
        {
            int[] AcArray1 = new int[temp[0]];
            int[] AcArray2 = new int[temp[0]];
            int Psum = 0;
            int fal = 0;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < temp[0]; i++)
            {
                AcArray1[i] = WorkTime[i];
                AcArray2[i] = DL[i];
                //切半
            }
            HeapSort(AcArray2);
            HeapSort(AcArray1);
            for (int i = 0; i < AcArray1.Length; i++)
            {
                if (AcArray1[i] > AcArray2[i])
                {
                    fal++;
                    List<int> list1 = AcArray1.ToList();
                    list1.RemoveAt(i);
                    AcArray1 = list1.ToArray();
                    List<int> list2 = AcArray2.ToList();
                    list2.RemoveAt(i);
                    AcArray2 = list2.ToArray();
                }
            }
            for (int i = 0; i < AcArray1.Length; i++)
            {              
                Psum = STPSum(AcArray1, i + 1);
                if (Psum > AcArray2[i])
                {
                    HeapSort(AcArray1);
                    HeapSort(AcArray2);           
                    fal++;
                    List<int> list1 = AcArray1.ToList();
                    list1.RemoveAt(i);
                    AcArray1 = list1.ToArray();
                    List<int> list2 = AcArray2.ToList();
                    list2.RemoveAt(i);
                    AcArray2 = list2.ToArray();                    
                    i--;
                }
            }
            HeapSort(AcArray2);
            HeapSort(AcArray1);
            string tmparr = "";
            for (int i = 0; i < AcArray1.Length; i++)
            {
                tmparr = tmparr + "(" + " " + AcArray1[i] + "," + AcArray2[i] + ")";
            }
            listBox1.Items.Add("EDD");
            listBox1.Items.Add("" + tmparr);
            var ms = watch.ElapsedMilliseconds;
            listBox1.Items.Add("Running time: " + ms + " milliseconds");
            listBox1.Items.Add("Number of Tardy Jobs: " + fal); listBox1.Items.Add("");

        }
        private void button4_Click(object sender, EventArgs e) {listBox1.Items.Clear();}
        private void button5_Click(object sender, EventArgs e)
        {  
            string[] separators = { " " };
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(@"1000data_1.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    String text = sr.ReadToEnd();
                    Console.WriteLine(text);
                    for (int i = 0; i < text.Length; i++)
                    {
                        temp[i] = int.Parse(text.Split(separators, StringSplitOptions.RemoveEmptyEntries)[i]);
                    }
                }
            }           
            catch (Exception a)  { }
            for (int i = 0; i < temp[0]; i++)
            {
                //divide
                WorkTime[i] = temp[2*i+1];             
                DL[i] = temp[2 * i + 2];
               
            }
            string temp1=TurnStr(WorkTime, temp[0]);
            string temp2=TurnStr(DL, temp[0]);
            listBox1.Items.Add("Total amount of data: " + temp[0]);
            listBox1.Items.Add("Input data Work_time: "+temp1);
            listBox1.Items.Add("Input data Due__date: "+temp2); listBox1.Items.Add("");
        }
        public static void HeapSort(int[] input)
        {
            //Build-Max-Heap
            int heapSize = input.Length;
            for (int p = (heapSize - 1) / 2; p >= 0; p--)
                MaxHeapify(input, heapSize, p);

            for (int i = input.Length - 1; i > 0; i--)
            {
                //Swap
                int temp = input[i];
                input[i] = input[0];
                input[0] = temp;

                heapSize--;
                MaxHeapify(input, heapSize, 0);
            }
        }

        private static void MaxHeapify(int[] input, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if (left < heapSize && input[left] > input[index])
                largest = left;
            else
                largest = index;

            if (right < heapSize && input[right] > input[largest])
                largest = right;

            if (largest != index)
            {
                int temp = input[index];
                input[index] = input[largest];
                input[largest] = temp;

                MaxHeapify(input, heapSize, largest);
            }
        }

        int STPSum(int[] array, int length) {
            int sum = 0;
            for (int i = 0; i < length; i++)
            {
                sum += array[i];
            }
            return sum;
        }
        /*
        private void button6_Click(object sender, EventArgs e) //test用
        {
            string path = @"D:\\10000data_2.txt";
            // Read the file and display it line by line. 
            try {
                using (StreamReader sr = new StreamReader(path))
                {
                    //This allows you to do one Read operation.
                    Console.WriteLine(sr.ReadToEnd());
                    listBox1.Items.Add("Txt : "+sr.ReadToEnd());
                }
            }
            catch (Exception m) { }
        }
        */
    }
}
