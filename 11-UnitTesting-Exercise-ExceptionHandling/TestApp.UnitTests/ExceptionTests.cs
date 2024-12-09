using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class ExceptionTests
{
    private Exceptions _exceptions = null!;

    [SetUp]
    public void SetUp()
    {
        this._exceptions = new Exceptions();
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange
        string input = "Hello!";
        string expected = "!olleH";

        // Act
        string result = _exceptions.ArgumentNullReverse(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_NullString_ThrowsArgumentNullException()
    {
        // Arrange
        string input = null;
        string expectedMessage = "String cannot be null. (Parameter 's')";

        // Act & Assert
        Assert.That(() => _exceptions.ArgumentNullReverse(input), Throws.ArgumentNullException);

        try
        {
            _exceptions.ArgumentNullReverse(input);
        }
        catch (ArgumentNullException exception)
        {
            Assert.AreEqual(expectedMessage, exception.Message);
        }
    }

    [Test]
    public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice()
    {
        // Arrange
        decimal totalPrice = 200;
        decimal discount = 10;
        decimal expectedPrice = 180;

        // Act
        decimal result = _exceptions.ArgumentCalculateDiscount(totalPrice, discount);

        // Assert
        Assert.That(result, Is.EqualTo(expectedPrice));
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 200;
        decimal discount = -10;
        string expectedMessage = "Discount must be between 0 and 100. (Parameter 'discount')";

        // Act & Assert
        //Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
        ArgumentException exception =  Assert.Throws<ArgumentException>(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount));
        Assert.AreEqual(expectedMessage, exception.Message);
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = 110.0m;
        string expectedMessage = "Discount must be between 0 and 100. (Parameter 'discount')";

        // Act & Assert
        ArgumentException exception = Assert.Throws<ArgumentException>(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount));
        Assert.AreEqual(expectedMessage, exception.Message);
    }

    [Test]
    public void Test_GetElement_ValidIndex_ReturnsElement()
    {
        //Arrange
        int[] input = new int[] { 1, 3, 7, -5, 20 };
        int index = 2;
        int expected = 7;

        // Act
        int result = _exceptions.IndexOutOfRangeGetElement(input, index);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
    {
        //Arrange
        int[] input = new int[] { 1, 3, 7, -5, 20 };
        int index = -2;
        string expectedMessage = "Index is out of range.";

        // Act & Assert - с метод  Assert.That
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(input, index), Throws.InstanceOf<IndexOutOfRangeException>());

        try
        {
            _exceptions.IndexOutOfRangeGetElement(input, index);
        }
        catch (IndexOutOfRangeException ex)
        {
            Assert.AreEqual(expectedMessage, ex.Message);
        }
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] input = { 10, 20, 30, 40, 50 };
        int index = input.Length;
        string expectedMessage = "Index is out of range.";

        // Act & Assert - с метод  Assert.Throws
        var exception = Assert.Throws<IndexOutOfRangeException>(() => _exceptions.IndexOutOfRangeGetElement(input, index));
        Assert.AreEqual(expectedMessage, exception.Message);
    }

    [Test]
    public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] input = { 10, 20, 30, 40, 50 };
        int index = 10;
        string expectedMessage = "Index is out of range.";

        // Act & Assert - с метод  Assert.Throws
        var exception = Assert.Throws<IndexOutOfRangeException>(() => _exceptions.IndexOutOfRangeGetElement(input, index));
        Assert.AreEqual(expectedMessage, exception.Message);
    }

    [Test]
    public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
    {
        // Arrange
        bool input = true;
        string expectedMessage = "User logged in.";

        // Act
        string result = _exceptions.InvalidOperationPerformSecureOperation(input);

        // Assert
        Assert.That(result, Is.EqualTo(expectedMessage));
    }

    [Test]
    public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
    {
        // Arrange
        bool input = false;
        string expectedMessage = "User must be logged in to perform this operation.";

        // Act & Assert
        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => _exceptions.InvalidOperationPerformSecureOperation(input));
        Assert.AreEqual(expectedMessage, ex.Message);
    }

    [Test]
    public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
    {
        // Arrange
        string input = "42";
        int expected = 42;

        // Act
        int result = _exceptions.FormatExceptionParseInt(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ParseInt_InvalidInput_ThrowsFormatException()
    {
        // Arrange
        string input = "42a";
        string expectedMessage = "Input is not in the correct format for an integer.";

        // Act & Assert
        FormatException ex =  Assert.Throws<FormatException>(() => _exceptions.FormatExceptionParseInt(input));
        Assert.That(ex.Message, Is.EqualTo(expectedMessage));
    }

    [Test]
    public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue()
    {
        // Arrange
        Dictionary<string, int> input = new Dictionary<string, int>()
        {
            ["one"] = 1,
            ["two"] = 2,
            ["three"] = 3,
        };
        string key = "two";
        int expected = 2;

        // Act
        int result = _exceptions.KeyNotFoundFindValueByKey(input, key);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, int> input = new Dictionary<string, int>()
        {
            ["one"] = 1,
            ["two"] = 2,
            ["three"] = 3,
        };
        string invalidKey = "four";
        string expectedMessage = "The specified key was not found in the dictionary.";

        // Act & Assert
        KeyNotFoundException ex =  Assert.Throws<KeyNotFoundException>(() => _exceptions.KeyNotFoundFindValueByKey(input, invalidKey));
        Assert.AreEqual(expectedMessage, ex.Message);
    }

    [Test]
    public void Test_AddNumbers_NoOverflow_ReturnsSum()
    {
        // Arrange
        int x = 700;
        int y = 800;
        int expected = 1500;

        // Act
        int result = _exceptions.OverflowAddNumbers(x, y);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
    {
        // Arrange
        int x = int.MaxValue;
        int y = 1;
        string expecterdMessage = "Arithmetic overflow occurred during addition.";

        // Act & Assert
        OverflowException ex = Assert.Throws<OverflowException>(() => _exceptions.OverflowAddNumbers(x, y));
        Assert.AreEqual(expecterdMessage, ex.Message);
    }

    [Test]
    public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
    {
        // Arrange
        int x = int.MinValue;
        int y = -1;
        string expecterdMessage = "Arithmetic overflow occurred during addition.";

        // Act & Assert
        OverflowException ex = Assert.Throws<OverflowException>(() => _exceptions.OverflowAddNumbers(x, y));
        Assert.AreEqual(expecterdMessage, ex.Message);
    }

    [Test]
    public void Test_DivideNumbers_ValidDivision_ReturnsQuotient()
    {
        // Arrange
        int dividend = 14;
        int divisor = 4;
        int expected = 3;

        // Act
        int result = _exceptions.DivideByZeroDivideNumbers(dividend, divisor);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DivideNumbers_DivideByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        int dividend = 14;
        int divisor = 0;
        string expectedMessage = "Division by zero is not allowed.";

        // Act & Assert
        DivideByZeroException ex = Assert.Throws<DivideByZeroException>(() => _exceptions.DivideByZeroDivideNumbers(dividend, divisor));
        Assert.AreEqual(expectedMessage, ex.Message);
    }

    [Test]
    public void Test_SumCollectionElements_ValidCollectionAndIndex_ReturnsSum()
    {
        // Arrange
        int[] array = new int[] { 1, 2, 3, 4, 5 };
        int index = 2;
        int expected = 15;

        // Act
        int result = _exceptions.SumCollectionElements(array, index);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_SumCollectionElements_NullCollection_ThrowsArgumentNullException()
    {
        // Arrange
        int[] array = null;
        int index = 2;
        string expectedMessage = "Collection cannot be null. (Parameter 'collection')";

        // Act & Assert
        ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => _exceptions.SumCollectionElements(array, index));
        Assert.AreEqual(expectedMessage, ex.Message);
    }

    [TestCase(-10)]
    [TestCase(-1)]
    [TestCase(5)]
    [TestCase(10)]
    public void Test_SumCollectionElements_IndexOutOfRange_ThrowsIndexOutOfRangeException(int index)
    {
        // Arrange
        int[] array = new int[] { 1, 2, 3, 4, 5 };
        string expectedMessage = "Index has to be within bounds.";

        // Act & Assert
        // var takes IndexOutOfRangeException 
        var ex = Assert.Throws<IndexOutOfRangeException>(() => _exceptions.SumCollectionElements(array, index));
        Assert.AreEqual(expectedMessage, ex.Message);
    }

    [Test]
    public void Test_GetElementAsNumber_ValidKey_ReturnsParsedNumber()
    {
        // Arrange
        Dictionary<string, string> input = new Dictionary<string, string>()
        {
            ["one"] = "1",
            ["two"] = "2",
            ["three"] = "3"
        };
        string key = "two";
        int expected = 2;

        // Act
        int result = _exceptions.GetElementAsNumber(input, key);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetElementAsNumber_KeyNotFound_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, string> input = new Dictionary<string, string>()
        {
            ["one"] = "1",
            ["two"] = "2",
            ["three"] = "3"
        };
        string invalidKey = "invalid";

        // Act & Assert - new sintaxis
        Assert.That(() => _exceptions.GetElementAsNumber(input, invalidKey), Throws.TypeOf<KeyNotFoundException>());
    }

    [Test]
    public void Test_GetElementAsNumber_InvalidFormat_ThrowsFormatException()
    {
        // Arrange
        Dictionary<string, string> input = new Dictionary<string, string>()
        {
            ["one"] = "1z",
            ["two"] = "2a",
            ["three"] = "b"
        };
        string key = "two";

        // Act & Assert - new sinraxis
        Assert.That(() => _exceptions.GetElementAsNumber(input, key), Throws.InstanceOf<FormatException>());
    }
}
