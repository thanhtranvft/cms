using System;
using System.ComponentModel.DataAnnotations.Schema;
using VFT.Shared;

namespace VFT.CMS.Entities
{
    [Table("vft_Category")]
    public class Category : BaseCruidEntity
    {
        public string Title { get; set; }
        public int? ParentCategory { get; set; }
        public StatusActivity Status { get; set; }
        [ForeignKey("ParentCategory")]
        public Category Parent { get; set; }
    }
}
