using MarsRover.ConsoleUI;
using System.Collections.Generic;
using Xunit;

namespace MarsRover.Test
{
    public class RoverTest
    {
        private readonly Plateau _plateau;
        public RoverTest()
        {
            _plateau = new Plateau() { Width = 5, Height = 5 };
        }
        [Fact]
        ///Bulunduğu konum ve yön itibari ile (5,5) bir uzay düzleminde kuzeye doğru en fazla 3 hareket(M) alabilir
        public void Move_GoOutOfThePlateau_GetErrorMessage()
        {

            // Arrange
            var rover = new Rover(_plateau, 1, 1, 2, 'N');
            var expectedMessage = "Rover1 cannot be outside of the plateue";

            // Act
            var actualMessage = rover.Move("MMMM");

            // Assert
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        ///Verilen talimatlar ile beklenen konuma gider
        public void Move_GoToDefinedPosition_GetExpectedPosition()
        {
            // Arrange
            var rover = new Rover(_plateau, 1, 1, 2, 'N');
            var expectedMessage = "Position of Rover1 is '1 3 N'";

            // Act
            var actualMessage = rover.Move("LMLMLMLMM");

            // Assert
            Assert.Equal(expectedMessage, actualMessage);
        }
    }
}
