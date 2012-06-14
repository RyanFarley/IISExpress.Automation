using System;
using System.Diagnostics;
using System.IO;

namespace IISExpressAutomation
{
    public class IISExpress : IDisposable
    {
        private readonly ProcessEnvelope process;        

        public IISExpress(Parameters parameters, string IISExpressPath = @"C:\Program Files (x86)\IIS Express\iisexpress.exe")
        {
            if (!File.Exists(IISExpressPath))
            {
                throw new ArgumentException("IIS Express executable not found", IISExpressPath);
            }
            
            var info = new ProcessStartInfo
                           {
                               FileName = IISExpressPath,
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