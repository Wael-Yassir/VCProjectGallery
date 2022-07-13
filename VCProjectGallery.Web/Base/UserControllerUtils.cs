using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace VCProjectGallery.Web.Base
{
	public static class UserControllerUtils
	{
        public static Guid GetUserID(this ControllerBase controller)
        {
            return new Guid(controller.HttpContext.User.Claims.Where(w => w.Type == "jti")
                .FirstOrDefault().Value);
        }

        public static string GetUserName(this ControllerBase controller)
        {
            return controller.HttpContext.User.Claims.Where(w => w.Type == ClaimTypes.Name)
                .FirstOrDefault().Value;
        }
    }
}