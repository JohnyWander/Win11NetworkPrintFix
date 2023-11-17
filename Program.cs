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
             
                WorkKey.SetValue("RpcAuthentication", 0, RegistryValueKind.DWord);
                WorkKey.SetValue("RpcUseNamedPipeProtocol", 1, RegistryValueKind.DWord);

                Console.WriteLine(@"Successfully added registry key Software\\Policies\\Microsoft\\Windows NT\Printers\RPC\RpcAuthentication, 0 value DWORD");
                Console.WriteLine(@"Successfully added registty key Software\\\\Policies\\\\Microsoft\\\\Windows NT\\Printers\\RPC\\RpcAuthentication , 1 value DWORD");
                Console.WriteLine(@"Your network printing should work now, if not feel free to open an issue on https://github.com/JohnyWander/Win11NetworkPrintFix");
                Console.WriteLine("There are several things more in Win 11 that can make problems with network printing");
                Console.WriteLine("Press any ley to exit");
                Console.ReadLine();

            } catch (System.Security.SecurityException)
            {
                Console.WriteLine("Please run this program with administrator rights");
                Console.ReadKey();
            }
            
        }
    }
}