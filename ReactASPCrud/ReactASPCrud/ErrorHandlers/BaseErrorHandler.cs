using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReactASPCrud.Services;

namespace ReactASPCrud.ErrorHandlers
{
    public abstract class BaseErrorHandler : IErrorHandler
    {
        public IErrorHandler _nextErrorHandler;
        BaseErrorHandler()
        {
            _nextErrorHandler = null;
        }

        public bool Process()
        {
            throw new NotImplementedException();
        }

        public void SetNextHandler(IErrorHandler handler)
        {
            _nextErrorHandler = handler;
        }
    }
}
