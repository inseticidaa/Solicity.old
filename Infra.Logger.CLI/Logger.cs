using Solicity.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Logger.CLI
{
    public class Logger : ILogger
    {
        public void Debug(string message)
        {
            //throw new NotImplementedException();
        }

        public void Debug(string message, Exception exception)
        {
            //throw new NotImplementedException();
        }

        public void Error(string message)
        {
            //throw new NotImplementedException();
        }

        public void Error(string message, Exception exception)
        {
            //throw new NotImplementedException();
        }

        public void Fatal(string message)
        {
            //throw new NotImplementedException();
        }

        public void Fatal(string message, Exception exception)
        {
            //throw new NotImplementedException();
        }

        public void Info(string message)
        {
            //throw new NotImplementedException();
        }

        public void Info(string message, Exception exception)
        {
            //throw new NotImplementedException();
        }

        public void Warn(string message)
        {
            //throw new NotImplementedException();
        }

        public void Warn(string message, Exception exception)
        {
            //throw new NotImplementedException();
        }
    }
}
