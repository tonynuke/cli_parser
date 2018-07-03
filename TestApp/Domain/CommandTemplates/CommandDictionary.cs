namespace TestApp.Domain.CommandTemplates
{
    /// <summary>
    /// Содержит токены cli
    /// </summary>
    public static class CommandDictionary
    {
        public static readonly string Word = @"'?\w[\w']*(?:-\w+)*'?";

        public static readonly string Protocol = @"protocol";

        public static readonly string TCP = @"tcp";

        public static readonly string UDP = @"udp";

        public static readonly string Name = @"name";

        public static readonly string Set = @"set";

        public static readonly string Description = @"description";

        public static readonly string CliDestinationPort = @"destination-port";

        public static readonly string DestinationPort = @"DestinationPort";

        public static readonly string CliSourcePort = @"source-port";

        public static readonly string SourcePort = @"SourcePort";

        public static readonly string CliApplication = @"application";

        public static readonly string CliApplicationSet = @"application-set";
    }
}