using System;
using Grpc.Core;

namespace Test
{
    class Program
    {
        public static void Main()
        {
            try
            {
                Channel channel = new Channel("192.168.237.130:50051", ChannelCredentials.Insecure);
                var client = new AccountService.AccountServiceClient(channel);

                EmployeeName empName = client.GetEmployeeName(new EmployeeNameRequest { EmpId = "1" });

                if(empName == null || string.IsNullOrWhiteSpace(empName.FirstName) ||
                    string.IsNullOrWhiteSpace(empName.LastName))
                {
                    Console.WriteLine("Employee not found.");
                }
                else
                {
                    Console.WriteLine($"The employee name is {empName.FirstName} {empName.LastName}.");
                }
                channel.ShutdownAsync().Wait();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception encountered: {ex}");
            }
        }
    }
}
