using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VFT.CMS.Web.Areas.Admin.Models
{
    public class AlertMessage
    {
        private string _text;

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        public AlertType Type { get; set; }

        public string Title { get; set; }

        public bool Dismissible { get; set; }

        public string DisplayType { get; set; }

        public AlertMessage(AlertType type, string text, string title = null, bool dismissible = true, string displayType = null)
        {
            Type = type;
            Text = text;
            Title = title;
            Dismissible = dismissible;
            DisplayType = displayType ?? AlertDisplayType.PageAlert;
        }
    }

    public enum AlertType
    {
        Success,
        Danger,
        Warning,
        Info
    }
    public class AlertDisplayType
    {
        public static string PageAlert = "PageAlert";

        public static string Toastr = "Toastr";
    }
}
