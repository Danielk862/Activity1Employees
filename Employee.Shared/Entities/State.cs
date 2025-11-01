using Employee.Shared.Interface;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Employee.Shared.Entities
{
    public class State : IEntityWithName
    {
        public int Id { get; set; }

        [Display(Name = "Estado")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        public int CountryId { get; set; }

        public Country? Country { get; set; }

        public ICollection<City>? Cities { get; set; }

        [DisplayName("Ciudades")]
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;
    }
}
