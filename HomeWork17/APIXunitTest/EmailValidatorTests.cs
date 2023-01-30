using API.Services;
using System;
using Xunit;

namespace APIXunitTest
{
    public class EmailValidatorTests
    {
        [Theory]
        [InlineData("iasjd@org.com")]
        [InlineData("i@tech.com")]
        [InlineData("takeda@knu.ua")]
        [InlineData("asdji@gmai.com")]
        public void IsValidEmail_ValidEmail_ReturnsTrue(string email)
        {
            EmailValidator emailValidator = new EmailValidator();

            var result = emailValidator.IsValid(email);

            Assert.True(result);
        }

        [Theory]
        [InlineData("iasjd@")]
        [InlineData("i@.com")]
        [InlineData("takeda@kn u.ua")]
        [InlineData("@gmai.com")]
        public void IsValidEmail_InvalidEmail_ReturnsFalse(string email)
        {
            EmailValidator emailValidator = new EmailValidator();

            var result = emailValidator.IsValid(email);

            Assert.False(result);
        }

        [Fact]
        public void IsValidEmail_NullEmail_ThrowsException()
        {
            EmailValidator emailValidator = new EmailValidator();

            Assert.Throws<ArgumentNullException>(() => emailValidator.IsValid(null));
        }
    }
}
