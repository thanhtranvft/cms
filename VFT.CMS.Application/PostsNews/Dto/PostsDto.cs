﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VFT.CMS.Entities;
using VFT.Shared;

namespace VFT.CMS.Application.PostsNews.Dto
{
    public class PostsDto : BaseCruidEntity
    {
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Danh mục")]
        public int CategoryId { get; set; }
        [Display(Name = "Danh mục")]
        public string CategoryName { get; set; }
        [Display(Name = "Lượt truy cập")]
        public string VisitCount { get; set; }
        [Display(Name = "Thời gian mở")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FromDate { get; set; }
        [Display(Name = "Thời gian đóng")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ToDate { get; set; }
        [Display(Name = "Trạng thái")]
        public StatusActivity Status { get; set; }
        [Display(Name = "Trạng thái")]
        public string StatusString { get => Status.GetDescription(); }
    }
}
