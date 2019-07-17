using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.BAL.ViewModels
{
	public class BillingAdressViewModel
	{
		public string Email { get; set; }
		public string Fullname { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public string Street { get; set; }
		public short HomeNumber { get; set; }
		public int Zip { get; set; }
	}
}
