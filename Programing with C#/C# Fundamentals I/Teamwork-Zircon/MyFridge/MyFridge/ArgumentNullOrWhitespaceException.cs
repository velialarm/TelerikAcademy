using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFridge
{
    
    public class ArgumentNullOrWhitespaceException : Exception
    {
        private string otherMessage;
        
        public string Message
        {
            get { return this.otherMessage; }
            set { this.otherMessage = value; }
        }
               
        public ArgumentNullOrWhitespaceException(string message)
            : this(message, null, null)
        {
            this.Message = message;
        }

        public ArgumentNullOrWhitespaceException(string message, string sysmessage, Exception innerException)
            : base(sysmessage, innerException)
        {
            this.Message = message;
        }
    }
}
