using System.ComponentModel.DataAnnotations;
//sbyte, decimal, RadioButton,  _ViewStart.cshtml, Compare, ValidationSummary(), состояние сеанса (класс Session), IndexOf, Remove(), Insert(). 
namespace Calculator.Models

{
    public class Calculator
    {
        [Required(ErrorMessage ="Value is invalid!")]
        public decimal operand1 { get; set; }
        //[Compare("operand1", ErrorMessage ="Operands must not be equal!")]
        [Required(ErrorMessage = "Value is invalid!")]
        public sbyte operand2 { get; set; }
        public decimal result { get; set; }
        public string operation { get; set; }
    }
}
