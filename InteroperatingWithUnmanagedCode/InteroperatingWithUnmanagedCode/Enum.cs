using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteroperatingWithUnmanagedCode
{

	/// <summary>
	/// Lmcons.h
	/// #define NET_API_STATUS DWORD
	/// </summary>
	public enum NET_API_STATUS : uint
	{
		NERR_Success = 0,
		/// <summary>
		/// This computer name is invalid.
		/// </summary>
		NERR_InvalidComputer = 2351,
		/// <summary>
		/// This operation is only allowed on the primary domain controller of the domain.
		/// </summary>
		NERR_NotPrimary = 2226,
		/// <summary>
		/// This operation is not allowed on this special group.
		/// </summary>
		NERR_SpeGroupOp = 2234,
		/// <summary>
		/// This operation is not allowed on the last administrative account.
		/// </summary>
		NERR_LastAdmin = 2452,
		/// <summary>
		/// The password parameter is invalid.
		/// </summary>
		NERR_BadPassword = 2203,
		/// <summary>
		/// The password does not meet the password policy requirements. 
		/// Check the minimum password length, password complexity and password history requirements.
		/// </summary>
		NERR_PasswordTooShort = 2245,
		/// <summary>
		/// The user name could not be found.
		/// </summary>
		NERR_UserNotFound = 2221,
		ERROR_ACCESS_DENIED = 5,
		ERROR_NOT_ENOUGH_MEMORY = 8,
		ERROR_INVALID_PARAMETER = 87,
		ERROR_INVALID_NAME = 123,
		ERROR_INVALID_LEVEL = 124,
		ERROR_MORE_DATA = 234,
		ERROR_SESSION_CREDENTIAL_CONFLICT = 1219,
		/// <summary>
		/// The RPC server is not available. This error is returned if a remote computer was specified in
		/// the lpServer parameter and the RPC server is not available.
		/// </summary>
		RPC_S_SERVER_UNAVAILABLE = 2147944122, // 0x800706BA
											   /// <summary>
											   /// Remote calls are not allowed for this process. This error is returned if a remote computer was 
											   /// specified in the lpServer parameter and remote calls are not allowed for this process.
											   /// </summary>
		RPC_E_REMOTE_DISABLED = 2147549468 // 0x8001011C
	}

	/// <summary>
	/// 
	/// </summary>
	enum POWER_INFORMATION_LEVEL
	{
		SystemPowerPolicyAc = 0,
		SystemPowerPolicyDc = 1,
		VerifySystemPolicyAc = 2,
		VerifySystemPolicyDc = 3,
		SystemPowerCapabilities = 4,
		SystemBatteryState = 5,
		SystemPowerPolicyCurrent = 8,
		AdministratorPowerPolicy = 9,
		SystemReserveHiberFile = 10,
		ProcessorInformation = 11,
		SystemPowerInformation = 12,
		LastWakeTime = 14,
		LastSleepTime = 15,
		SystemExecutionState = 16,
		ProcessorPowerPolicyAc = 18,
		ProcessorPowerPolicyDc = 19,
		VerifyProcessorPowerPolicyDc = 21,
		ProcessorPowerPolicyCurrent = 22
	}

}
