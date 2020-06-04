﻿using System;
using System.Net.Http;

namespace TimeClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:1337");

            while (true)
            {
                var response = client.GetAsync("/time").Result; // NEVER DO THIS ON A SERVER!
                var content = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(content);
                Console.WriteLine(response.Headers.CacheControl?.ToString());

                if (Console.ReadLine() == "done") break;
            }
        }
    }
}
