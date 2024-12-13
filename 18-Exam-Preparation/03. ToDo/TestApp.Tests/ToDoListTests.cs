using System;

using NUnit.Framework;

using TestApp.Todo;

namespace TestApp.Tests;

[TestFixture]
public class ToDoListTests
{
    private ToDoList _toDoList = null!;

    [SetUp]
    public void SetUp()
    {
        this._toDoList = new ToDoList();
    }

    [Test]
    public void Test_AddTask_TaskAddedToToDoList()
    {
        // Arrange
        string taskName = "Homework";
        DateTime dueDate = DateTime.Now;
        string expected = $"To-Do List:{Environment.NewLine}" +
                          $"[ ] Homework - Due: {dueDate.ToString("MM/dd/yyyy")}";

        // Act
        _toDoList.AddTask(taskName, dueDate);
        string result = _toDoList.DisplayTasks();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CompleteTask_TaskMarkedAsCompleted()
    {
        // Arrange
        string taskName = "Homework";
        DateTime dueDate = DateTime.Now;
        //string expected = $"To-Do List:{Environment.NewLine}" +
        //                  $"[✓] Homework - Due: {dueDate.ToString("MM/dd/yyyy")}";

        string substring = "[✓] Homework";

        // Act
        _toDoList.AddTask(taskName, dueDate);
        _toDoList.CompleteTask("Homework");
        string result = _toDoList.DisplayTasks();

        // Assert
        Assert.That(result, Does.Contain(substring));
    }

    [Test]
    public void Test_CompleteTask_TaskNotFound_ThrowsArgumentException()
    {
        // Arrange
        string taskName = "Homework";
        DateTime dueDate = DateTime.Now;
        string expectedMessage = "Task with given title does not exist.";

        // Act
        _toDoList.AddTask(taskName, dueDate);

        // Проверяване на съобщението в грешката с try-catch блок
        try
        {
            _toDoList.CompleteTask("InvalidTask");
        }
        catch (Exception exception)
        {
            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }

        // Assert - Проверяване на съобщението в грешката с Assert.Throws
        ArgumentException ex = Assert.Throws<ArgumentException>(() => _toDoList.CompleteTask("InvalidTask"));
        Assert.That(ex.Message, Is.EqualTo(expectedMessage));
    }

    [Test]
    public void Test_DisplayTasks_NoTasks_ReturnsEmptyString()
    {
        // Arrange
        string expected = $"To-Do List:";

        // Act
        string result = _toDoList.DisplayTasks();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DisplayTasks_WithTasks_ReturnsFormattedToDoList()
    {
        // Arrange
        string taskName1 = "Homework";
        string taskName2 = "Exam";
        DateTime dueDate = DateTime.Now;

        string expected = $"To-Do List:{Environment.NewLine}" +
                          $"[ ] Homework - Due: {dueDate.ToString("MM/dd/yyyy")}{Environment.NewLine}" +
                          $"[✓] Exam - Due: {dueDate.ToString("MM/dd/yyyy")}";

        // Act
        _toDoList.AddTask(taskName1, dueDate);
        _toDoList.AddTask(taskName2, dueDate);
        _toDoList.CompleteTask("Exam");
        string result = _toDoList.DisplayTasks();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }


    // Bonus test - not for Judge
    [Test]
    public void Test_CompleteTask_TaskMarkedAsCompleted_CaseInsensitive()
    {
        // Arrange
        string taskName = "Homework";
        DateTime dueDate = DateTime.Now;
        string substring = "[✓] Homework";

        // Act
        _toDoList.AddTask(taskName, dueDate);
        _toDoList.CompleteTask("hoMewOrK");
        string result = _toDoList.DisplayTasks();

        // Assert
        Assert.That(result, Does.Contain(substring));
    }

}
