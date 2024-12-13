using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class CsvParserTests
{
    [TestCase("")]
    [TestCase(null)]
    public void Test_ParseCsv_EmptyInput_ReturnsEmptyArray(string input)
    {
        // Act
        string[] result = CsvParser.ParseCsv(input);

        // Assert
        Assert.IsEmpty(result);
    }

    [Test]
    public void Test_ParseCsv_SingleField_ReturnsArrayWithOneElement()
    {
        // Arrange
        string input = "Hello";
        string[] expected = new string[] { "Hello" };

        // Act
        string[] result = CsvParser.ParseCsv(input);

        // Assert - compare the element in the array
        Assert.That(result[0], Is.EqualTo(input));
        Assert.That(result.Length, Is.EqualTo(1));

        // Assert - compare two arrays
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_ParseCsv_MultipleFields_ReturnsArrayWithMultipleElements()
    {
        // Arrange
        string input = "Hello,name,car,doctor";
        string[] expected = new string[] { "Hello", "name", "car", "doctor" };

        // Act
        string[] result = CsvParser.ParseCsv(input);

        // Assert - compare the element in the array
        Assert.That(result[0], Is.EqualTo(expected[0]));
        Assert.That(result[2], Is.EqualTo(expected[2]));
        Assert.That(result.Length, Is.EqualTo(4));
    }

    [Test]
    public void Test_ParseCsv_TrimsWhiteSpace_ReturnsCleanArray()
    {
        // Arrange
        string input = "  Hello, name  , car,       doctor   ";
        string[] expected = new string[] { "Hello", "name", "car", "doctor" };

        // Act
        string[] result = CsvParser.ParseCsv(input);

        // Assert - compare two arrays
        CollectionAssert.AreEqual(expected, result);
    }
}
