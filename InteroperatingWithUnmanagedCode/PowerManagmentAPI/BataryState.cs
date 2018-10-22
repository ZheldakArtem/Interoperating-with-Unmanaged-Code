using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerManagmentAPI
{
	/// <summary>
	/// 
	/// </summary>
	public struct SYSTEM_BATTERY_STATE
	{
		public byte AcOnLine;
		public byte BatteryPresent;
		public byte Charging;
		public byte Discharging;
		public byte spare1;
		public byte spare2;
		public byte spare3;
		public byte spare4;
		public UInt32 MaxCapacity;
		public UInt32 RemainingCapacity;
		public Int32 Rate;
		public UInt32 EstimatedTime;
		public UInt32 DefaultAlert1;
		public UInt32 DefaultAlert2;
	}
}
