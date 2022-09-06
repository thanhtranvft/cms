using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Entities;
using VFT.CMS.EntityFrameworkCore;

namespace VFT.CMS.Application.Services
{
    public class BaseService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BaseService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected void FillAuthInfo(BaseCruidEntity data)
        {
            if (data != null)
            {
                var userId = _httpContextAccessor.HttpContext.User.GetUserProperty(CustomClaimTypes.NameIdentifier);
                var timeNow = DateTime.Now;
                if (data.Id < 1)
                {
                    data.CreatedBy = userId;
                    data.CreatedTime = timeNow;
                    data.ModifiedBy = userId;
                    data.ModifiedTime = timeNow;
                }
                else
                {
                    if(string.IsNullOrEmpty(data.CreatedBy))
                    {
                        data.CreatedBy = userId;
                        data.CreatedTime = timeNow;
                    }    
                    data.ModifiedBy = userId;
                    data.ModifiedTime = timeNow;
                }
            }
        }
    }
}
