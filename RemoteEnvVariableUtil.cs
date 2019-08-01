using System;
using Microsoft.Win32;

namespace RegistryConsoleAppCore
{
	public class RemoteEnvVariableUtil : IDisposable
	{
		private readonly RegistryKey envVariables;

		public RemoteEnvVariableUtil(string remoteMachineName)
		{
			this.envVariables = RegistryKey
				.OpenRemoteBaseKey(RegistryHive.LocalMachine, "\\\\" + remoteMachineName)
				.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Environment",
					true);
		}

		/// <summary>
		/// Sets the environment variable. If the environment variable doesn't exist, it will create it. If
		/// it already exists, the value will be overwritten.l
		/// </summary>
		/// <param name="envVariableName"></param>
		/// <param name="envVariableValue"></param>
		public void SetEnvVariable(string envVariableName, string envVariableValue)
		{
			//retrieve Key information
			this.envVariables.SetValue(envVariableName.Trim(), envVariableValue.Trim());
		}

		/// <summary>
		/// Retrieves value of environment variable.
		/// </summary>
		/// <param name="envVariableName"></param>
		/// <returns></returns>
		public string GetEnvVariable(string envVariableName)
		{
			return this.envVariables.GetValue(envVariableName)?.ToString();
		}

		/// <inheritdoc />
		public void Dispose()
		{
			this.envVariables?.Dispose();
		}
	}

}