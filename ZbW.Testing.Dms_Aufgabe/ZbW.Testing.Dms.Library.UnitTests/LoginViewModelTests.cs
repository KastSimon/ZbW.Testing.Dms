using ZbW.Testing.Dms.Client.Views;

namespace ZbW.Testing.Dms.Library.UnitTests
{
    using NUnit.Framework;
    using ZbW.Testing.Dms.Client.ViewModels;

    [TestFixture]
    class LoginViewModelTests
    {

        [Test]
        public void OnCanLogin_ValideUserName_RetrunsTrue()
        {
            // arrange
            var loginViewModel = new LoginViewModel(new LoginView());

            // act
            var result = loginViewModel.CmdLogin.CanExecute();

            // assert
            Assert.That(result, Is.True);
        }

    }
}
