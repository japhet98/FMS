using FMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new CustomerController();
            Console.WriteLine(repo.GetCustomers());
        }
    }
}
