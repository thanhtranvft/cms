using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VFT.CMS.Web.Areas.Admin.Common;
using VFT.CMS.Web.Areas.Admin.Models;
using System.Security.Claims;
using VFT.CMS.Web.Areas.Admin.Common.Extensions;
using System;

namespace VFT.CMS.Web.Areas.Admin.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        public SidebarViewComponent()
        {
        }

        public IViewComponentResult Invoke(string filter)
        {
            //you can do the access rights checking here by using session, user, and/or filter parameter
            var sidebars = new List<SidebarMenu>();

            sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.Home));

            sidebars.Add(ModuleHelper.AddTree("Quản lý"));
            sidebars.Last().TreeChild = new List<SidebarMenu>()
            {
                ModuleHelper.AddModule(ModuleHelper.Module.Menu),
                ModuleHelper.AddModule(ModuleHelper.Module.Category),
                ModuleHelper.AddModule(ModuleHelper.Module.Posts),
                ModuleHelper.AddModule(ModuleHelper.Module.Slides),
            };

            sidebars.Add(ModuleHelper.AddTree("Thành phố"));
            sidebars.Last().TreeChild = new List<SidebarMenu>()
            {
                ModuleHelper.AddModule(ModuleHelper.Module.City),
            };

            sidebars.Add(ModuleHelper.AddTree("Dự án"));
            sidebars.Last().TreeChild = new List<SidebarMenu>()
            {
                ModuleHelper.AddModule(ModuleHelper.Module.Catalog),
                ModuleHelper.AddModule(ModuleHelper.Module.Project),
            };

            sidebars.Add(ModuleHelper.AddTree("Nhà đất"));
            sidebars.Last().TreeChild = new List<SidebarMenu>()
            {
                ModuleHelper.AddModule(ModuleHelper.Module.Kinds),
                ModuleHelper.AddModule(ModuleHelper.Module.House),
            };

            sidebars.Add(ModuleHelper.AddTree("Khách hàng"));
            sidebars.Last().TreeChild = new List<SidebarMenu>()
            {
                ModuleHelper.AddModule(ModuleHelper.Module.RegisterRecieveInfo),
            };
            //sidebars.Add(ModuleHelper.AddHeader("QUẢN LÝ"));            
            //sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.Menu));
            //sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.Category));
            ////sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.Category, Tuple.Create(0, 1, 0)));
            //sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.Posts));
            //sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.Slides));

            //sidebars.Add(ModuleHelper.AddHeader("THÀNH PHỐ"));
            //sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.City));

            //sidebars.Add(ModuleHelper.AddHeader("DỰ ÁN"));
            //sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.Catalog));
            //sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.Project));

            //sidebars.Add(ModuleHelper.AddHeader("NHÀ ĐẤT"));
            //sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.Kinds));
            //sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.House));

            //sidebars.Add(ModuleHelper.AddHeader("KHÁCH HÀNG"));
            //sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.RegisterRecieveInfo));

            if (User.IsInRole("SuperAdmin"))
            {
                sidebars.Add(ModuleHelper.AddTree("Quản trị"));
                sidebars.Last().TreeChild = new List<SidebarMenu>()
                {
                    ModuleHelper.AddModule(ModuleHelper.Module.User),
                    ModuleHelper.AddModule(ModuleHelper.Module.Role),
                };
                //sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.UserLogs));
            }

            return View(sidebars);
        }
    }
}
