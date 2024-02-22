using DiamondKata.Services;
using DiamondKata.Services.Interfaces;
using NUnit.Framework;
using System;
using System.IO;

namespace DiamondKataTests
{
    [TestFixture]
    public class DiamondServiceTests
    {
        private StringWriter _stringWriter;
        private DiamondService _diamondService;

        [SetUp]
        public void Setup()
        {
            // Przekierowanie standardowego wyjœcia konsoli do StringWriter.
            _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);

            // Inicjalizacja DiamondService.
            _diamondService = new DiamondService();
        }

        [TearDown]
        public void TearDown()
        {
            _stringWriter.Dispose();
            Console.SetOut(Console.Out);
        }

        [TestCase('1')]
        [TestCase('*')]
        [TestCase(' ')]
        [TestCase('¹')]
        [TestCase('¥')]
        [TestCase('¿')]
        [TestCase('¯')]
        public void PrintDiamond_PrintsNothing_ForNonLatinAlphabeticCharacters(char inputChar)
        {            
            var ex = Assert.Throws<ArgumentException>(() => _diamondService.PrintDiamond(inputChar));
            Assert.That(ex.Message, Is.EqualTo($"'{char.ToUpper(inputChar)}' is not a latin character"));
        }

        [Test]
        public void PrintDiamond_PrintsCorrectOutput_ForCharA()
        {
            _diamondService.PrintDiamond('A');
            var output = _stringWriter.ToString().Trim();
            Assert.That(output, Is.EqualTo("A"));
        }

        [TestCase('b')]
        [TestCase('B')]
        public void PrintDiamond_PrintsCorrectOutput_ForBCaseInsensitive(char inputChar)
        {
            _diamondService.PrintDiamond(inputChar);
            var output = _stringWriter.ToString();
            
            var expectedOutput = " A\r\nB B\r\n A\r\n";
            Assert.That(output, Is.EqualTo(expectedOutput));
        }

        [TestCase('c')]
        [TestCase('C')]
        public void PrintDiamond_PrintsCorrectOutput_ForCCaseInsensitive(char inputChar)
        {
            _diamondService.PrintDiamond(inputChar);
            var output = _stringWriter.ToString();

            var expectedOutput = "  A\r\n B B\r\nC   C\r\n B B\r\n  A\r\n";
            Assert.That(output, Is.EqualTo(expectedOutput));
        }
    }
}