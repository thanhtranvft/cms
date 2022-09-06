using System.ComponentModel.DataAnnotations;

namespace VFT.CMS.Web.Areas.Admin.Models.AccountViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
