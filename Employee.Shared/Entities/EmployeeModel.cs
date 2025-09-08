using System.ComponentModel.DataAnnotations;

namespace Employee.Shared.Entities
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Display(Name = "Nombres")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Apellidos")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "Estado")]
        public bool IsActive { get; set; }

        [Display(Name = "Fecha")]
        public DateTime HireDate { get; set; }

        [Display(Name = "Salario")]
        [Range(1000000, double.MaxValue, ErrorMessage = "El valor mínimo debe ser de 1.000.000")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Salary { get; set; }
    }
}
