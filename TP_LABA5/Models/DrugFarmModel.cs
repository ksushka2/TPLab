//Фармацевтическая компания - лекарства
//ЧАСТЬ 1: 6 свойств, 3 разных типа, DisplayName, DataType, MultilineText
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TP_LABA5.Models
{
    public class DrugFarmModel
    {
        [DisplayName("Id")]
        public int DrugId { get; set; }

        [DisplayName("Название")]
        [Required(ErrorMessage = "Поле Название обязательно для заполнения")]
        public string DrugName { get; set; }

        [DisplayName("Форма выпуска")]
        public string FormPack { get; set; }

        [DisplayName("Номер упаковки")]
        public int PackId { get; set; }

        [DisplayName("Дата производства")]
        [DataType(DataType.MultilineText)]
        public DateOnly ProductionDate { get; set; }

        [DisplayName("Стоимость")]
        public decimal Price { get; set; }
    }
}
