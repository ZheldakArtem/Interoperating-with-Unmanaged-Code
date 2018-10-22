using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InteroperatingWithUnmanagedCode
{
	[TestClass]
	public class Tasks
	{
		const int ProcessorInformation = 11;

		[DllImport("powrprof.dll")]
		private static extern UInt32 CallNtPowerInformation(
					Int32 InformationLevel,
					IntPtr lpInputBuffer,
					UInt32 nInputBufferSize,
					out ulong lpOutputBuffer,
					UInt32 nOutputBufferSize
					);


		// Last last wake time
		[TestMethod]
		public void TestLastWakeTime()
		{
			ulong lpOutputBuffer = 0;

			uint retval = CallNtPowerInformation(
					(int)POWER_INFORMATION_LEVEL.LastWakeTime,
					IntPtr.Zero,
					0,
					out lpOutputBuffer,
					256
				);

			var status = (NET_API_STATUS)Enum.Parse(typeof(NET_API_STATUS), retval.ToString());

			if (status == NET_API_STATUS.NERR_Success)
			{
				Console.WriteLine("Success");
				Console.WriteLine($"Last Wake Time { lpOutputBuffer / 10000000 / 60} min");
			}

		}

		// Last last sleep time
		[TestMethod]
		public void TestLastSleepTime()
		{
			ulong lpOutputBuffer = 0;

			uint retval = CallNtPowerInformation(
					(int)POWER_INFORMATION_LEVEL.LastSleepTime,
					IntPtr.Zero,
					0,
					out lpOutputBuffer,
					256
				);

			var status = (NET_API_STATUS)Enum.Parse(typeof(NET_API_STATUS), retval.ToString());

			if (status == NET_API_STATUS.NERR_Success)
			{
				Console.WriteLine("Success");
				Console.WriteLine($" Last Sleep Time { lpOutputBuffer / 10000000 / 60} min");
			}

		}
	}
}
