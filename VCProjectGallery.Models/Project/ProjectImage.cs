using System;
using System.ComponentModel.DataAnnotations.Schema;
using VCProjectGallery.Models.Base;

namespace VCProjectGallery.Models.Project
{
	public class ProjectImage : MediaBaseClass
	{
		public Guid ProjectID { get; set; }
		
		[ForeignKey(nameof(ProjectID))]
		public Project Project { get; set; }
	}
}
