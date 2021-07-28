using CsvImporter;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace TestCsvImporter
{
    [TestClass]
    public class Tests
    {
        private IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appSettings.json");
        
        [Test]
        public async Task Main()
        {
            await AzureCsvImporter.Main();
        }

        [Test]
        public async Task DownloadFilesAsync()
        {
            IConfiguration configuration = builder.Build();
            await AzureCsvImporter.DownloadFilesAsync(configuration);
        }

        [Test]
        public async Task InsertDataAsync()
        {
            IConfiguration configuration = builder.Build();
            string file = configuration["FileDownload"];
            string targetRoute = configuration["TargetRoute"];
            int timeOut = Convert.ToInt32(configuration["TimeOut"]);
            string download = string.Format("{0}/{1}", targetRoute, file);

            await AzureCsvImporter.InsertDataAsync(download, timeOut);
        }
        
    }
}