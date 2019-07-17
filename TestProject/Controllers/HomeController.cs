using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TestProject.BAL.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestProject
{
	public class HomeController : Controller
	{
		private readonly IXmlParserService ParserService;
		private readonly IOrdersService OrdersService;
		public HomeController(IXmlParserService parserService, IOrdersService ordersService)
		{
			ParserService = parserService;
			OrdersService = ordersService;
		}
		// GET: /<controller>/
		public IActionResult Index()
		{
			var model = OrdersService.GetOrders();
			return View(model);
		}
		public IActionResult UploadXml()
		{
			return View();
		}

		[HttpPost("SaveChanges")]
		public IActionResult SaveChanges(TestProject.BAL.ViewModels.OrdersListViewModel model)
		{
			if(ModelState.IsValid)
			{
				OrdersService.ApplyChanges(model);
			}
			return RedirectToAction("Index", "Home");
		}

		[HttpPost("Upload")]
		public IActionResult Upload(TestProject.Models.FileUpload xmlModel)
		{
			try
			{
				ParserService.ParseAndSaveToDB(xmlModel.UploadXmlFile);
				return RedirectToAction("Index", "Home");
			}
			catch (Exception ex)
			{
				return View("Error");
			}
		}

		[HttpGet("Search")]
		public IActionResult Search(TestProject.BAL.ViewModels.OrdersListViewModel model)
		{
			if(!string.IsNullOrEmpty(model.SearchLine))
			{
				var newModel = OrdersService.GetOrders(x => x.OxId.ToString().Contains(model.SearchLine));
				return View("Index", newModel);
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}
	}
}
