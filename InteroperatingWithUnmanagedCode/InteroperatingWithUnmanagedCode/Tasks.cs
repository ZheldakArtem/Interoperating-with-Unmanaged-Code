using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerManagmentAPI;

namespace InteroperatingWithUnmanagedCode
{
	[TestClass]
	public class Tasks
	{
	


		// Last last wake time
		[TestMethod]
		public void TestLastWakeTime()
		{
			ulong lpOutputBuffer = 0;

			uint retval = PowerManagment.CallNtPowerInformation(
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

			uint retval = PowerManagment.CallNtPowerInformation(
					(int)POWER_INFORMATION_LEVEL.LastSleepTime,
					IntPtr.Zero,
					0,
					out lpOutputBuffer,
					Marshal.SizeOf<ulong>()
				);

			var status = (NET_API_STATUS)Enum.Parse(typeof(NET_API_STATUS), retval.ToString());

			if (status == NET_API_STATUS.NERR_Success)
			{
				Console.WriteLine("Success");
				Console.WriteLine($" Last Sleep Time { lpOutputBuffer / 10000000 / 60} min");
			}

		}

		[TestMethod]
		public void TestcSystemBatteryState()
		{
			SYSTEM_BATTERY_STATE batteryStatesStruct;

			uint retval = PowerManagment.CallNtPowerInformation(
					(int)POWER_INFORMATION_LEVEL.SystemBatteryState,
					IntPtr.Zero,
					0,
					out batteryStatesStruct,
					Marshal.SizeOf<SYSTEM_BATTERY_STATE>()
				);

			var status = (NET_API_STATUS)Enum.Parse(typeof(NET_API_STATUS), retval.ToString());

			if (status == NET_API_STATUS.NERR_Success)
			{
				Console.WriteLine("Success");
				Console.WriteLine($"AcOnLine: {batteryStatesStruct.AcOnLine}");
				Console.WriteLine($"BatteryPresent: {batteryStatesStruct.BatteryPresent}");
				Console.WriteLine($"Charging: {batteryStatesStruct.Charging}");
				Console.WriteLine($"DefaultAlert1: {batteryStatesStruct.DefaultAlert1}");
				Console.WriteLine($"DefaultAlert2: {batteryStatesStruct.DefaultAlert2}");
				Console.WriteLine($"Discharging: {batteryStatesStruct.Discharging}");
				Console.WriteLine($"EstimateTime: {batteryStatesStruct.EstimatedTime}");
				Console.WriteLine($"MaxCapacity: {batteryStatesStruct.MaxCapacity}");
				Console.WriteLine($"Rate: {batteryStatesStruct.Rate}");
				Console.WriteLine($"RemainingCapacity: {batteryStatesStruct.RemainingCapacity}");
				Console.WriteLine($"Spare1: {batteryStatesStruct.spare1}");
				Console.WriteLine($"Spare2: {batteryStatesStruct.spare2}");
				Console.WriteLine($"Spare3: {batteryStatesStruct.spare3}");
				Console.WriteLine($"Spare4: {batteryStatesStruct.spare4}");
			}

		}
	}
}
