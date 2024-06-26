﻿//#define CALC_1
#define CALC_2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
	class Program
	{
		static string expression;
		static void Main(string[] args)
		{
#if CALC_1
			Console.Write("Введите простое арифметическое выражение: ");
			string expression = Console.ReadLine();
			expression = expression.Replace(',', '.');
			Console.WriteLine(expression);
			String[] numbers = expression.Split('+', '-', '*', '/');
			//for (int i = 0; i < numbers.Length; i++)Console.Write(numbers[i] + "\t");
			double a = Convert.ToDouble(numbers[0]);
			double b = Convert.ToDouble(numbers[1]);
			char s = expression[expression.IndexOfAny(new char[] { '+', '-', '*', '/' })];
			Console.WriteLine(a);
			Console.WriteLine(b);
			Console.WriteLine(s);
			switch (s)
			{
				case '+': Console.WriteLine($"{a} + {b} = {a + b}"); break;
				case '-': Console.WriteLine($"{a} - {b} = {a - b}"); break;
				case '*': Console.WriteLine($"{a} * {b} = {a * b}"); break;
				case '/': Console.WriteLine($"{a} / {b} = {a / b}"); break;
			} 
#endif
			bool correct = true;
			//do
			//{
				//Console.Write("Введите арифметические выражение: ");
				//string expression = Console.ReadLine();
				//string expression = "22 * 33 / 44 * 55 / 5";				
				expression = "(22 + 33 * (44 + 55 ))/ 5";

				Console.WriteLine("Result: " + Browse(expression));
				Console.WriteLine("Result: " + Calculate(expression));
			//} while (!correct);


			//Main(args);	//Рекурсивный вызов функции Main(), при завершении программы она заново звпускается.
		}
		static string Browse(string expression)
		{
			expression = expression.Replace(" ", "");
			for (int i = 0; i < expression.Length; i++)
			{
				if (expression[i] == '(')
				{
					for (int j = i + 1; j < expression.Length; j++)
					{
						if (expression[j] == '(')
						{
							string buffer = expression.Substring(j + 1, expression.Length - j - 1);
							Browse(buffer);
						}
						if (expression[j] == ')')
						{
							//string s_subexpr = (expression.Substring(i,j-i));
							//double result = Calculate(s_subexpr.Substring(1, s_subexpr.Length-2));
							//expression = expression.Replace(s_subexpr, result.ToString());
							string s_subexpr = expression.Substring(i + 1, j - i - 1);
							if (!s_subexpr.Contains('(')&&!s_subexpr.Contains(')'))
							{
								double result = Calculate(s_subexpr);
								Program.expression = expression.Replace($"({s_subexpr})", result.ToString());
							}
							Browse(Program.expression);							
							//break;
						}						
					}
				}
				if (expression[i] == ')')
				{
					string s_subexpr = expression.Substring(0, i);
					if (!s_subexpr.Contains('(') && !s_subexpr.Contains(')'))
					{
						double result = Calculate(s_subexpr);
						Program.expression = expression.Replace($"({s_subexpr})", result.ToString());
						
					}
					//Browse(Program.expression);
				}
			}
			return expression;
		}
	

	static double Calculate(string expression)
	{
		expression = expression.Replace(" ", "");
		Console.WriteLine(expression);
		string s_operations = "+-*/";
		String[] s_numbers = expression.Split(s_operations.ToCharArray());
		s_numbers = s_numbers.Where(item => item != "").ToArray();
		double[] d_numbers = new double[s_numbers.Length];
		for (int i = 0; i < s_numbers.Length; i++)
		{
			d_numbers[i] = Convert.ToDouble(s_numbers[i]);
			//Console.Write(d_numbers[i] + "\t");
		}
		//Console.WriteLine();
		char[] c_operations = expression.Where(item => s_operations.Contains(item)).ToArray();
		//for (int i = 0; i < c_operations.Length; i++)
		//{
		//	Console.Write(c_operations[i] + "\t");
		//}
		//Console.WriteLine();

		if (d_numbers.Length != c_operations.Length + 1)
		{
			throw new Exception("Выражение некорректно");
		}


		for (int i = 0; i < c_operations.Length; i++)
		{
			//if (c_operations[0] == '\0')
			//{
			//	break;
			//}
			//if (c_operations[1] == '\0')
			//{
			//	i = 0;
			//}
			while (c_operations[i] == '*' || c_operations[i] == '/')
			{

				if (c_operations[i] == '*') d_numbers[i] *= d_numbers[i + 1];
				if (c_operations[i] == '/') d_numbers[i] /= d_numbers[i + 1];
				for (int j = i + 1; j < d_numbers.Length - 1; j++) d_numbers[j] = d_numbers[j + 1];
				for (int j = i; j < c_operations.Length - 1; j++) c_operations[j] = c_operations[j + 1];
				d_numbers[d_numbers.Length - 1] = 0;
				c_operations[c_operations.Length - 1] = '\0';
			}
		}
		for (int i = 0; i < c_operations.Length; i++)
		{
			if (c_operations[0] == '\0')
			{
				break;
			}
			//if (c_operations[1] == '\0')
			//{
			//	i = 0;
			//}
			while (c_operations[i] == '+' || c_operations[i] == '-')
			{
				if (c_operations[i] == '+') d_numbers[i] += d_numbers[i + 1];
				if (c_operations[i] == '-') d_numbers[i] -= d_numbers[i + 1];
				for (int j = i + 1; j < d_numbers.Length - 1; j++) d_numbers[j] = d_numbers[j + 1];
				for (int j = i; j < c_operations.Length - 1; j++) c_operations[j] = c_operations[j + 1];
				d_numbers[d_numbers.Length - 1] = 0;
				c_operations[c_operations.Length - 1] = '\0';
			}
		}

		//for (int i = 0; i < d_numbers.Length; i++)
		//{
		//	Console.Write(d_numbers[i] + "\t");
		//}
		//Console.WriteLine();
		//for (int i = 0; i < c_operations.Length; i++)
		//{
		//	Console.Write(c_operations[i] + "\t");
		//}
		//Console.WriteLine();
		return d_numbers[0];
	}
}
}

