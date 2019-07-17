using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.BAL.ViewModels
{
	public class OrderViewModel
	{
		public OrderViewModel()
		{
			Articles = new List<ArticleViewModel>();
			Payments = new List<PaymentViewModel>();
		}

		public long OxId { get; set; }
		public DateTime OrderDatetime { get; set; }
		public int? InvoiceNumber { get; set; }

		public virtual string OrderStatus { get; set; }
		public virtual BillingAdressViewModel BillingAddresses { get; set; }
		public virtual List<ArticleViewModel> Articles { get; set; }
		public virtual List<PaymentViewModel> Payments { get; set; }
	}
}
