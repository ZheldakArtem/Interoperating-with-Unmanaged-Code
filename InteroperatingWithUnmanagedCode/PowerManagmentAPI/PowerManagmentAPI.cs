using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PowerManagmentAPI
{
    public class PowerManagment
    {
		[DllImport("powrprof.dll")]
		public static extern UInt32 CallNtPowerInformation(
				int InformationLevel,
				[Out] IntPtr lpInputBuffer,
				uint nInputBufferSize,
				out ulong lpOutputBuffer,
				int nOutputBufferSize
			);

		[DllImport("powrprof.dll")]
		public static extern UInt32 CallNtPowerInformation(
				int InformationLevel,
				IntPtr lpInputBuffer,
				uint nInputBufferSize,
				out SYSTEM_BATTERY_STATE lpOutputBuffer,
				int nOutputBufferSize
			);

		[DllImport("powrprof.dll")]
		public static extern uint CallNtPowerInformation(
				int InformationLevel,
				IntPtr lpInputBuffer,
				int nInputBufferSize,
				out SYSTEM_POWER_INFORMATION spi,
				int nOutputBufferSize
			);


		[DllImport ("powrprof.dll", SetLastError = true)]
		public static extern bool SetSuspendState (bool hibernate, bool forceCritical, bool disableWakeEvent);

	}

}

