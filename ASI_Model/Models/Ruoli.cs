namespace Electro.Domain.Models
{
    public class Ruoli
    {
        private enum Role
        {
            Owner,
            Admin,
            Technician,
            User
        }

        public string Owner => Role.Owner.ToString();
        public string Admin => Role.Admin.ToString();
        public string Tech => Role.Technician.ToString();
        public string User => Role.User.ToString();
    }
}
