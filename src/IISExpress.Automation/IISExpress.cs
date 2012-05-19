using System;
using System.Diagnostics;

namespace IISExpress.Automation
{
    public class IISExpress : IDisposable
    {
        private readonly ProcessEnvelope process;

        public IISExpress(Parameters parameters)
        {
            var info = new ProcessStartInfo
                           {
                               FileName = @"c:\Program Files (x86)\IIS Express\iisexpress.exe",
                               Arguments = parameters == null ? "" : parameters.ToString()
                           };

            process = new ProcessEnvelope(Process.Start(info));
        }

        #region IDisposable Members

        public void Dispose()
        {
            process.Dispose();
        }

        #endregion
    }
}