using System;

namespace SharedKernel
{
    public interface ILog
    {
        string TableName { get; set; }
        string LogString { get; set; }
        Nullable<System.DateTime> TimeStamp { get; set; }
    }
}
