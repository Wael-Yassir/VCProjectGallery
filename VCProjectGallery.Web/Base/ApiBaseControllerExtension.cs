using Microsoft.AspNetCore.Mvc;
using System;
using VCProjectGallery.Models.Base;

namespace VCProjectGallery.Web.Base
{
	public static class ApiBaseControllerExtension
	{
		public static void SetCreatedByUser(this ControllerBase controller, PublicBaseClass entity)
		{
			entity.CreatedByID = controller.GetUserID();
			entity.CreatedByName = controller.GetUserName();
			entity.CreatedOn = DateTime.UtcNow;
		}

		public static void SetDeletedByUser(this ControllerBase controller, PublicBaseClass entity)
		{
			entity.IsDeleted = true;
			entity.DeletedByID = controller.GetUserID();
			entity.DeletedByName = controller.GetUserName();
			entity.DeletedOn = DateTime.UtcNow;
		}

		public static void SetUpdatedByUser(this ControllerBase controller, PublicBaseClass entity)
		{
			entity.UpdatedByID = controller.GetUserID();
			entity.UpdatedByName = controller.GetUserName();
			entity.UpdatedOn = DateTime.UtcNow;
		}
	}
}
