using TransportManagementSystem.Models;

namespace TransportManagementSystem.Validators
{
    public class ReservationValidator
    {
        public List<string> Validate(Reservation reservation)
        {
            var errors = new List<string>();

            if (reservation == null)
            {
                errors.Add("La reservation est obligatoire.");
                return errors;
            }

            if (reservation.Client == null)
            {
                errors.Add("Le client de la reservation est obligatoire.");
            }

            if (reservation.Horaire == null)
            {
                errors.Add("L'horaire de la reservation est obligatoire.");
            }

            if (reservation.NumSiege <= 0)
            {
                errors.Add("Le numero de siege doit etre positif.");
            }

            if (string.IsNullOrWhiteSpace(reservation.Statut))
            {
                errors.Add("Le statut de la reservation est obligatoire.");
            }
            else if (reservation.Statut.Trim().Length > 50)
            {
                errors.Add("Le statut de la reservation ne doit pas depasser 50 caracteres.");
            }

            if (reservation.DateReservation == default)
            {
                errors.Add("La date de reservation est obligatoire.");
            }
            else if (reservation.DateReservation > DateOnly.FromDateTime(DateTime.Today))
            {
                errors.Add("La date de reservation ne peut pas etre future.");
            }

            return errors;
        }
    }
}
