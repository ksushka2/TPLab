//ЧАСТЬ 3: внешний вспомогательный метод

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using TP_LABA5.Models;


namespace TP_LABA5.Helpers
{
    public static class DrugHelper
    {
        public static HtmlString ExternalDrugList(List<DrugFarmModel> drugs)
        {
            var result = "<table class='table'><thead><tr>" +
                  "<th>Номер</th>" +
                  "<th>Название</th>" +
                  "<th>Форма выпуска</th>" +
                  "<th>Номер упаковки</th>" +
                  "<th>Дата производства</th>" +
                  "<th>Стоимость</th>" +
                  "<th>Действия</th>" +
                  "</tr></thead><tbody>";
            int i = 0;
            while (i < drugs.Count)
            {
                var drug = drugs[i];
                result += $"<tr>" +
                   $"<td>{drug.DrugId}</td>" +
                   $"<td>{drug.DrugName}</td>" +
                   $"<td>{drug.FormPack}</td>" +
                   $"<td>{drug.PackId}</td>" +
                   $"<td>{drug.ProductionDate}</td>" +
                   $"<td>{drug.Price}</td>" +
                   $"<td>" +
                   $"<a href='/DrugFarm/Details/{drug.DrugId}' class='btn btn-secondary'>Просмотр</a> " +
                   $"<a href='/DrugFarm/Red/{drug.DrugId}' class='btn btn-primary'>Редактировать</a>" +
                   $"</td></tr>";
                i++;
            }

            result += "</tbody></table>";
            return new HtmlString(result);
        }

        public static List<DrugFarmModel> GetMockDrugList()
        {
            var drugs = new List<DrugFarmModel>
            {
                new DrugFarmModel
                {
                    DrugId = 1,
                    DrugName = "Ринза",
                    FormPack = "Таблетки",
                    PackId = 101,
                    ProductionDate = DateOnly.FromDateTime(new DateTime(2024, 1, 1)),
                    Price = 150.50m
                },
                new DrugFarmModel
                {
                    DrugId = 2,
                    DrugName = "Гилан",
                    FormPack = "Капли",
                    PackId = 102,
                    ProductionDate = DateOnly.FromDateTime(new DateTime(2024, 3, 1)),
                    Price = 420.00m
                }
            };
            return drugs;
        }
    }
}