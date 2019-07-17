using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.BAL.ViewModels
{
	public class ArticleViewModel
	{
		public long Nomenclature { get; set; }
		public string Title { get; set; }
		public int Amount { get; set; }
		public double BrutPrice { get; set; }
	}
}
