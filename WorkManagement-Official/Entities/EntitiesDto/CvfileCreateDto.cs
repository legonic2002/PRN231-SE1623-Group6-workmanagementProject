using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.EntitiesDto
{
    public class CvfileCreateDto
    {
        public IFormFile CvFile { get; set; } = null!;
        public int AccountKey { get; set; }
        public string CvName { get; set; } = null!;
    }
}
