using Microsoft.AspNetCore.Mvc;
namespace Calculator.Models;

public class CalcController : Controller
{
    public IActionResult Index()
    {
        return View(new Calculator());
    }

    [HttpGet]
    public ViewResult RsvpForm()
    {
        return View();
    }

    [HttpPost]
    public ViewResult Calculate(Calculator calc, string action)
    {
        if (action == "clear")
        {
            ModelState.Clear();
            return View("Index", new Calculator());
        }

        if (!ModelState.IsValid)
        {
            return View("Index", calc);
        }

        switch (calc.operation)
        {
            case "+":
                calc.result = calc.operand1 + calc.operand2;
                break;

            case "-":
                calc.result = calc.operand1 - calc.operand2;
                break;

            case "*":
                calc.result = calc.operand1 * calc.operand2;
                break;

            case "/":
                calc.result = calc.operand1 / calc.operand2;
                break;
        }

        ViewBag.WantResult = 212;

        string operationstr = $"{calc.operand1} {calc.operation} {calc.operand2} = {calc.result}";

        HttpContext.Session.SetString("LastOperation", operationstr);

        return View("Index", calc);
    }
    public IActionResult IndexLink()
    {
        ViewBag.LastOperation = HttpContext.Session.GetString("LastOperation");
        return View("IndexLink");
    }
}
