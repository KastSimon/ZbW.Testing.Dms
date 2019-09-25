using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Library.UnitTests
{
    using FakeItEasy;
    using NUnit.Framework;
    using ZbW.Testing.Dms.Client.Model;
    using ZbW.Testing.Dms.Client.Services;
    using ZbW.Testing.Dms.Client.Services.Interface;
    using ZbW.Testing.Dms.Client.ViewModels;
    using ZbW.Testing.Dms.Client.Views;

    [TestFixture, RequiresSTA]
    public class LoginViewTest
    {

        [Test]
        public void LoginView_canLogin_RetrunTrue()
        {
            // arrange
            LoginView loginView = new LoginView();
            LoginViewModel loginViewModel = new LoginViewModel(loginView);
            loginViewModel.Benutzername = "TestUser";

            // act
            bool canLogin = loginViewModel.OnCanLogin();

            // assert
            Assert.That(canLogin, Is.True);

        }

    }
}
