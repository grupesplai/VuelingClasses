using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Common.Logic
{
    public interface ILogger
    {
        void Debug(object message);
        void Error(object message);
    }
}
