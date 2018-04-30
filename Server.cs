using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace jp.tamagotchi.engine {
    public class Server {

        private IConfiguration _configuration;
        private IConfigurationSection _serverConfiguration;
        private Grpc.Core.Server _server;

        public Server(IConfiguration configuration) {
            _configuration = configuration;
            _serverConfiguration = _configuration.GetSection("server");

            BuildServer();

        }

        private void BuildServer() {

            var host = _serverConfiguration["host"];
            var port = int.Parse(_serverConfiguration["port"]);
            var credentials = Grpc.Core.ServerCredentials.Insecure;

            _server = new Grpc.Core.Server {
                Ports = {
                new Grpc.Core.ServerPort(host, port, credentials)
                }
            };

        }

        public void Start() => _server.Start();

        public Task Stop() => _server.ShutdownAsync();

    }
}