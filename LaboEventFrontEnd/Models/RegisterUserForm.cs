using System.ComponentModel.DataAnnotations;

namespace LaboEventFrontEnd.Models
{
    public class RegisterUserForm
    {
        [Required(ErrorMessage = "Le champ 'Email' est obligatoire.")]
        [EmailAddress(ErrorMessage = "Veuillez entrer une adresse mail valide.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le champ 'Nom' est obligatoire.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Le champ 'Prénom' est obligatoire.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Le champ 'Mot de passe' est obligatoire.")]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$",
            ErrorMessage = "Doit contenir une majuscule et 8 characteres ")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Le champ 'Confirmation de mot de passe' est obligatoire.")]
        [Compare(nameof(Password), ErrorMessage = "Les deux mots de passe doivent correspondre")]
        public string PasswordConfirm { get; set; }
    }
}
