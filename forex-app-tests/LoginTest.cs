using forex_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace forex_app_tests
{
    public class LoginTest
    {
        [Fact]
        public void EmptyFieldsLoginTest()
        {
            var login = new LoginModel();
            var data = new Login();
            data.ClientId = "";
            data.UserId = "";
            data.Password = "";

            
            Assert.False(login.isValidLogin(data));
        }

        [Fact]
        public void InvalidLoginTest()
        {
            var login = new LoginModel();
            var data = new Login();
            data.ClientId = "ert555";
            data.UserId = "2rgfgf";
            data.Password = "rrtrtr";


            Assert.False(login.isValidLogin(data));
        }

        [Fact]
        public void ValidLoginTest()
        {
            var login = new LoginModel();
            var data = new Login();
            data.ClientId = "C14557";
            data.UserId = "USER23";
            data.Password = "ExamplePw";


            Assert.True(login.isValidLogin(data));
        }

        [Fact]
        public void SuccessfullLoginTest()
        {
            var login = new LoginModel();
            var data = new Login();
            data.ClientId = "C14557";
            data.UserId = "USER23";
            data.Password = "ExamplePw";

            var result = login.OnPost(data) as RedirectToPageResult;

            Assert.NotNull(result);
            Assert.Equal("/Home", result.PageName);
        }
    }
}