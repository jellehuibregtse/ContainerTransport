using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContainerTransport.UnitTests
{
    [TestClass]
    public class RowTests
    {
        private Row _row;
        
        [TestInitialize]
        public void Setup()
        {
            _row = new Row();
        }

        [TestMethod]
        public void IsRowBalanced_Exactly20Percent_IsTrue()
        {
            // Arrange
            var leftStack = new Stack();
            var rightStack = new Stack();
            
            for (var i = 0; i < 10; i++)
            {
                leftStack.AddContainer(new Container(10000, ContainerType.Normal));
                rightStack.AddContainer(new Container(10000, ContainerType.Normal));
            }

            leftStack.AddContainer(new Container(20000, ContainerType.Normal));
            
            _row.AddStack(leftStack);
            _row.AddStack(rightStack);

            // Act
            var actual = _row.IsRowBalanced();

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsRowBalanced_Not20Percent_IsFalse()
        {
            // Arrange
            var leftStack = new Stack();
            var rightStack = new Stack();
            
            for (var i = 0; i < 10; i++)
            {
                leftStack.AddContainer(new Container(10000, ContainerType.Normal));
                rightStack.AddContainer(new Container(10000, ContainerType.Normal));
            }

            leftStack.AddContainer(new Container(20001, ContainerType.Normal));
            
            _row.AddStack(leftStack);
            _row.AddStack(rightStack);

            // Act
            var actual = _row.IsRowBalanced();

            // Assert
            Assert.IsFalse(actual);
        }
    }
}