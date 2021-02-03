using System;
using Azure.Storage.Blobs;

namespace PhotoSharedApp
{
    
public static class OperationStorageAccount
    {
        public static void ShowBlobs(string connectionString){
            // Get a connection string to our Azure Storage account.  You can
                // obtain your connection string from the Azure Portal (click
                // Access Keys under Settings in the Portal Storage account blade)
                // or using the Azure CLI with:
                //
                //     az storage account show-connection-string --name <account_name> --resource-group <resource_group>
                //
                // And you can provide the connection string to your application
                // using an environment variable.
                string containerName = "images"; //I've named my container "images"
                //string connectionString = "DefaultEndpointsProtocol=https;AccountName=studyazurestorage;AccountKey=a5td8/AZOeeUJ0OxxNLdO30GWtVSsklUnXvdO0GyIYW16LtB+4c9gzBFB1I6YzCFBKKAM1ExL+uSXcc6RUHxUg==;EndpointSuffix=core.windows.net";
                //or better use JSON Configuration
                
                BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
                container.CreateIfNotExists(); //create the container "images" if no exists

                string blobName = "docs-and-friends-selfie-stick"; //
                string fileName = "myphotos\\docs-and-friends-selfie-stick.png";
                BlobClient blobClient = container.GetBlobClient(blobName);
                blobClient.Upload(fileName, true); //the second param allow re-write if exists.

                var blobs = container.GetBlobs();
                foreach (var blob in blobs)
                {
                    Console.WriteLine($"{blob.Name} --> Created On: {blob.Properties.CreatedOn:YYYY-MM-dd HH:mm:ss}  Size: {blob.Properties.ContentLength}");
                }
        }
    }
}