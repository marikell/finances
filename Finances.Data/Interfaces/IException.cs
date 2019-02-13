using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Data.Interfaces
{
    public interface IException
    {
        bool IsValid{ get; }
        ICollection<string> Errors { get; }
        string GetException();
        void SetException(Exception exception);
        void SetException(string message);
    }
}
