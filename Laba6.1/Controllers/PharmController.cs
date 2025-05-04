using Microsoft.AspNetCore.Mvc;
using System;

namespace laba6._1.Controllers
{
    public class PharmController : Controller, IController
    {
        //В методе Execute(), проверив, что название метода действия – «start», а значение переменной id – 0, выполнить переход на метод Index() обычного контроллера.
        public IActionResult Execute()
        {
            string controller = (string)RouteData.Values["controller"];
            string action = (string)RouteData.Values["action"];
            string id = RouteData.Values["id"]?.ToString();

            if (Request.Path.Value.Contains("start") && id == "0")
            {
                return RedirectToRoute(new { action = "Index", controller = "Pharm" });
            }
            // Если условия не выполняются, вывести сообщение об ошибке, а также(с новой строки) полный URL(использовать контекстный объект Request.Url). 
            Response.WriteAsync($"Error: {Request.Path}");

            return new EmptyResult();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int? productId, string productName, DateTime? productionDate, string form)
        {
            //вывести их в ещё одном представлении, передав значения с помощью объекта ViewBag, если числовой идентификатор не пустой.(частично из параметров метода действия, частично с помощью контекстного объекта Request.Form)
            if (productId.HasValue)
            {
                decimal price = 0;
                decimal.TryParse(Request.Form["price"], out price);

                bool isAvailable = Request.Form["isAvailable"].Count > 0;

                ViewBag.ProductId = productId;
                ViewBag.ProductName = productName;
                ViewBag.ProductionDate = productionDate;
                ViewBag.Form = form;
                ViewBag.Price = price;
                ViewBag.IsAvailable = isAvailable;

                return View("Result");
            }
            else
            //Иначе выполнить перенаправление снова на метод действия Index(), используя метод RedirectToAction()(вариант 1)
            {
                return RedirectToAction("Index");
            }
        }
    }
}