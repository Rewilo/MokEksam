using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using MokEksam.Common;
using MokEksam.Handler;
using MokEksam.Common.Custom_Attributes;
using Prism.Windows.Validation;

namespace MokEksam.ViewModel
{
    /// <summary>
    /// Klassen er til for at indføre MVVM-struktur til applikationen.
    /// Der er sat DataContext til CreateUser.xaml, hvortil properties er bundet til forskellige elementer i CreateUser.xaml.
    /// Der bruges Prism.Windows for at give responsive fejlbeskeder til bruger ved inputtet, der ikke følger kravene.
    /// </summary>
    class EndUserViewModel : ValidatableBindableBase
    {
        private string _username;
        private string _password;
        private string _confirmPassword;
        private string _email;
        private ICommand _navigateToLoginCommand;
        private ICommand _createUserCommand;
        
        /// <summary>
        /// ValidationAttribute tilbyder en metoder kaldet SetProperty(ref object, string value).
        /// Denne metode kalder IsValid() i klasserne UsernameOnlyLettersAttribute og EnduserExistAttribute.
        /// </summary>
        [Required(ErrorMessage = "Name must be entered")]
        [StringLength(25, ErrorMessage = "Username must hold between 4 and 25 character", MinimumLength = 4)]
        [UsernameOnlyLettters(ErrorMessage = "Username can only consist of small and capital letters")]
        [EndUserExist(ErrorMessage = "Username exist and therefor username is invalid")]
        public string Username
        {
            get { return _username; }
            set
            {
                SetProperty(ref _username, value);
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// ValidationAttribute tilbyder en metoder kaldet SetProperty(ref object, string value).
        /// Denne metode kalder IsValid() i klassen PasswordAttribute.
        /// Hvis værdien valideres, så sættes et statisk felt i CreateEndUserHandler for at kunne 
        /// sammeligne Password og ConfirmPassword.
        /// </summary>
        [Required(ErrorMessage = "Password must be entered")]
        [StringLength(int.MaxValue, ErrorMessage = "Username must hold between 8 and 25 character", MinimumLength = 8)]
        [Password(ErrorMessage = "Password must contains at least one special character and alpha numeric number")]
        public string Password
        {
            get { return _password; }
            set
            {
                SetProperty(ref _password, value);
                CreateEndUserHandler.PasswordToConfirm = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// ValidationAttribute tilbyder en metoder kaldet SetProperty(ref object, string value).
        /// Denne metode kalder IsValid() i klassen PasswordAttribute.
        /// </summary>
        [Required(ErrorMessage = "You must confirm password")]
        [ConfirmPassword(ErrorMessage = "Passwords are not alike")]
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                SetProperty(ref _confirmPassword, value);
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// ValidationAttribute tilbyder en metoder kaldet SetProperty(ref object, string value).
        /// Denne metode kalder IsValid() i klassen EmailAttribute.
        /// </summary>
        [Required(ErrorMessage = "Email must be entered")]
        [Email(ErrorMessage = "Email is not valid in this context")]
        public string Email
        {
            get { return _email; }
            set
            {
                SetProperty(ref _email, value);
                OnPropertyChanged();
            }
        }

        // Oprettelse af reference til at kunne tilgå metoder og logik, såsom metoder til Command-properties.
        private CreateEndUserHandler Handler { get; }

        // Instanstiering af objekt af typen ICommand, som bindes til en knap i CreateUser.xaml.
        // Hvis referene ikke refererer til et objekt, oprettes et nyt (Eager-princip).
        public ICommand NavigateToLoginCommand => _navigateToLoginCommand ?? (_navigateToLoginCommand = new RelayCommand(Handler.NavigateToLogin));

        // Instanstiering af objekt af typen ICommand, som bindes til en knap i CreateUser.xaml.
        // Hvis referene ikke refererer til et objekt, oprettes et nyt (Eager-princip).
        public ICommand CreateUserCommand => _createUserCommand ?? (_createUserCommand = new RelayCommand(Handler.CreateUser));
        
        /// <summary>
        /// Instanstiering af Handler, som i dens konstruktør referer til nuværende objekt CreateEndUserViewModel.
        /// </summary>
        public EndUserViewModel()
        {
            Handler = new CreateEndUserHandler(this);
        }
        
    }
}
