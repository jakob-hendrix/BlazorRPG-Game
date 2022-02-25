using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SimpleRPG.Game.Tests
{
    public class TestClassTests
    {
        [Fact]
        public void DoSomething_Test()
        {
            // arrange
            var cut = new TestClass();

            // act
            var result = cut.DoSomething("TestAbc");

            // assert
            Assert.True(result);
            Assert.Equal("TestAbc", cut.Name);
        }
    }
}
