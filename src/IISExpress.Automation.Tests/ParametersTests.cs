using System;
using System.Linq;

using NUnit.Framework;
using SharpTestsEx;

namespace IISExpress.Automation.Tests
{
    [TestFixture]
    public class ParametersTests
    {
        [Test]
        public void Parameters_DefaultToString_ShouldBeEmpty()
        {
            var target = new Parameters();
            target.ToString().Should().Be.Empty();
        }

        [Test]
        [TestCase("port", 8080)]
        [TestCase("config", "demo.config")]
        [TestCase("site", "MySite")]
        [TestCase("siteid", "myId")]
        [TestCase("path", @"c:\myPath")]
        public void SetParameter(string name, object value)
        {
            var target = new Parameters();
            var property = typeof (Parameters).GetProperties()
                .First(p => string.Equals(p.Name, name, StringComparison.InvariantCultureIgnoreCase));

            property.SetValue(target, value, null);

            var expected = string.Format(" /{0}:{1}", name, value);

            target.ToString().Should().Be(expected);
        }

        [Test]
        public void SettingTraceLevelToNone_ReturnsEmpty()
        {
            var target = new Parameters();
            target.Trace.Should().Be(TraceLevel.None);
            target.ToString().Should().Be.Empty();
        }

        [Test]
        [TestCase(TraceLevel.Info)]
        [TestCase(TraceLevel.Error)]
        [TestCase(TraceLevel.Warning)]
        public void SettingTraceLevelTo(TraceLevel level)
        {
            var target = new Parameters {Trace = level};
            var expected = " /trace:" + level.ToString().ToLower();
            target.ToString().Should().Be(expected);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void SettingSystrayTo(bool value)
        {
            var target = new Parameters {Systray = value};
            var expected = value ? " /systray:true" : "";
            target.ToString().Should().Be(expected);
        }

    }
}
