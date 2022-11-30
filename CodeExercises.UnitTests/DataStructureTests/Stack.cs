using System;
using CodeExercises.DataStructures;

namespace CodeExercises.UnitTests.DataStructureTests;

public class StackTests
{
    [Test]
    public void Stack_Count_EmptyStack_ReturnZero()
    {
        var stack = new DataStructures.Stack<string>();

        Assert.That(stack.Count, Is.EqualTo(0));
    }

    [Test]
    public void Stack_Push_ArgIsNull_ThrowArgNullException()
    {
        var stack = new DataStructures.Stack<string>();

        Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
    }

    [Test]
    public void Stack_Push_ValidArg_AddTheObjectToTheStack()
    {
        var stack = new DataStructures.Stack<string>();

        stack.Push("a");

        Assert.That(stack.Count, Is.EqualTo(1));
    }

    [Test]
    public void Stack_Pop_EmptyStack_ThrowInvalidOperationException()
    {
        var stack = new DataStructures.Stack<string>();

        Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
    }

    [Test]
    public void Stack_Pop_StackWithObjects_ReturnsObjectOnTop()
    {
        // Arrange
        var stack = new DataStructures.Stack<string>();
        stack.Push("a");
        stack.Push("b");
        stack.Push("c");

        // Act
        var result = stack.Pop();

        // Assert
        Assert.That(result, Is.EqualTo("c"));
    }

    [Test]
    public void Stack_Pop_StackWithObjects_RemovesObjectOnTop()
    {
        // Arrange
        var stack = new DataStructures.Stack<string>();
        stack.Push("a");
        stack.Push("b");
        stack.Push("c");

        // Act
        stack.Pop();

        // Assert
        Assert.That(stack.Count, Is.EqualTo(2));
    }

    [Test]
    public void Stack_Peek_EmptyStack_ThrowInvalidOperationException()
    {
        // Arrange 
        var stack = new DataStructures.Stack<string>();
        
        // Assert
        Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
    }

    [Test]
    public void Stack_Peek_StackWithObjects_ReturnsObjectOnTopOfTheStack()
    {
        // Arrange
        var stack = new DataStructures.Stack<string>();
        stack.Push("a");
        stack.Push("b");
        stack.Push("c");

        // Act
        var result = stack.Peek();

        // Assert
        Assert.That(result, Is.EqualTo("c"));
    }

    [Test]
    public void Stack_Peek_StackWithObjects_DoesNotRemoveObjectOnTopOfTheStack()
    {
        // Arrange
        var stack = new DataStructures.Stack<string>();
        stack.Push("a");
        stack.Push("b");
        stack.Push("c");

        // Act
        stack.Peek();

        // Assert
        Assert.That(stack.Count, Is.EqualTo(3));
    }
}

