using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerManagmentAPI;

namespace InteroperatingWithUnmanagedCode
{
	[TestClass]
	public class Tasks
	{
		/// <summary>
		/// 1.a. LastSleepTime
		/// </summary>
		[TestMethod]
		public void TestLastWakeTime()
		{
			ulong lpOutputBuffer = 0;

			uint retval = NativePowerManagment.CallNtPowerInformation(
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
			else
			{
				Console.WriteLine("Error");
			}
		}

		/// <summary>
		/// 1.b. LastWakeTime
		/// </summary>
		[TestMethod]
		public void TestLastSleepTime()
		{
			ulong lpOutputBuffer = 0;

			uint retval = NativePowerManagment.CallNtPowerInformation(
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
			else
			{
				Console.WriteLine("Error");
			}

		}

		/// <summary>
		/// 1.c. SystemBatteryState 
		/// </summary>
		[TestMethod]
		public void TestcSystemBatteryState()
		{
			SYSTEM_BATTERY_STATE batteryStatesStruct;

			uint retval = NativePowerManagment.CallNtPowerInformation(
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
			else
			{
				Console.WriteLine("Error");
			}

		}

		/// <summary>
		/// 1.d. SystemPowerInformation
		/// </summary>
		[TestMethod]
		public void TestSystemPowerInformation()
		{
			SYSTEM_POWER_INFORMATION spi;

			uint retval = NativePowerManagment.CallNtPowerInformation(
				(int)POWER_INFORMATION_LEVEL.SystemPowerInformation,
				IntPtr.Zero,
				0,
				out spi,
				Marshal.SizeOf(typeof(SYSTEM_POWER_INFORMATION))
			);

			var status = (NET_API_STATUS)Enum.Parse(typeof(NET_API_STATUS), retval.ToString());

			if (status == NET_API_STATUS.NERR_Success)
			{
				Console.WriteLine($"TimeRemaining: {spi.TimeRemaining}");
				Console.WriteLine($"CoolingMode: {spi.CoolingMode}");
				Console.WriteLine($"Idleness: {spi.Idleness}");
				Console.WriteLine($"MaxIdlenessAllowed: {spi.MaxIdlenessAllowed}");
			}
			else
			{
				Console.WriteLine("Error");
			}
		}

		/// <summary>
		/// 2.1 Reserve and delete hibernation file 
		/// </summary>
		[TestMethod]
		public void TestReserveHibernationFile()
		{
			ulong outBuffer;

			int size = Marshal.SizeOf(typeof(Int32));

			IntPtr pBool = Marshal.AllocHGlobal(size);
			Marshal.WriteInt32(pBool, 0, 1);  // last parameter 0 (FALSE), 1 (TRUE)

			uint retval = NativePowerManagment.CallNtPowerInformation(
				(int)POWER_INFORMATION_LEVEL.SystemReserveHiberFile,
				pBool,
				(uint)Marshal.SizeOf(typeof(IntPtr)),
				out outBuffer,
				0
			);

			Marshal.FreeHGlobal(pBool);

			var status = (NET_API_STATUS)Enum.Parse(typeof(NET_API_STATUS), retval.ToString());

			if (status == NET_API_STATUS.NERR_Success)
			{
				Console.WriteLine("Success");
				Console.WriteLine("Hibernation file is reserved");
			}
			else
			{
				Console.WriteLine("Error");
			}
		}

		/// <summary>
		/// 2.2 Delete and delete hibernation file 
		/// </summary>
		[TestMethod]
		public void TestDeleteHibernationFile()
		{
			ulong outBuffer;

			int size = Marshal.SizeOf(typeof(Int32));

			IntPtr pBool = Marshal.AllocHGlobal(size);
			Marshal.WriteInt32(pBool, 0, 0);  // last parameter 0 (FALSE), 1 (TRUE)

			uint retval = NativePowerManagment.CallNtPowerInformation(
				(int)POWER_INFORMATION_LEVEL.SystemReserveHiberFile,
				pBool,
				(uint)Marshal.SizeOf(typeof(IntPtr)),
				out outBuffer,
				0
			);

			Marshal.FreeHGlobal(pBool);

			var status = (NET_API_STATUS)Enum.Parse(typeof(NET_API_STATUS), retval.ToString());

			if (status == NET_API_STATUS.NERR_Success)
			{
				Console.WriteLine("Success");
				Console.WriteLine("Hibernation file is deleted");
			}
			else
			{
				Console.WriteLine("Error");
			}
		}

		/// <summary>
		/// 3. TestSetSuspendStateTest
		/// </summary>
		[TestMethod]
		public void TestSetSuspendStateTest()
		{
			//PowerManagment.SetSuspendState(false, false, false);   // IT WORKS!!! I've already checked :))
		}


		[TestMethod]
		public void TestMessageBox()
		{
			var t = new PowerManager();
			t.LastSleepTime();
			t.LastWakeTime();
			t.SystemBaterryState();
			t.SystemPowerInformation();
		}
	}
}
