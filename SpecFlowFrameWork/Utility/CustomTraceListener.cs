using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Tracing;

namespace SpecFlowFrameWork.Utility
{
    public class CustomTraceListener:IThreadSafeTraceListener
    {
        public void WriteTestOutput(string message)
        {
            // Implement custom logic to handle test output messages
            // This method is called when SpecFlow generates test output.
            // You can log or process the message as needed.
        }

        public void WriteToolOutput(string message)
        {
            // Implement custom logic to handle tool output messages
            // This method is called when SpecFlow generates tool output.
            // You can log or process the message as needed.
        }
    }
}
