using System.ComponentModel.DataAnnotations;
using VFT.CMS.Entities;
using VFT.Shared;

namespace VFT.CMS.Application.PostsNews.Dto
{
    public class PostsCreateDto : BaseCruidEntity
    {
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Liên kết")]
        public string? Slug { get; set; }
        [Display(Name = "Mô tả trích đoạn")]
        public string Excerpt { get; set; }
        [Display(Name = "Hình ảnh trích đoạn")]
        public string? ExcerptImage { get; set; }
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Danh mục")]
        public int CategoryId { get; set; }
        [Display(Name = "Liên kết đến")]
        public string? LinkTo { get; set; }

        [Display(Name = "Thời gian mở")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FromDate { get; set; }

        [Display(Name = "Thời gian đóng")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ToDate { get; set; }
        [Display(Name = "Trạng thái")]
        public StatusActivity Status { get; set; }

        [Display(Name = "SEO tiêu đề")]
        public string? MetaKey { get; set; }
        [Display(Name = "SEO data")]
        public string? MetaValue { get; set; }
    }
}
