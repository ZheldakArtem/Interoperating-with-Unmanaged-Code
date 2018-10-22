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
				IntPtr lpInputBuffer,
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

	}

}

