﻿using VFT.CMS.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace VFT.CMS.Web.Areas.Admin.ViewComponents
{
    public class MenuNotificationViewComponent : ViewComponent
    {

        public MenuNotificationViewComponent()
        {
        }

        public IViewComponentResult Invoke(string filter)
        {
            var messages = GetData();
            return View(messages);
        }

        private List<Message> GetData()
        {
            var messages = new List<Message>();
            messages.Add(new Message
            {
                Id = 1,
                FontAwesomeIcon = "fa fa-users text-aqua",
                ShortDesc = "5 new members joined today",
                URLPath = "#",
            });

            return messages;
        }
    }
}
