using System.ComponentModel.DataAnnotations;
using VFT.CMS.Entities;
using VFT.Shared;

namespace VFT.CMS.Application.Menus.Dto
{
    public class MenuEditDto : BaseCruidEntity
    {
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Thuộc menu")]
        public int? ParentMenu { get; set; }
        [Display(Name = "Trạng thái")]
        public StatusActivity Status { get; set; }
        [Display(Name = "Router")]
        public string? Router { get; set; }
        [Display(Name = "Sắp xếp")]
        public int DisplayOrder { get; set; }
        [Display(Name = "Vị trí")]
        public string? Position { get; set; }
        [Display(Name = "Liên kết đến")]
        public string? LinkTo { get; set; }
    }
}
