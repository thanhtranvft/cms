using System;
using System.ComponentModel.DataAnnotations.Schema;
using VFT.Shared;

namespace VFT.CMS.Entities
{
    [Table("vft_Posts")]
    public class Posts : BaseCruidEntity
    {
        /// <summary>
        /// Tên menu
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// link bài viết
        /// </summary>
        public string? Slug { get; set; }
        /// <summary>
        /// Trích đoạn mô tả
        /// </summary>
        public string Excerpt { get; set; }
        /// <summary>
        /// Hình ảnh trích cho trích đoạn
        /// </summary>
        public string? ExcerptImage { get; set; }
        /// <summary>
        /// Nội dung bài viết, dùng ckeditor
        /// </summary>
        public string Content { get; set; }        
        /// <summary>
        /// Liên kết đến
        /// </summary>
        public string? LinkTo { get; set; }
        /// <summary>
        /// Thuộc danh mục nào, tạm thời 1 bài viết chỉ thuộc 1 loại danh mục
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// Bài viết hiệu lực từ ngày
        /// </summary>
        public DateTime? FromDate { get; set; }
        /// <summary>
        /// Bài viết hiệu lực đến ngày
        /// </summary>
        public DateTime? ToDate { get; set; }
        /// <summary>
        /// Trạng thái
        /// </summary>
        public StatusActivity Status { get; set; }

        //navigation property: configure one-t0-many relationship with Photo 
        //public List<Photo> Photos { get; set; }
        public Meta Meta { get; set; }
        public VisitCount VisitCount { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
