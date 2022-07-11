using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCProjectGallery.Models.Project;

namespace VCProjectGallery.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Project> Projects { get; set; }
		public DbSet<ProjectImage> ProjectImages { get; set; }
	}
}
