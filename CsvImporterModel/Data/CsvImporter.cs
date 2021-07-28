using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace CsvImporterModel.Data
{
    public class CsvImporter: DbContext
    {
        [StringLength(20)]
        public string PointOfSale { get; set; }

        [StringLength(20)]
        public string Product { get; set; }

        [StringLength(10)]
        [Required]
        public string Date { get; set; }

        public Int16 Stock { get; set; }
    }
}
