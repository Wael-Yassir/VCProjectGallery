using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VCProjectGallery.Data.Base;
using VCProjectGallery.Models;
using VCProjectGallery.Models.Project;
using Microsoft.EntityFrameworkCore;
using VCProjectGallery.Models.Base;
using Microsoft.AspNetCore.Authorization;
using VCProjectGallery.API.Authentication;
using Microsoft.AspNetCore.JsonPatch;

namespace VCProjectGallery.Data.Controllers
{
	[Authorize]
    public class ProjectsController : ApiBaseController<Project>
    {

        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

		[AllowAnonymous]
        public override object Get()
		{
			return base.Get();
		}


		[AllowAnonymous]
		public override ActionResult<Project> Get(Guid key)
		{
			return base.Get(key);
		}
	}
}
