using System;
using System.Diagnostics;

namespace IISExpress.Automation
{
    public class IISExpress : IDisposable
    {
        private readonly ProcessEnvelope process;

        public IISExpress(int port, string path)
        {
            var info = new ProcessStartInfo
                           {
                               FileName = @"c:\Program Files (x86)\IIS Express\iisexpress.exe",
                               Arguments = string.Format("/port:{0} /path:{1}", port, path)
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