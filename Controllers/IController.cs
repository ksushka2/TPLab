// интерфейс IController
using Microsoft.AspNetCore.Mvc;

namespace laba6._1.Controllers
{
    public interface IController
    {
        IActionResult Execute();
    }
}