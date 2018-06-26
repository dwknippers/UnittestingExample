using System;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorUnitTests
{
	[TestClass]
	public class CalculatorClassTest
	{
		[TestMethod]
		public void calculate_Add_Valid()
		{
			Assert.IsTrue(CalculatorClass.Calculate(1, -1, CalculatorClass.CalculationType.Add) == 0);
		}

		[TestMethod]
		public void calculate_Divide_Valid()
		{
			Assert.IsTrue(CalculatorClass.Calculate(2, 2, CalculatorClass.CalculationType.Divide) == 1);
		}
		[TestMethod]
		public void calculate_Multiply_Valid()
		{
			Assert.IsTrue(CalculatorClass.Calculate(2, 6, CalculatorClass.CalculationType.Multiply) == 12);
		}

		[TestMethod]
		public void calculate_calculationtype_Invalid()
		{
			Assert.ThrowsException<ArgumentException>(() => { CalculatorClass.Calculate(1, 1, null); });
		}
	}
}
