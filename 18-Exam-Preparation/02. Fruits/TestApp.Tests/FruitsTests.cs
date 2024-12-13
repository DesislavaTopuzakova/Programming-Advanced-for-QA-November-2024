using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class FruitsTests
{
    [Test]
    public void Test_GetFruitQuantity_FruitExists_ReturnsQuantity()
    {
        // Arrange
        Dictionary<string, int> fruits = new Dictionary<string, int>();
        fruits.Add("apple", 15);
        fruits.Add("banana", 25);
        fruits.Add("grape", 20);
        int expected = 25;

        // Act
        int result = Fruits.GetFruitQuantity(fruits, "banana");

        // Arrange
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFruitQuantity_FruitDoesNotExist_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> fruits = new Dictionary<string, int>();
        fruits.Add("apple", 15);
        fruits.Add("banana", 25);
        fruits.Add("grape", 20);
        int expected = 0;

        // Act
        int result = Fruits.GetFruitQuantity(fruits, "orange");

        // Asssert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFruitQuantity_EmptyDictionary_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> fruits = new Dictionary<string, int>();
        int expected = 0;

        // Act
        int result = Fruits.GetFruitQuantity(fruits, "orange");

        // Asssert
        Assert.That(result, Is.EqualTo(expected));
  
    }

    [Test]
    public void Test_GetFruitQuantity_NullDictionary_ReturnsZero()
    {
        // Arrange
        int expected = 0;

        // Act
        int result = Fruits.GetFruitQuantity(null, "orange");

        // Asssert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFruitQuantity_NullFruitName_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> fruits = new Dictionary<string, int>();
        fruits.Add("apple", 15);
        fruits.Add("banana", 25);
        fruits.Add("grape", 20);
        int expected = 0;

        // Act
        int result = Fruits.GetFruitQuantity(fruits, null);

        // Asssert
        Assert.That(result, Is.EqualTo(expected));
    }
}
