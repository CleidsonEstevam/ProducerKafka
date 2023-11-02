using Confluent.Kafka;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    public static async Task Main(string[] args)
    {
        var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

        using (var p = new ProducerBuilder<Null, string>(config).Build())
        {
            try
            {
                var count = 0;
                var dataPayment = new DataPayment();

                var data = JsonSerializer.Serialize(dataPayment);
                while (true)
                {
                    var dr = await p.ProduceAsync("topic-payment-analysis", new Message<Null, string> 
                    
                    { Value = $"Mensagem {data} {count++}" });
                    
                    Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset} | {count}'");
                    Thread.Sleep(2000);
                }
           
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Delivery failed: {e.Error.Reason}");
            }
        }
    }
}