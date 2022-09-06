﻿using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VFT.Shared
{
    public enum StatusActivity
    {
        [Display(Name = "Kích hoạt")]
        Active = 1,
        [Display(Name = "Kích hoạt nội bộ")]
        ActiveInternal = 2,
        [Display(Name = "Khóa")]
        InActive = 3
    }
}
