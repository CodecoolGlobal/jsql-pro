using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactASPCrud.Services
{
    public interface IErrorHandler
    {
        void SetNextHandler(IErrorHandler handler);
        bool Process();
    }
}
