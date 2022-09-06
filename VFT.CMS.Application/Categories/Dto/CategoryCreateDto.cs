using System.ComponentModel.DataAnnotations;
using VFT.CMS.Entities;
using VFT.Shared;

namespace VFT.CMS.Application.Categories.Dto
{
    public class CategoryCreateDto : BaseCruidEntity
    {
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Thuộc danh mục")]
        public int? ParentCategory { get; set; }
        [Display(Name = "Trạng thái")]
        public StatusActivity Status { get; set; }
    }
}
