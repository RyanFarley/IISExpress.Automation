using System.Globalization;
using System.Text;

namespace IISExpress.Automation
{
    public enum TraceLevel
    {
        None,
        Info,
        Warning,
        Error
    }

    public class Parameters
    {
        public int Port { get; set; }
        public string Config { get; set; }
        public TraceLevel Trace { get; set; }
        public string Site { get; set; }
        public string Path { get; set; }
        public string SiteId { get; set; }
        public bool Systray { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (Port != 0)
                sb.Append(" /port:" + Port.ToString(CultureInfo.InvariantCulture));

            if (!string.IsNullOrEmpty(Config))
                sb.Append(" /config:" + Config);

            if (Trace != TraceLevel.None)
                sb.Append(" /trace:" + Trace.ToString().ToLower());

            if (!string.IsNullOrEmpty(Site))
                sb.Append(" /site:" + Site);

            if (!string.IsNullOrEmpty(Path))
                sb.Append(" /path:" + Path);

            if (!string.IsNullOrEmpty(SiteId))
                sb.Append(" /siteid:" + SiteId);

            if (Systray)
                sb.Append(" /systray:true");

            return sb.ToString();
        }
    }
}