using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TestProject.Models
{
	public class FileUpload
	{
		[Required]
		public IFormFile UploadXmlFile { get; set; }
	}
}
