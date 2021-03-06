﻿using ConsoleAppFramework;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MultiContainedApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder()
                .RunConsoleAppFrameworkAsync(args);
        }
    }

    public class Foo : ConsoleAppBase
    {
        [Command("Echo", "Echo message to the logger")]
        public void Echo([Option("msg", "Message to send.")]string msg)
        {
            this.Context.Logger.LogInformation(msg);
        }

        public void Sum([Option(0)]int x, [Option(1)]int y)
        {
            this.Context.Logger.LogInformation((x + y).ToString());
        }
    }

    public class Bar : ConsoleAppBase
    {
        public void Hello2()
        {
            this.Context.Logger.LogInformation("H E L L O");
        }
    }
}
