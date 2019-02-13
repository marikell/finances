using Finances.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finances.Data.Models
{
    public class ExceptionResult : IException
    {
        public bool IsValid
        {
            get { return Errors.Count == 0; }
        }

        public ICollection<string> Errors { get; } = new List<string>();

        private void SetError(string message)
        {
            Errors.Add(message);
        }

        public void SetException(Exception exception)
        {
            SetError(exception.InnerException.Message);
        }

        public void SetException(string message)
        {
            SetError(message);
        }

        public string GetException()
        {
            return Errors.FirstOrDefault();
        }
    }
}
