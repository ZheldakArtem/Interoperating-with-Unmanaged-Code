using PowerManagmentAPI.COM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PowerManagmentAPI
{
	[ComVisible(true)]
	[Guid("EDA89F99-B3F7-48A0-ACE3-9FD07B93A1E5")]
	[ClassInterface(ClassInterfaceType.None)]
	public class PowerManager : IPowerManagmentAPI
	{
		/// <summary>
		/// 
		/// </summary>
		public void LastWakeTime()
		{
			ulong lpOutputBuffer = 0;
			StringBuilder sb = new StringBuilder();

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
				sb.AppendLine("Success");
				sb.AppendLine($"Last Wake Time { lpOutputBuffer / 10000000 / 60} min");
			}
			else
			{
				sb.AppendLine("Error");
			}

			NativePowerManagment.MessageBoxW(0, sb.ToString(), "Last Wake Time", 0);
		}

		/// <summary>
		/// 
		/// </summary>
		public void LastSleepTime()
		{
			ulong lpOutputBuffer = 0;
			StringBuilder sb = new StringBuilder();

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
				sb.AppendLine("Success");
				sb.AppendLine($" Last Sleep Time { lpOutputBuffer / 10000000 / 60} min");
			}
			else
			{
				sb.AppendLine("Error");
			}

			NativePowerManagment.MessageBoxW(0, sb.ToString(), "Last Sleep Time", 0);
		}

		/// <summary>
		/// 
		/// </summary>
		public void SystemBaterryState()
		{
			SYSTEM_BATTERY_STATE batteryStatesStruct;
			StringBuilder sb = new StringBuilder();

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
				sb.AppendLine("Success");
				sb.AppendLine($"AcOnLine: {batteryStatesStruct.AcOnLine}");
				sb.AppendLine($"BatteryPresent: {batteryStatesStruct.BatteryPresent}");
				sb.AppendLine($"Charging: {batteryStatesStruct.Charging}");
				sb.AppendLine($"DefaultAlert1: {batteryStatesStruct.DefaultAlert1}");
				sb.AppendLine($"DefaultAlert2: {batteryStatesStruct.DefaultAlert2}");
				sb.AppendLine($"Discharging: {batteryStatesStruct.Discharging}");
				sb.AppendLine($"EstimateTime: {batteryStatesStruct.EstimatedTime}");
				sb.AppendLine($"MaxCapacity: {batteryStatesStruct.MaxCapacity}");
				sb.AppendLine($"Rate: {batteryStatesStruct.Rate}");
				sb.AppendLine($"RemainingCapacity: {batteryStatesStruct.RemainingCapacity}");
				sb.AppendLine($"Spare1: {batteryStatesStruct.spare1}");
				sb.AppendLine($"Spare2: {batteryStatesStruct.spare2}");
				sb.AppendLine($"Spare3: {batteryStatesStruct.spare3}");
				sb.AppendLine($"Spare4: {batteryStatesStruct.spare4}");
			}
			else
			{
				sb.AppendLine("Error");
			}
			NativePowerManagment.MessageBoxW(0, sb.ToString(), "System Baterry State", 0);
		}

		/// <summary>
		/// 
		/// </summary>
		public void SystemPowerInformation()
		{
			SYSTEM_POWER_INFORMATION spi;
			StringBuilder sb = new StringBuilder();

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
				sb.AppendLine($"TimeRemaining: {spi.TimeRemaining}");
				sb.AppendLine($"CoolingMode: {spi.CoolingMode}");
				sb.AppendLine($"Idleness: {spi.Idleness}");
				sb.AppendLine($"MaxIdlenessAllowed: {spi.MaxIdlenessAllowed}");
			}
			else
			{
				sb.AppendLine("Error");
			}

			NativePowerManagment.MessageBoxW(0, sb.ToString(), "System Power Information", 0);
		}
	}
}
