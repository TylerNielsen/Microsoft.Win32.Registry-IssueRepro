using System;

namespace RegistryConsoleAppCore
{
    class Program
    {
        static void Main(string[] args)
        {
	        using (var util = new RemoteEnvVariableUtil("10.11.41.110"))
	        {
				util.SetEnvVariable("TYLER_TEST_VAR", DateTime.Now.ToString("O"));
	        }
        }
    }
}
