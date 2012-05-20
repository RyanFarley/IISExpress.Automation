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

