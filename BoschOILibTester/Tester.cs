using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bosch.PRAESENSA.OpenInterface;

namespace BoschOILibTester
{
    public class Tester
    {
        //private bool NCO_GetNcoVersion(OpenInterfaceNetClient client, string ip, string username, string password)
        //{
        //    TOIErrorCode ec = client.Connect(ip, username, password);
        //    if (ec == TOIErrorCode.OIERROR_OK) {
        //        // Continue as usual
        //        return true;
        //    } else {
        //        // Handle and/or report error
        //        return false
        //    }
        //}
        static void Main(string[] args)
        {
            OpenInterfaceNetClient client = new OpenInterfaceNetClient();
            string ip = "192.168.4.15";
            string username = "admin";
            string password = "password";

            TOIErrorCode ec_connect = client.Connect(ip, username, password);
            if (ec_connect == TOIErrorCode.OIERROR_OK) {
                Console.WriteLine("Praesensa is connected");

                TOIErrorCode ec_getNcoVersion = client.GetNcoVersion(out string release);
                if (ec_getNcoVersion == TOIErrorCode.OIERROR_OK) {
                    Console.WriteLine($"NCO Version: {release}");
                } else {
                    Console.WriteLine("Failed to get NCO Version");
                }

                TOIErrorCode ec_disconnect = client.Disconnect();
                if (ec_disconnect == TOIErrorCode.OIERROR_OK) {
                    Console.WriteLine("Praesensa is disconnected");
                } else {
                    Console.WriteLine("Failed to disconnect Praesensa");
                }

            } else {
                Console.WriteLine("Failed to connect Praesensa");
            }

            Console.ReadKey();
        }
    }
}
