using System.IO;
using NUnit.Framework;
using TestApp.Domain;
using TestApp.Domain.CommandTemplates;
using TestApp.Domain.Configurations;

namespace TestApp.UnitTests
{
    [TestFixture]
    public class CommandTemplatesTest
    {
        [Test]
        public void Application_set_description_attribute()
        {
            var app = new ApplicationConfig();
            app.SetPropsFromString("description", "asd");

            Assert.AreEqual("asd", app.Description);
        }

        [Test]
        public void Application_set_port_attribute()
        {
            var app = new ApplicationConfig();
            app.SetPropsFromString("destinationport", "1488");

            Assert.AreEqual("1488", app.DestinationPort);
        }

        [Test]
        public void Application_set_tcp_protocol_attribute()
        {
            var app = new ApplicationConfig();
            app.SetPropsFromString("protocol", "tcp");

            Assert.AreEqual("tcp", app.Protocol);
        }

        [Test]
        public void Application_set_udp_protocol_attribute()
        {
            var app = new ApplicationConfig();
            app.SetPropsFromString("protocol", "udp");

            Assert.AreEqual("udp", app.Protocol);
        }

        [Test]
        public void SAPC_return_protocol_application()
        {
            var cli = "set applications application custom-sql protocol tcp";
            var sapc = new SetApplicationProtocolCommandTemplate();
            var actualResult = sapc.Parse(cli) as ApplicationConfig;

            Assert.IsNotNull(actualResult);

            Assert.AreEqual("tcp", actualResult.Protocol);
            Assert.AreEqual("custom-sql", actualResult.Name);
        }

        [Test]
        public void SAPC_return_port_application()
        {
            var cli = "set applications application custom-sql destination-port 5000-6000";
            var sapc = new SetApplicationDestinationPortCommandTemplate();
            var actualResult = sapc.Parse(cli) as ApplicationConfig;

            Assert.IsNotNull(actualResult);

            Assert.AreEqual("5000-6000", actualResult.DestinationPort);
            Assert.AreEqual("custom-sql", actualResult.Name);
        }

        [Test]
        public void SADC_return_description_application()
        {
            var cli = "set applications application custom-xyz description myCoolApp";
            var sapc = new SetApplicationDesscriptionCommandTemplate();
            var actualResult = sapc.Parse(cli) as ApplicationConfig;

            Assert.IsNotNull(actualResult);

            Assert.AreEqual("myCoolApp", actualResult.Description);
        }

        [Test]
        public void CommandsManager_creates_app()
        {
            var cli = "set applications application custom-sql destination-port 5000-6000";
            var manager = new CommandsManager();
            var app = manager.Parse(cli);

            Assert.IsNotNull(app);
        }

        [Test]
        public void CommandsManager_returns_null()
        {
            var cli = "set applications application custom-sql destination-por 5000-6000";
            var manager = new CommandsManager();
            var app = manager.Parse(cli);

            Assert.IsNull(app);
        }

        [Test]
        public void CommandsManager_parse()
        {
            var filename = @"D:\Projects\Repos\TestApp\TestApp\Src\test.txt";
            var manager = new CommandsManager();
            manager.ParseFile(filename);
        }

        [Test]
        public void CommandsManager_exports_xml()
        {
            var filename = @"D:\Projects\Repos\TestApp\TestApp\Src\test.txt";
            var manager = new CommandsManager();
            manager.ParseFile(filename);
            var output = manager.Configuration.Export();

            File.WriteAllText(@"D:\Projects\Repos\TestApp\TestApp\Src\res.txt", output);
        }
    }
}