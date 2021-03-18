using System;

namespace ProjectManagement.Entities
{
    public class ExceptionEntity
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }

        public ExceptionEntity(Exception ex)
        {
            Type = ex.GetType().Name;
            Message = ex.Message;
            StackTrace = ex.StackTrace.ToString();
        }
    }
}
