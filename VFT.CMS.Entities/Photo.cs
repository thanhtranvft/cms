using System;
using System.ComponentModel.DataAnnotations.Schema;
using VFT.Shared;

namespace VFT.CMS.Entities
{
    [Table("vft_Photo")]
    public class Photo : BaseCruidEntity
    {
        public byte[] Bytes { get; set; }
        public string Description { get; set; }
        public string FileExtension { get; set; }
        public decimal Size { get; set; }
        public int PostsId { get; set; }
        [ForeignKey("PostsId")]
        public Posts Posts { get; set; }
    }
}
