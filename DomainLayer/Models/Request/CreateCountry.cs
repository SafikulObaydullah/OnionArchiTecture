using System;

namespace DomainLayer.Models.Request
{
    public class CreateCountry
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime dteCreatedAt { get; set; }
        public string strUpdatedBy { get; set; }
        public DateTime? dteUpdatedAt { get; set; }
        public bool? isActive { get; set; }
    }
}