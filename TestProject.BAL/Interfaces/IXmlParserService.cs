using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace TestProject.BAL.Interfaces
{
	public interface IXmlParserService
	{
		void ParseAndSaveToDB(IFormFile xmlFile);
	}
}
