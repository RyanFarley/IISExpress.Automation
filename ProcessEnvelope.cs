using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace IISExpress.Automation
{
    internal class ProcessEnvelope
    {
        private readonly Process process;

        public ProcessEnvelope(Process process)
        {
            this.process = process;
        }

        public void Dispose()
        {
            NativeMethods.PostMessage(
                GetHandleRef(),
                0x12,
                IntPtr.Zero,
                IntPtr.Zero
                );
            process.Dispose();
        }

        private HandleRef GetHandleRef()
        {
            IntPtr ptr = NativeMethods.GetTopWindow(IntPtr.Zero);

            while (ptr != IntPtr.Zero)
            {
                uint num;
                NativeMethods.GetWindowThreadProcessId(ptr, out num);
                if (process.Id == num)
                    return new HandleRef(null, ptr);
                ptr = NativeMethods.GetWindow(ptr, 2);
            }

            throw new NullReferenceException("Process window not found.");
        }
    }
}