using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStandardRegistryLib
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				if (args.Length != 3)
				{
					throw new ArgumentException("Must provide three arguments, the machine name, the variable name, and the variable value. Was provided with " + args.Length + " arguments.");
				}

				using (var registryUtil = new RegistryUtil(args[0]))
				{
					registryUtil.SetEnvVariable(args[1], args[2]);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("ERROR: " + ex);
			}
		}
	}
}
