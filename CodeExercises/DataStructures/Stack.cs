using System;
namespace CodeExercises.DataStructures;

/*
 * A stack is a data structure in which items are added or removed in a Last In First Out (LIFO) 
 * or First In Last Out (FILO) manner.
 * 
 * The back button in your browser is a good example of stack functionality.
 * As you visit a web page it will add it to the stack that is your browser history.
 * When you hit the back button, it "pops" the most recent item off the stack and redirects the user there.
 * 
 * There are three main functions associated with a stack. Those are Push, Pop, and Peek.
 * Push (Object) - Inserts an object at the top of the Stack.
 * Pop () - Removes and returns the object at the top of the Stack.
 * Peek () - Returns the object at the top of the Stack without removing it.
 */
public class Stack<T>
{
    private readonly List<T> _list = new List<T>();
    public int Count => _list.Count;

    public void Push(T obj)
    {
        if (obj == null)
            throw new ArgumentNullException();

        _list.Add(obj);
    }

    public T Pop()
    {
        if (_list.Count == 0)
            throw new InvalidOperationException();

        var index = _list.Count - 1;

        var result = _list[index];
        _list.RemoveAt(index);

        return result;
    }

    public T Peek()
    {
        if (_list.Count == 0)
            throw new InvalidOperationException();

        return _list[_list.Count - 1];
    }
}

