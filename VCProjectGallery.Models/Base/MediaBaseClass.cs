using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace VCProjectGallery.Models.Base
{
	public abstract class MediaBaseClass : PublicBaseClass
	{
		protected MediaBaseClass() : base()
		{ }

		public virtual string FileName { get; set; }

		public virtual string Extension { get; set; }

		public virtual string Revision { get; set; }

		public virtual string Path { get; set; }

		public virtual long FileSize { get; set; }

		[NotMapped]
		public virtual byte[] FileBytes { get; set; }

		[NotMapped]
		public virtual IFormFile FormFile { get; set; }
	}
}
