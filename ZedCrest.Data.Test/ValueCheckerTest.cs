using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZedCrest.Data.Interfaces;
using ZedCrest.Data.Repositories;

namespace ZedCrest.Data.Test
{
     [TestClass]
     public class ValueCheckerTest
     {
          private IValueCheckerRepository valueCheckerRepository;

          [TestInitialize]
          public void Initialize()
          {
               valueCheckerRepository = new ValueCheckerRepository();;
          }

          [TestMethod]
          public void Check_If_Value_Less_Than_One()
          {
               // Arrange
               int value = -1;

               // Act
               var result = valueCheckerRepository.IsMultiple(value);

               // Assert
               Assert.AreEqual(value.ToString(), result);
          }

          [TestMethod]
          public void Check_If_Value_More_Than_One_Hundred()
          {
               // Arrange
               int value = 101;

               // Act
               var result = valueCheckerRepository.IsMultiple(value);

               // Assert
               Assert.AreEqual(value.ToString(), result);
          }

          [DataTestMethod]
          [DataRow(3)]
          [DataRow(6)]
          [DataRow(9)]
          [DataRow(12)]
          [DataRow(18)]
          [DataRow(21)]
          [DataRow(24)]
          [DataRow(27)]
          [DataRow(33)]
          [DataRow(36)]
          public void Check_If_Value_Is_Multiple_Of_Three(int value)
          {
               // Arrange
               //int value = 18;

               // Act
               var result = valueCheckerRepository.IsMultiple(value);

               // Assert
               Assert.AreEqual("Fizz", result);
          }

          [DataTestMethod]
          [DataRow(5)]
          [DataRow(10)]
          [DataRow(20)]
          [DataRow(25)]
          [DataRow(35)]
          [DataRow(40)]
          [DataRow(50)]
          [DataRow(55)]
          [DataRow(65)]
          public void Check_If_Value_Is_Multiple_Of_Five(int value)
          {
               // Arrange
               //int value = 25;

               // Act
               var result = valueCheckerRepository.IsMultiple(value);

               // Assert
               Assert.AreEqual("Buzz", result);
          }

          [DataTestMethod]
          [DataRow(15)]
          [DataRow(30)]
          [DataRow(45)]
          [DataRow(60)]
          [DataRow(75)]
          [DataRow(90)]
          public void Check_If_Value_Is_Multiple_Of_Three_And_Five(int value)
          {
               // Arrange
               //int value = 25;

               // Act
               var result = valueCheckerRepository.IsMultiple(value);

               // Assert
               Assert.AreEqual("FizzBuzz", result);
          }

          [DataTestMethod]
          [DataRow(204)]
          public void Check_If_Repo_Returns_Value(int value)
          {
               //Arrange

               //Act
               var result = valueCheckerRepository.IsMultiple(value);

               //Assert
               Assert.IsNotNull(result);
          }
     }
}
