using System;
using System.ComponentModel.DataAnnotations.Schema;
using VFT.Shared;

namespace VFT.CMS.Entities
{
    [Table("vft_VisitCount")]
    public class VisitCount : BaseEntity
    {
        public int Count { get; set; }
        public int PostsId { get; set; }
        [ForeignKey("PostsId")]
        public Posts Posts { get; set; }
    }
}
