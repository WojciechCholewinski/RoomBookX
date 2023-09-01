using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomBookX.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Display(Name = "Imię rezerwującego"), StringLength(60, MinimumLength = 3, ErrorMessage = "Wpisz prawdziwe imię!"), RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "Imię powinno rozpoczynać się wielką literą i nie posiadać znaków specjalnych."), Required(ErrorMessage = "Pole imię jest wymagane.")]
        public string CustomerName { get; set; }

        [Display(Name = "Nazwisko rezerwującego"), StringLength(60, MinimumLength = 3, ErrorMessage = "Wpisz prawdziwe nazwisko!"), RegularExpression(@"^[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]*$", ErrorMessage = "Nazwisko powinno rozpoczynać się wielką literą i nie posiadać znaków specjalnych."), Required(ErrorMessage = "Pole nazwisko jest wymagane.")]
        //^[A-Z][a-z]*$
        public string CustomerSurname { get; set; }


        [Display(Name = "Numer pokoju"), StringLength(5, MinimumLength = 1, ErrorMessage = "Wpisz numer pokoju!"), RegularExpression(@"^\d+[a-zA-Z]?$", ErrorMessage = "Numer pokoju to liczba, fakultatywnie z literą."), Required(ErrorMessage = "Pole nr pokoju jest wymagane.")]
        public string RoomNumber { get; set; }

        [Display(Name = "Powierzchnia")]
        [Range(10, int.MaxValue, ErrorMessage = "Niestety nie posiadamy sal o powierzchni mniejszej niż 10m².")]
        public int? Capacity { get; set; }
        //public ICollection<Reservation>? Reservations { get; set; }

        [Range(typeof(decimal), "1", "999", ErrorMessage = "Aktualny cennik jest z zakresu 1zł-999zł i składa się z cen zaokrąglonych do pełnych złotówek.")]
        [Display(Name = "Cena"), Required(ErrorMessage = "Pole Cena jest wymagane.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }


        [Display(Name = "Data rozpoczęcia"), Required(ErrorMessage = "Musisz podać datę rozpoczęcia podnajmu sali.")]
        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }

        [Display(Name = "Data zakończenia")]
        [DataType(DataType.Date)]
        public DateTime? EndTime { get; set; }
        
    }
}
