using System;
using System.IO;
using System.Text;
using Moq;
using NUnit.Framework;

namespace Snake_Game.Tests.ViewTests
{
    [TestFixture]
    [Category("View")]
    class ViewTest : TestBase<Src.View.MasterView>
    {
        private Mock<StringWriter> _mockOutput;

        [SetUp]
        public override void Init()
        {
            _sut = new Src.View.MasterView();
            _mockOutput = new Mock<StringWriter>();
            System.Console.SetOut(_mockOutput.Object);
        }

        [TearDown]
        public override void Dispose()
        {
            var standardOutput = new StreamWriter(Console.OpenStandardOutput());
            System.Console.SetOut(standardOutput);
        }

        [TestCase(ConsoleKey.UpArrow)]
        [TestCase(ConsoleKey.DownArrow)]
        [TestCase(ConsoleKey.LeftArrow)]
        [TestCase(ConsoleKey.RightArrow)]
        public void AssertViewGetsPressedKey(ConsoleKey key)
        {
            var mockUserInput = new Mock<Src.View.IConsoleView>();
            mockUserInput.Setup(s => s.GetPressedArrow()).Returns(key);

            _sut = new Src.View.MasterView(mockUserInput.Object);
            _sut.GetChosenDirection();

            mockUserInput.Verify(s => s.GetPressedArrow(),
            Times.Once());
        }

        [TestCase(30)]
        public void AssertArenaWritesTopWall(int arenaLimits)
        {
            _sut.WriteTop(arenaLimits);
            int expected = arenaLimits;
            _mockOutput.Verify(mo => mo.Write(It.Is<string>(Out => Out == "#")),
            Times.Exactly(expected));
        }
        [TestCase(20)]
        public void AssertArenaWritesSideWalls(int arenaLimits)
        {
            _sut.WriteSides(arenaLimits);
            int expected = arenaLimits * 2 - 4; // minus 4 because removes corners
            _mockOutput.Verify(mo => mo.Write(It.Is<string>(Out => Out == "#")),
            Times.Exactly(expected));
        }
        [TestCase(30)]
        public void AssertArenaWritesBottomWall(int arenaLimits)
        {
            _sut.WriteBottom(arenaLimits);
            int expected = arenaLimits;
            _mockOutput.Verify(mo => mo.Write(It.Is<string>(Out => Out == "#")),
            Times.Exactly(expected));
        }

        [Test]
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

        [Test]
        public void AssertViewWritesFood()
        {
            var Game = new Src.Model.Game();
            Game.NewGame();

            _sut.WriteFood(Game.Food);
            int expected = 1;

            _mockOutput.Verify(mo => mo.Write(It.Is<string>(Out => Out == "◕")),
            Times.Exactly(expected));
        }

        [TestCase(2)]
        public void AssertViewWritesPlayerStats(int score)
        {
            _sut.WriteStats(score);

            _mockOutput.Verify(mo => mo.Write(It.Is<string>(Out => Out == "\n")),
            Times.Once());
            _mockOutput.Verify(mo => mo.Write(It.Is<string>(Out => Out == "Score: " + score + " p")),
            Times.Once());
        }
        [Test]
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