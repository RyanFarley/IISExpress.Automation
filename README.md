IISExpress Automation Library
================================

What is "IISExpress Automation?"
--------------------------------
IISExpress Automation is a simple little library built to solve a deceptively complex problem - to start and stop IISExpress, for a WebSite, from code.


Where can I get it?
--------------------------------
First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). Then, install IISExpress Automation from the package manager console:

    PM> Install-Package IISExpress.Automation

Basic Sample
--------------------------------

    using System;
    using IISExpressAutomation;

    namespace Automation.Demo
    {
        class Program
        {
            static void Main()
            {
                using (var iis = new IISExpress(new Parameters {
                    Path = @"c:\git\MyWebSite",
                    Port = 8080
                    }))
                {
                    Console.WriteLine("Pressione qq tecla para fechar.");
                    Console.ReadLine();
                }
            }
        }
    }
	
Shipping IIS Express with your application and custom path
----------------------------------------------------------
	
By default, IISExpress.Automation will look for the IIS Express executable in "C:\Program Files (x86)\IIS Express\iisexpress.exe".

In case you have it somewhere else or want to ship it with your application you can provide the executable path as an optional parameter in the constructor.

	using (var iis = new IISExpress(new Parameters {
		Path = @"c:\git\MyWebSite",
		Port = 8080
		}),
		"C:\myCustomPath\iisexpress.exe")
	{
		Console.WriteLine("Pressione qq tecla para fechar.");
		Console.ReadLine();
	}