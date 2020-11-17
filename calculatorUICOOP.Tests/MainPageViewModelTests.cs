using calculatorUICOOP.ViewModels;
using NUnit.Framework;

namespace calculatorUICOOP.Tests
{
    internal class MainPageViewModelTests
    {
        private MainPageViewModel _vm;

        [SetUp]
        public void Setup()
        {
            _vm = new MainPageViewModel();
        }

        /// <summary>
        /// Expected result: Should never have leading zeros when given a string of numerical characters
        /// </summary>
        [Test]
        [TestCase("5","0005")]
        [TestCase("5", "05")]
        [TestCase("0.005", "0.005")]
        [TestCase("50", "50")]
        [TestCase("50.0", "50.0")]
        [TestCase("50.0000000005", "50.0000000005")]
        public void ShowNumberOnDisplayTest(string expected, string input)
        {
            _vm.ShowNumberOnDisplay(input);
            var actual = _vm.DisplayContent;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ClearScreenTest()
        {
            var initial = _vm.DisplayContent;
            _vm.ClearScreen();
            var post = _vm.DisplayContent;
            Assert.AreNotEqual(initial,post);
        }

        [Test]
        [TestCase("50","500")]
        [TestCase("5.55", "5.555")]
        [TestCase("0", "1")]    // TODO open bug
        [TestCase("0", "5")]    // TODO open bug
        public void DeleteLastInputTest(string expected, string input)
        {
            _vm.DisplayContent = input;
            _vm.DeleteLastInput();
            string actual = _vm.DisplayContent;
            Assert.AreEqual(expected, actual);
        }
    }
}