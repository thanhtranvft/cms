using System;
using System.ComponentModel.DataAnnotations.Schema;
using VFT.Shared;

namespace VFT.CMS.Entities
{
    [Table("vft_Menu")]
    public class Menu : BaseCruidEntity
    {
        /// <summary>
        /// Tên menu
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Menu thuộc 1 menu cha
        /// </summary>
        public int? ParentMenu { get; set; }
        /// <summary>
        /// Trạng thái
        /// </summary>
        public StatusActivity Status { get; set; }
        /// <summary>
        /// show link instead of action/controll
        /// </summary>
        public string? Router { get; set; }
        /// <summary>
        /// Hiển thị thứ tự ở menu
        /// </summary>
        public int DisplayOrder { get; set; }
        /// <summary>
        /// Vị trị hiển thị nếu template có định nghĩa
        /// </summary>
        public string? Position { get; set; }
        /// <summary>
        /// Liên kết đến
        /// </summary>
        public string? LinkTo { get; set; }       
    }
}
