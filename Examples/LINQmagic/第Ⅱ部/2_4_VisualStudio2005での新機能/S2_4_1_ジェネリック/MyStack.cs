using System.Collections.Generic;

public class MyStack<T>
{
  private List<T> _stack = new List<T>();

  public int Count { get { return _stack.Count; } }

  public void Push(T item)
  {
    _stack.Add(item);
  }

  public T Pop()
  {
    var item = _stack[Count - 1];
    _stack.RemoveAt(Count - 1);
    return item;
  }
}

