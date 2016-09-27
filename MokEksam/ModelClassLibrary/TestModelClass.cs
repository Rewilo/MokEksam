using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModelClassLibrary
{
    [TestClass]
    public class TestModelClass
    {
        EndUser myEndUser = new EndUser("Rasmus", "pzxftv1!", "miniblufii@hotmail.com");

        [TestMethod]
        public void TestCreateUser()
        {
            // Arrange

            //Act

            //Assert
            Assert.AreEqual("Rasmus", myEndUser.Username);
            Assert.AreEqual("pzxftv1!", myEndUser.Password);
            Assert.AreEqual("miniblufii@hotmail.com", myEndUser.Email);
        }
        
        [TestMethod]
        public void TestShortUsernameExceptionMessage()
        {
            try
            {
                //Arrange
                myEndUser.Username = "";
                Assert.Fail();
            }
            // Act
            catch (ArgumentException exception)
            {
                // Assert
                Assert.AreEqual("Invalid Username", exception.Message);
            }
        }

        [TestMethod]
        public void TestLongUsernameExceptionMessage()
        {
            try
            {
                //Arrange
                myEndUser.Username = "ABCABCABCABCABCABCABCABCABC";
                Assert.Fail();
            }
            // Act
            catch (ArgumentException exception)
            {
                // Assert
                Assert.AreEqual("Invalid Username", exception.Message);
            }
        }

        [TestMethod]
        public void TestInvalidUsernameExceptionMessage()
        {
            try
            {
                //Arrange
                myEndUser.Username = "12345";
                Assert.Fail();
            }
            // Act
            catch (ArgumentException exception)
            {
                // Assert
                Assert.AreEqual("Invalid Username", exception.Message);
            }
        }

        [TestMethod]
        public void TestShortPasswordExceptionMessage()
        {
            try
            {
                //Arrange
                myEndUser.Password = "Abcde1!";
                Assert.Fail();
            }
            // Act
            catch (ArgumentException exception)
            {
                // Assert
                Assert.AreEqual("Invalid Password", exception.Message);
            }
        }

        [TestMethod]
        public void TestInvalidPasswordExceptionMessage1()
        {
            try
            {
                //Arrange
                myEndUser.Password = "abcdefgh";
                Assert.Fail();
            }
            // Act
            catch (ArgumentException exception)
            {
                // Assert
                Assert.AreEqual("Invalid Password", exception.Message);
            }
        }

        [TestMethod]
        public void TestInvalidPasswordExceptionMessage2()
        {
            try
            {
                //Arrange
                myEndUser.Password = "Abcdefgh";
                Assert.Fail();
            }
            // Act
            catch (ArgumentException exception)
            {
                // Assert
                Assert.AreEqual("Invalid Password", exception.Message);
            }
        }

        [TestMethod]
        public void TestInvalidPasswordExceptionMessage3()
        {
            try
            {
                //Arrange
                myEndUser.Password = "Abcdefg1";
                Assert.Fail();
            }
            // Act
            catch (ArgumentException exception)
            {
                // Assert
                Assert.AreEqual("Invalid Password", exception.Message);
            }
        }

        [TestMethod]
        public void TestInvalidPasswordExceptionMessage4()
        {
            try
            {
                //Arrange
                myEndUser.Password = "abcdef1!";
                Assert.Fail();
            }
            // Act
            catch (ArgumentException exception)
            {
                // Assert
                Assert.AreEqual("Invalid Password", exception.Message);
            }
        }

        [TestMethod]
        public void TestShortEmailExceptionMessage()
        {
            try
            {
                //Arrange
                myEndUser.Email = "a@a.d";
                Assert.Fail();
            }
            // Act
            catch (ArgumentException exception)
            {
                // Assert
                Assert.AreEqual("Invalid Email", exception.Message);
            }
        }

        [TestMethod]
        public void TestInvalidEmailExceptionMessage()
        {
            try
            {
                //Arrange
                myEndUser.Email = "abcdef";
                Assert.Fail();
            }
            // Act
            catch (ArgumentException exception)
            {
                // Assert
                Assert.AreEqual("Invalid Email", exception.Message);
            }
        }

        [TestMethod]
        public void TestInvalidEmailExceptionMessage2()
        {
            try
            {
                //Arrange
                myEndUser.Email = "abc.ef";
                Assert.Fail();
            }
            // Act
            catch (ArgumentException exception)
            {
                // Assert
                Assert.AreEqual("Invalid Email", exception.Message);
            }
        }

        [TestMethod]
        public void TestInvalidEmailExceptionMessage3()
        {
            try
            {
                //Arrange
                myEndUser.Email = "abc.cef";
                Assert.Fail();
            }
            // Act
            catch (ArgumentException exception)
            {
                // Assert
                Assert.AreEqual("Invalid Email", exception.Message);
            }
        }

        [TestMethod]
        public void TestValidEmail()
        {
            myEndUser.Email = "ABC123@abc.com";
            Assert.AreEqual("ABC123@abc.com", myEndUser.Email);
        }
    }
}
