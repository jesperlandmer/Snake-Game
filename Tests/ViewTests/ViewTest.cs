using System;
using System.IO;
using System.Text;
using Moq;
using Xunit;

namespace Snake_Game.Tests.ViewTests
{
    public class ViewTest : TestBase<Src.View.MasterView>
    {
        private Mock<StringWriter> _mockOutput;
        public ViewTest()
        {
            _sut = new Src.View.MasterView();
            _mockOutput = new Mock<StringWriter>();
            System.Console.SetOut(_mockOutput.Object);
        }
        public override void Dispose()
        {
            var standardOutput = new StreamWriter(Console.OpenStandardOutput());
            System.Console.SetOut(standardOutput);
        }

        [Theory]
        [InlineData(ConsoleKey.UpArrow)]
        public void AssertViewReturnsConsoleKey(ConsoleKey testKey)
        {
            var mockView = new Mock<Src.View.IView>();

            mockView.Setup(s => s.GetChosenDirection())
            .Returns(testKey);
        }

        [Theory]
        [InlineData(30)]
        public void AssertViewWritesArena(int arenaLimits)
        {
            _sut.WriteArena(arenaLimits);
            int TopLength = arenaLimits;
            int SidesLength = arenaLimits * 2 - 4; // minus 4 because removes corners
            int BottomLength = arenaLimits;
            int expectedWallsLength = TopLength + SidesLength + BottomLength;

            // Write All Walls
            _mockOutput.Verify(mo => mo.Write(It.Is<string>(Out => Out == "#")),
            Times.Exactly(expectedWallsLength));
        }

        [Fact]
        public void AssertViewWritesSnake()
        {
            var Game = new Src.Model.Game();
            Game.NewGame();

            _sut.WriteSnake(Game.Snake);
            int expectedHead = 1;
            int expectedBody = Game.Snake.Body.Count - expectedHead;

            _mockOutput.Verify(mo => mo.Write(It.Is<string>(Out => Out == "⊙")),
            Times.Exactly(expectedHead));
            _mockOutput.Verify(mo => mo.Write(It.Is<string>(Out => Out == "*")),
            Times.Exactly(expectedBody));
        }

        [Fact]
        public void AssertViewWritesFood()
        {
            var Game = new Src.Model.Game();
            Game.NewGame();

            _sut.WriteFood(Game.Food);
            int expected = 1;

            _mockOutput.Verify(mo => mo.Write(It.Is<string>(Out => Out == "◕")),
            Times.Exactly(expected));
        }

        [Theory]
        [InlineData(2)]
        public void AssertViewWritesPlayerStats(int score)
        {
            _sut.WriteStats(score);

            _mockOutput.Verify(mo => mo.Write(It.Is<string>(Out => Out == "\n")),
            Times.Once());
            _mockOutput.Verify(mo => mo.Write(It.Is<string>(Out => Out == "Score: " + score + " p")),
            Times.Once());
        }
        [Fact]
        public void AssertViewWritesGameOver()
        {
            _sut.WriteGameOver();

            _mockOutput.Verify(mo => mo.Write(It.Is<string>(Out => Out == "\n")),
            Times.Once());
            _mockOutput.Verify(mo => mo.Write(It.Is<string>(Out => Out == "Game Over")),
            Times.Once());
        }
    }
}