using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_LABA5.Models;
using TP_LABA5.Helpers;

namespace TP_LABA5.Controllers
{
    public class DrugFarmController : Controller
    {
        //×ÀÑÒÜ 2: ìàññèâ
        private static DrugFarmModel[] drugs = new DrugFarmModel[100];
        private static bool isInitialized = false;

        //×ÀÑÒÜ 2: êóêèñû
        private void InitializeDefaultDrugs()
        {
            if (!isInitialized)
            {
                var mockDrugs = DrugHelper.GetMockDrugList();
                for (int i = 0; i < mockDrugs.Count; i++)
                {
                    drugs[i] = mockDrugs[i];
                    CurrentIndex = Math.Max(CurrentIndex, mockDrugs[i].DrugId);
                }
                isInitialized = true;
            }
        }
        private int CurrentIndex
        {
            get
            {
                int index = 0;
                if (Request.Cookies.ContainsKey("CurrentIndex"))
                {
                    int.TryParse(Request.Cookies["CurrentIndex"], out index);
                }
                return index;
            }
            set
            {
                Response.Cookies.Append("CurrentIndex", value.ToString());
            }
        }

        // GET: FarmController1
        //ViewData
        public ActionResult Index()
        {
            InitializeDefaultDrugs(); 
            var drugList = drugs.Where(d => d != null).ToList();

            ViewData["UseInternalMethod"] = true;
            return View(drugList);
        }

        // GET: FarmController1/Details/5
        public ActionResult Details(int id)
        {
            var drug = drugs.FirstOrDefault(d => d != null && d.DrugId == id);
            if (drug == null)
            {
                return NotFound();
            }
            return View(drug);
        }

        // GET: FarmController1/Create
        public ActionResult Create()
        {
            return View(new DrugFarmModel());
        }

        // POST: FarmController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DrugFarmModel model)
        {
            if (ModelState.IsValid)
            {
                model.DrugId = CurrentIndex + 1;
                drugs[CurrentIndex] = model;
                CurrentIndex++;
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: FarmController1/Red/5
        public ActionResult Red(int id)
        {
            var drug = drugs.FirstOrDefault(d => d != null && d.DrugId == id);
            if (drug == null)
            {
                return NotFound();
            }
            return View(drug);
        }

        // GET: DrugFarm/ViewCookies
        public ActionResult ViewCookies()
        {
            var cookieData = new Dictionary<string, string>();

            foreach (var cookie in Request.Cookies)
            {
                cookieData.Add(cookie.Key, cookie.Value);
            }

            return View(cookieData);
        }

        // POST: FarmController1/Red/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Red(int id, DrugFarmModel model)
        {
            if (ModelState.IsValid)
            {
                int index = Array.FindIndex(drugs, d => d != null && d.DrugId == id);
                if (index != -1)
                {
                    model.DrugId = id;
                    drugs[index] = model;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: FarmController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FarmController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
