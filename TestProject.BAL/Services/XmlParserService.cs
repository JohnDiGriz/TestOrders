using System;
using System.Collections.Generic;
using System.Text;
using TestProject.BAL.Interfaces;
using TestProject.DAL.Interfaces;
using TestProject.DAL.Models;
using Microsoft.AspNetCore.Http;
using System.Xml;
using System.Globalization;
using System.IO;

namespace TestProject.BAL.Services
{
	public class XmlParserService : IXmlParserService
	{
		private readonly IUnitOfWork Unit;
		public XmlParserService(IUnitOfWork unitOfWork)
		{
			Unit = unitOfWork;
		}
		private BillingAddresses ParseAdress(XmlNode orderRoot, long orderId)
		{
			return new BillingAddresses()
			{
				Email = orderRoot.SelectSingleNode("billingaddress/billemail").InnerText,
				Fullname = orderRoot.SelectSingleNode("billingaddress/billfname").InnerText,
				Street = orderRoot.SelectSingleNode("billingaddress/billstreet").InnerText,
				HomeNumber = short.Parse(orderRoot.SelectSingleNode("billingaddress/billstreetnr").InnerText),
				City = orderRoot.SelectSingleNode("billingaddress/billcity").InnerText,
				Country = orderRoot.SelectSingleNode("billingaddress/country/geo").InnerText,
				Zip = int.Parse(orderRoot.SelectSingleNode("billingaddress/billzip").InnerText),
				OrderOxId = orderId
			};
		}
		private Payments ParsePayment(XmlNode paymentsRoot, long orderId)
		{
			var provider = new CultureInfo("en-US");
			return new Payments()
			{
				MethodName = paymentsRoot.SelectSingleNode("method-name").InnerText,
				Amount = decimal.Parse(paymentsRoot.SelectSingleNode("amount").InnerText, provider),
				OrderOxId = orderId
			};
		}
		private Articles ParseArticle(XmlNode articlesRoot, long orderId)
		{
			var provider = new CultureInfo("en-US");
			return new Articles()
			{
				Nomenclature = long.Parse(articlesRoot.SelectSingleNode("artnum").InnerText),
				Title = articlesRoot.SelectSingleNode("title").InnerText,
				Amount = int.Parse(articlesRoot.SelectSingleNode("amount").InnerText),
				BrutPrice = double.Parse(articlesRoot.SelectSingleNode("brutprice").InnerText, provider),
				OrderOxId = orderId
			};
		}
		public void ParseAndSaveToDB(IFormFile xmlFile)
		{
			var doc = new XmlDocument();
			var filePath = Path.GetTempFileName();
			using (var stream = xmlFile.OpenReadStream())
			{
				doc.Load(stream);
				List<Orders> orders = new List<Orders>();
				List<BillingAddresses> addresses = new List<BillingAddresses>();
				List<Articles> articles = new List<Articles>();
				List<Payments> payments = new List<Payments>();
				foreach (XmlNode order in doc.SelectNodes("//orders/order"))
				{
					var orderModel = new Orders()
					{
						OxId = long.Parse(order.SelectSingleNode("oxid").InnerText),
						OrderDatetime = DateTime.Parse(order.SelectSingleNode("orderdate").InnerText)
					};
					addresses.Add(ParseAdress(order, orderModel.OxId));
					foreach(XmlNode payment in order.SelectNodes("payments/payment"))
					{
						payments.Add(ParsePayment(payment, orderModel.OxId));
					}
					foreach(XmlNode article in order.SelectNodes("articles/orderarticle"))
					{
						articles.Add(ParseArticle(article, orderModel.OxId));
					}
					orders.Add(orderModel);
				}
				Unit.Adresses.AddRange(addresses);
				Unit.Articles.AddRange(articles);
				Unit.Payments.AddRange(payments);
				Unit.Orders.AddRange(orders);
				Unit.Commit();
			}
		}
	}
}
