using System;
using System.ComponentModel.DataAnnotations.Schema;
using VFT.Shared;

namespace VFT.CMS.Entities
{
    [Table("vft_Meta")]
    public class Meta : BaseEntity
    {
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
        public int PostsId { get; set; }
        [ForeignKey("PostsId")]
        public Posts Posts { get; set; }
    }
}
