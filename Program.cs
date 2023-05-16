using Microsoft.Win32;
namespace Win11PrintFIxer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Policies\Microsoft\Windows NT", true);
                key.CreateSubKey("Printers");
                key.CreateSubKey("Printers\\RPC");


                RegistryKey WorkKey = Registry.LocalMachine.OpenSubKey(@"Software\Policies\Microsoft\Windows NT\Printers\RPC", true);
                // WorkKey.SetValue("RpcOverNamedPipes", 1, RegistryValueKind.DWord);
                //key.SetValue()
                WorkKey.SetValue("RpcAuthentication", 0, RegistryValueKind.DWord);
                WorkKey.SetValue("RpcUseNamedPipeProtocol", 1, RegistryValueKind.DWord);

            } catch (System.Security.SecurityException)
            {
                Console.WriteLine("Please run this program with administrator rights");
                Console.ReadKey();
            }
            
        }
    }
}