using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchHiddenException
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Program will raise and handle exception.");
			var pid = Process.GetCurrentProcess().Id;
			var processorArchticture = ProcessorArchticture();
			Console.WriteLine($"PID {pid}, {processorArchticture}\n");

			ConsoleKeyInfo key = default (ConsoleKeyInfo);
			do
			{
				key = Console.ReadKey(true);

				if (key.Key != ConsoleKey.Escape)
				{
					RaiseAndHandleException();
				}
			} while (key.Key != ConsoleKey.Escape);

			Console.WriteLine("Good bye!");
		}

		private static void RaiseAndHandleException()
		{
			try
			{
				int a = 0;
				int b = 42/a;
			}
			catch
			{
				Console.WriteLine("Exception handled");
			}
		}

		private static string ProcessorArchticture()
		{
			return IntPtr.Size == 8 ? "x64" : "x86";
		}
	}
}
