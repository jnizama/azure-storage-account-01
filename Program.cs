using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace PhotoSharedApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Configue this app to read from JSON File
            //USE this commands to work with JSON files
            //dotnet add package Microsoft.Extensions.Configuration.Json
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            
            string connectionString = configuration.GetConnectionString("StorageAccount");
            
            
            //1 Read files (blobs) from a container
            OperationStorageAccount.ShowBlobs(connectionString);
            Console.WriteLine("Let's pass DP-200!");
        }
    }
}
