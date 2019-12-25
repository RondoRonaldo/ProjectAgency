using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Infrastructure
{
    public class OperationDetails
    {
        public OperationDetails(bool succeeded, string message, string property)
        {
            Succeeded = succeeded;
            Message = message;
            Property = property;
        }
        public bool Succeeded { get; }
        public string Message { get; }
        public string Property { get; }
    }
}
