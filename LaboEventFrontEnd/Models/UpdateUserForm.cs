using System.ComponentModel.DataAnnotations;

namespace LaboEventFrontEnd.Models
{
    public class UpdateUserForm
    {
        [Required(ErrorMessage = "Le champ 'Email' est obligatoire.")]
        [EmailAddress(ErrorMessage = "Veuillez entrer une adresse mail valide.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le champ 'Nom' est obligatoire.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Le champ 'Prénom' est obligatoire.")]
        public string LastName { get; set; }

    }
}
