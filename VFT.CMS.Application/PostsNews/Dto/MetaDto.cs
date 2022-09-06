using System;
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
    public class MetaDto : BaseEntity
    {
        [Display(Name = "SEO tiêu đề")]
        public string MetaKey { get; set; }
        [Display(Name = "SEO data")]
        public string MetaValue { get; set; }
        public int PostsId { get; set; }
    }
}
