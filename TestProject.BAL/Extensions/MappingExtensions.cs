using System;
using System.Collections.Generic;
using System.Text;
using TestProject.BAL.ViewModels;
using TestProject.DAL.Models;
using System.Linq;

namespace TestProject.BAL.Extensions
{
	public static class MappingExtensions
	{
		public static ArticleViewModel ToViewModel(this Articles article)
		{
			return new ArticleViewModel()
			{
				Nomenclature = article.Nomenclature,
				Title = article.Title,
				Amount = article.Amount,
				BrutPrice = article.BrutPrice
			};
		}
		public static PaymentViewModel ToViewModel(this Payments payment)
		{
			return new PaymentViewModel()
			{
				Amount = payment.Amount,
				MethodName = payment.MethodName
			};
		}
		public static BillingAdressViewModel ToViewModel(this BillingAddresses billingAddress)
		{
			return new BillingAdressViewModel()
			{
				Email = billingAddress.Email,
				Fullname = billingAddress.Fullname,
				Street = billingAddress.Street,
				HomeNumber = billingAddress.HomeNumber,
				City = billingAddress.City,
				Country = billingAddress.Country,
				Zip = billingAddress.Zip
			};
		}
		public static OrderViewModel ToViewModel(this Orders order)
		{
			return new OrderViewModel()
			{
				OxId = order.OxId,
				OrderDatetime = order.OrderDatetime,
				BillingAddresses = order.BillingAddresses.ToViewModel(),
				Payments = order.Payments.Select(x => x.ToViewModel()).ToList(),
				Articles = order.Articles.Select(x => x.ToViewModel()).ToList(),
				OrderStatus = order.OrderStatusNavigation?.Name,
				InvoiceNumber = order.InvoiceNumber
			};
		}
	}
}
