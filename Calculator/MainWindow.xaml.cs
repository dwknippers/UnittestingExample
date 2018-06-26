using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Calculator.CalculatorClass;

namespace Calculator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private string[] inputs = new string[2];
		private CalculationType? calculationTypeChosen;
		private bool showingResult = true;
		private CultureInfo cultureInfo = new CultureInfo("en-US");

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string content = (string)(sender is Button ? ((Button)sender).Content : sender);
			switch(content)
			{
				case "+": calculationTypeChosen = CalculationType.Add; break;
				case "-": calculationTypeChosen = CalculationType.Subtract; break;
				case "/": calculationTypeChosen = CalculationType.Divide; break;
				case "x": calculationTypeChosen = CalculationType.Multiply; break;
				case "c":
					inputs = new string[2];
					calculationTypeChosen = null;
					showingResult = false;
					InputDisplay.Content = "";
					break;
				case "=":
					if (calculationTypeChosen == null) return;
					InputDisplay.Content = CalculatorClass.Calculate(Convert.ToDouble(inputs[0], cultureInfo), Convert.ToDouble(inputs[1], cultureInfo), calculationTypeChosen);
					showingResult = true;
					break;
				default:
					if (showingResult) Button_Click("c", new RoutedEventArgs());
					inputs[calculationTypeChosen != null ? 1 : 0] += content;
					InputDisplay.Content = inputs[calculationTypeChosen != null ? 1 : 0];
					break;
			}
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			switch(e.Key)
			{
				case Key.Add: Button_Click("+", new RoutedEventArgs()); break;
				case Key.Subtract: Button_Click("-", new RoutedEventArgs()); break;
				case Key.Divide: Button_Click("/", new RoutedEventArgs()); break;
				case Key.Multiply: Button_Click("x", new RoutedEventArgs()); break;
				case Key.Return: Button_Click("=", new RoutedEventArgs()); break;
				case Key.NumPad0:
				case Key.NumPad1:
				case Key.NumPad2:
				case Key.NumPad3:
				case Key.NumPad4:
				case Key.NumPad5:
				case Key.NumPad6:
				case Key.NumPad7:
				case Key.NumPad8:
				case Key.NumPad9:
					Button_Click(e.Key.ToString().Substring(6), new RoutedEventArgs());
					break;
				case Key.Decimal: Button_Click(".", new RoutedEventArgs()); break;
			}
		}
	}
}
