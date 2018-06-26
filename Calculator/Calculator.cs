using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	/// <summary>
	/// Class encompassing functions required for a basic calculator
	/// </summary>
	public static class CalculatorClass
	{
		/// <summary>
		/// Refers to a type of calculation
		/// </summary>
		public enum CalculationType { Add, Subtract, Divide, Multiply }

		/// <summary>
		/// Calculates a result using given numbers a and b according to the given calculation type.
		/// </summary>
		/// <param name="a">The first argument.</param>
		/// <param name="b">The second argument.</param>
		/// <param name="calculationType">The calculation type to perform. For example Add, Subtract.</param>
		/// <returns>The calculated result.</returns>
		public static double Calculate(double a, double b, CalculationType? calculationType)
		{
			switch (calculationType)
			{
				case CalculationType.Add: return a + b;
				case CalculationType.Subtract: return a - b;
				case CalculationType.Divide: return a / b;
				case CalculationType.Multiply: return a * b;
				default: throw new ArgumentException("calculationType is required!");
			}
		}
	}
}
