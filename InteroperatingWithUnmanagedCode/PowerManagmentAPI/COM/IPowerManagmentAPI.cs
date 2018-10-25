using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PowerManagmentAPI.COM
{
	[ComVisible(true)]
	[Guid("EDA6A34D-BAC2-46C8-8265-C4E795C0B272")]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IPowerManagmentAPI
	{
		void LastSleepTime();

		void LastWakeTime();

		void SystemBaterryState();

		void SystemPowerInformation();
	}
}
