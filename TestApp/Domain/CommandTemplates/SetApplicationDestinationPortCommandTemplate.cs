﻿using System.Text.RegularExpressions;
using TestApp.Domain.Configurations;

namespace TestApp.Domain.CommandTemplates
{
    public class SetApplicationDestinationPortCommandTemplate : ICommandTemplate
    {
        private readonly string pattern =
            $"^{CommandDictionary.Set} " +
            $"{CommandDictionary.Word} " +
            $"{CommandDictionary.CliApplication} " +
            $"{CommandDictionary.Word} " +
            $"{CommandDictionary.CliDestinationPort} " +
            $"{CommandDictionary.Word}";

        public AbstractConfig Parse(string commandLine)
        {
            bool isMathced = Regex.IsMatch(commandLine, this.pattern);

            if (isMathced == true)
            {
                var result = this.SetupApplication(commandLine);
                return result;
            }

            return null;
        }

        private ApplicationConfig SetupApplication(string commandLine)
        {
            var separator = ' ';
            var args = commandLine.Split(separator);

            var application = new ApplicationConfig();

            var root = args[1];
            var appName = args[3];
            var port = args[5];

            application.Root = root;
            application.Name = appName;
            application.DestinationPort = port;

            return application;
        }
    }
}