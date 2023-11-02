using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Entities.EntitiesDto
{
    public partial class CompanyDto
    {
        public int CompanyKey { get; set; }
        public string? Name { get; set; } 
        public string? Description { get; set; } 
        public string? ImageUrl { get; set; } 
        public string? LogoUrl { get; set; } 
        public string? Location { get; set; } 
        public string? WorkField { get; set; } 
        public IFormFile? ImageFile { get; set; }
        public IFormFile? LogoFile { get; set; }
    }
}
