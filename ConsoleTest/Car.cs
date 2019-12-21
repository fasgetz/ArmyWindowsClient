using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public class Car
    {
        [Key]
        public string LicenceNumber { get; set; }
        public string Insurance { get; set; }
        public int? Year { get; set; }

        public override string ToString()
        {
            return LicenceNumber;
        }
    }
}
