using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription_Listing
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Test t = new Test();
            await t.Go();
            Console.WriteLine("finished");
            Console.ReadKey();
        }
    }
}
