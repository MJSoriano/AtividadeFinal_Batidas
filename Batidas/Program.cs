using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using M2Mqtt;
using M2Mqtt.Messages;
using M2Mqtt.Net;
using M2Mqtt.Utility;
using M2Mqtt.Internal;

namespace Batidas
{
    class Program
    {
        static void Main(string[] args)
        {
            string IotEndPoint = "awsiotendpoint.iot.us-east-1.amazonaws.com";
            Console.WriteLine("AWS IOT Iniciado");
            int BrokerPort = 8883;
            string Topic = "Coisa Batidas";

            Random randNum = new Random();

            var CaCert = X509Certificate.CreateFromCertFile(@"C:\Users\Mateus\source\repos\Batidas\17c2989b0d-certificate.pem.crt");
            var ClientCert = new X509Certificate2(@"C:\Users\Mateus\source\repos\Batidas\17c2989b0d-public.pfxx", "senha@pass");

            string ClientId = Guid.NewGuid().ToString();

            var IotClient = new MqttClient(IotEndPoint, BrokerPort, true, CaCert, ClientCert, MqttSslProtocols.TLSv1_2);

            IotClient.Connect(ClientId);

            while (true)
            {
                int Message = randNum.Next(70, 200);
                //IotClient.Publish(Topic, Encoding.UTF8.GetBytes(Message.ToString()));
                Console.WriteLine(Message);
                Thread.Sleep(1000);
            }
        }
    }
}
