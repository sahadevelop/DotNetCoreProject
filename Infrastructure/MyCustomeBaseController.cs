

namespace Infrastructure
{
    public class MyCustomeBaseController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        public static string ServerIp;
        public MyCustomeBaseController():base()
        {
            System.Net.IPHostEntry ip = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            System.Net.IPAddress[] paddr = ip.AddressList;
            string logip = string.Empty;
            foreach (System.Net.IPAddress t in paddr)
            {
                logip = t.ToString();
            }
            ServerIp = logip;
        }
    
    }
}
