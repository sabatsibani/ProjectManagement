using System;
using System.Globalization;

namespace ProjectManagement.Shared
{
    public class ApplicationError:Exception
    {
        public ApplicationError() : base() { }

        public ApplicationError(string message) : base(message) { }

        public ApplicationError(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
