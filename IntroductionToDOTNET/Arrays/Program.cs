//#define single_dimensional_arrays
//#define multi_dimensional_arrays
#define jagged_arrays
using System;



namespace Arrays
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Random rand = new Random(0);
#if single_dimensional_arrays
			Console.Write("Введите размер массива -> ");
			int n = Convert.ToInt32(Console.ReadLine());
			int[] arr = new int[n];

		
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = rand.Next(50, 100);
			}
			//foreach (int i in arr)
			//{
			//	arr[i] = rand.Next(50, 100);
			//}
			for (int i = 0; i < arr.Length; i++)
			{
				Console.Write(arr[i] + "\t");
			}
			Console.WriteLine();

			foreach (int i in arr)
			{
				Console.Write(i + "\t");
			}
			Console.WriteLine();			
#endif

#if multi_dimensional_arrays

			int rows,cols;
            Console.Write("Введите количество строк -> ");
			rows=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Введите количество столбцов -> ");
			cols =Convert.ToInt32(Console.ReadLine());
			int[,] i_arr= new int[rows,cols];
			Console.WriteLine($"Количество измерений: {i_arr.Rank}");
			for (int i = 0; i < i_arr.GetLength(0); i++)
			{
				for (int j = 0; j < i_arr.GetLength(1); j++)
				{
					i_arr[i, j] = rand.Next(10,50);
					Console.Write(i_arr[i, j]+"\t");
				}
				Console.WriteLine();
			}
            foreach (int item in i_arr)
            {
				Console.Write(item + "\t");

			}

#endif

#if jagged_arrays
			int rows = 5;
			int[][] arr = new int[][] { new int[] { 1, 2, 3 },new int[] { 35}, new int[] { 35,33,442,341243,0 } };
			for (int i = 0; i < arr.Length; i++)
			{
				for (int j = 0; j < arr[i].Length; j++)
				{
					Console.Write(arr[i][j]+"\t");
				}
				Console.WriteLine();
			}
			
#endif

		}
	}
}
