using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VCProjectGallery.Models.Base
{
	public abstract class PublicBaseClass
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid ID { get; set; } = Guid.NewGuid();

		[Required]
		[MaxLength(127)]
		public virtual string CreatedByName { get; set; } = "System";

		public virtual Guid? CreatedByID { get; set; }

		[Required]
		[Column(TypeName = "DateTime2")]
		public virtual DateTime CreatedOn { get; set; } = DateTime.UtcNow;

		[MaxLength(127)]
		public virtual string UpdatedByName { get; set; }

		public virtual Guid? UpdatedByID { get; set; }

		[Column(TypeName = "DateTime2")]
		public virtual DateTime? UpdatedOn { get; set; } = DateTime.UtcNow;

		[MaxLength(127)]
		public virtual string DeletedByName { get; set; }

		public virtual Guid? DeletedByID { get; set; }

		[Column(TypeName = "DateTime2")]
		public virtual DateTime? DeletedOn { get; set; } = DateTime.UtcNow;

		public virtual bool IsDeleted { get; set; } = false;
	}
}
