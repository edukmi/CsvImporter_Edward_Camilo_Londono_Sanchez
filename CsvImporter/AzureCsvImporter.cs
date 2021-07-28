using Azure;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using CsvImporterModel.Connection;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace CsvImporter
{
    public class AzureCsvImporter
    {
        private static AcmeCorporationDbContext _db;

        public static async Task Main()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appSettings.json");
            IConfiguration configuration = builder.Build();

            await DownloadFilesAsync(configuration);

        }

        /// <summary>
        /// Download azure file
        /// </summary>
        /// <param name="configuration">configuration variables</param>
        /// <returns></returns>
        public static async Task DownloadFilesAsync(IConfiguration configuration)
        {
            #region Variables

            _db = new AcmeCorporationDbContext();
            string url = configuration["URLBlog"];
            string file = configuration["FileDownload"];
            string targetRoute = configuration["TargetRoute"];
            int timeOut = Convert.ToInt32(configuration["TimeOut"]);
            string uri = string.Format("{0}/{1}", url, file);
            string download = string.Format("{0}/{1}", targetRoute, file);

            #endregion

            try
            {
                var options = new StorageTransferOptions
                {
                    MaximumConcurrency = 8,
                    MaximumTransferSize = 50 * 1024 * 1024
                };

                BlockBlobClient blobsss = new BlockBlobClient(new Uri(uri));
                _ = await blobsss.DownloadToAsync(download, default, options);

                Console.WriteLine("Download File succed");

                await InsertDataAsync(download, timeOut);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        /// <summary>
        /// Insert into database the data downloaded from Azure
        /// </summary>
        /// <param name="targetRoute">path where the azure file was downloaded</param>
        /// <param name="timeOut">Waiting time for stored procedure execution</param>
        /// <returns></returns>
        public  static async Task InsertDataAsync(string targetRoute, int timeOut)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[]
                       {
                    new SqlParameter()
                    {
                        ParameterName = "@sourceroute",
                        Value = targetRoute
                    }
                       };

                _db.Database.SetCommandTimeout(timeOut);
                var rowsAffected = await _db.Database.ExecuteSqlRawAsync("EXEC dbo.SP_CsvImporter @sourceroute", parameter);

                Console.WriteLine($"Total data inserted: {rowsAffected}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

        }
    }
}
