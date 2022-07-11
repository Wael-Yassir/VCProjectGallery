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

namespace VCProjectGallery.Data.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ApiBaseController<Project>
    {

        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
