using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace VCProjectGallery.Data.Base
{
	public static class UserControllerUtils
	{
        public static Guid GetUserID(this ControllerBase controller)
        {
            //TODO: change line below
            return new Guid();
            return new Guid(controller.HttpContext.User.Claims.Where(w => w.Type == ClaimTypes.NameIdentifier)
                .FirstOrDefault().Value);
        }

        public static string GetUserName(this ControllerBase controller)
        {
            //TODO: change line below
            return "System";
            return controller.HttpContext.User.Claims.Where(w => w.Type == ClaimTypes.Name)
                .FirstOrDefault().Value;
        }
    }
}
