using NetCoreAngularHelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAngularHelloWorld.Services
{
    public class MyService : IService
    {
        public bool DoSomething(DataModel data)
        {
            return true;
        }
    }
}
