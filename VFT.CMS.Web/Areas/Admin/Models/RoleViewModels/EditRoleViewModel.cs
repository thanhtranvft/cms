﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VFT.CMS.EntityFrameworkCore;

namespace VFT.CMS.Web.Areas.Admin.Models.RoleViewModels
{
    public class EditRoleViewModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<CMSIdentityUser> Members { get; set; }
        public IEnumerable<CMSIdentityUser> NonMembers { get; set; }
    }
}
