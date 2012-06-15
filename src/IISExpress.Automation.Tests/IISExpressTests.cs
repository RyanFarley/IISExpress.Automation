using System;

using NUnit.Framework;
using SharpTestsEx;

namespace IISExpressAutomation.Tests
{
    [TestFixture]
    public class IISExpressTests
    {
        [Test]
        public void constructor_should_throw_if_IISExpress_executable_not_found()
        {
            var IISExpressPath = @"C:\NotExist.exe";
            
            Executing
                .This(() => new IISExpressAutomation.IISExpress(null, IISExpressPath))
                .Should()
                .Throw()
                    .Exception.GetType().Should().Be.EqualTo<ArgumentException>();            
        }
    }
}
