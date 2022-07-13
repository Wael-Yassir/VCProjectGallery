using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCProjectGallery.Models.Base;

namespace VCProjectGallery.Models.Project
{
	public class Project : PublicBaseClass
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }

		public DateTime? FinishedOn { get; set; }

		public string Client { get; set; }

		public string Location { get; set; }

		public long? Budget { get; set; }

		public string BudgetCurrency { get; set; }

		public List<ProjectImage> ProjectImages { get; set; }
	}
}
