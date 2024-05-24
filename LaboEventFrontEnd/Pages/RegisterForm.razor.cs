using LaboEventFrontEnd.Models;
using System.ComponentModel.DataAnnotations;

namespace LaboEventFrontEnd.Pages
{
    public partial class RegisterForm
    {
        public RegisterUserForm MyForm { get; set; }

        protected override void OnInitialized()
        {
            MyForm = new RegisterUserForm();
        }
        public async Task OnSubmitForm()
        {
            
        }

    }
}
