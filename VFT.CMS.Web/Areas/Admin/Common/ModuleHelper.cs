using VFT.CMS.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;

namespace VFT.CMS.Web.Areas.Admin.Common
{
    /// <summary>
    /// This is where you customize the navigation sidebar
    /// </summary>
    public static class ModuleHelper
    {
        public enum Module
        {
            Home,

            Menu,
            Category,
            Posts,
            Slides,

            City,

            Catalog,
            Project,

            Kinds,
            House,

            RegisterRecieveInfo,

            User,
            Role,
            UserLogs
        }

        public static SidebarMenu AddHeader(string name)
        {
            return new SidebarMenu
            {
                Type = SidebarMenuType.Header,
                Name = name,
            };
        }

        public static SidebarMenu AddTree(string name, string iconClassName = "fa fa-link")
        {
            return new SidebarMenu
            {
                Type = SidebarMenuType.Tree,
                IsActive = false,
                Name = name,
                IconClassName = iconClassName,
                URLPath = "#",
            };
        }

        public static SidebarMenu AddModule(Module module, Tuple<int, int, int> counter = null)
        {
            if (counter == null)
                counter = Tuple.Create(0, 0, 0);

            switch (module)
            {
                case Module.Home:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Bảng điều khiển",
                        IconClassName = "fa fa-home",
                        URLPath = "/Admin",
                        LinkCounter = counter,
                    };
                case Module.Menu:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Menu",
                        IconClassName = "fa fa-sign-in-alt",
                        URLPath = "/Admin/Menu",
                        LinkCounter = counter,
                    };
                case Module.Category:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Danh mục",
                        IconClassName = "fa fa-sign-in-alt",
                        URLPath = "/Admin/Category",
                        LinkCounter = counter,
                    };
                case Module.Posts:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Tin tức",
                        IconClassName = "fa fa-sign-in-alt",
                        URLPath = "/Admin/Posts",
                        LinkCounter = counter,
                    };
                case Module.Slides:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Slides",
                        IconClassName = "fa fa-sign-in-alt",
                        URLPath = "/Admin/Slides",
                        LinkCounter = counter,
                    };
                case Module.City:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Thành phố",
                        IconClassName = "fa fa-sign-in-alt",
                        URLPath = "/Admin/City",
                        LinkCounter = counter,
                    };
                case Module.Catalog:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Danh mục dự án",
                        IconClassName = "fa fa-sign-in-alt",
                        URLPath = "/Admin/Catalog",
                        LinkCounter = counter,
                    };
                case Module.Project:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Dự án",
                        IconClassName = "fa fa-sign-in-alt",
                        URLPath = "/Admin/Project",
                        LinkCounter = counter,
                    };
                case Module.Kinds:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Danh mục nhà đất",
                        IconClassName = "fa fa-sign-in-alt",
                        URLPath = "/Admin/Kinds",
                        LinkCounter = counter,
                    };
                case Module.House:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Nhà đất",
                        IconClassName = "fa fa-sign-in-alt",
                        URLPath = "/Admin/House",
                        LinkCounter = counter,
                    };
                case Module.RegisterRecieveInfo:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Đăng ký nhận thông tin",
                        IconClassName = "fa fa-sign-in-alt",
                        URLPath = "/Admin/RegisterRecieveInfo",
                        LinkCounter = counter,
                    };
                case Module.User:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Người dùng",
                        IconClassName = "fa fa-users",
                        URLPath = "/Admin/User",
                        LinkCounter = counter,
                    };
                case Module.Role:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Phân quyền",
                        IconClassName = "fa fa-user-tag",
                        URLPath = "/Admin/Role",
                        LinkCounter = counter,
                    };
                case Module.UserLogs:
                    return new SidebarMenu
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Nhật ký log",
                        IconClassName = "fa fa-history",
                        URLPath = "/Admin/UserLogs",
                        LinkCounter = counter,
                    };

                default:
                    break;
            }

            return null;
        }
    }
}
