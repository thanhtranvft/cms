using System;
using System.Collections.Generic;
using System.Text;

namespace VFT.CMS.Entities
{
    public class BaseCruidEntity
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime ModifiedTime { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
