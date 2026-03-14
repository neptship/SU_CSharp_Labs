using System;

namespace Lab02;

class LinkedListVector
{
    public class Node
    {
        public int Data;
        public Node? Next;

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
        
        public Node(int data, Node? next)
        {
            Data = data;
            Next = next;
        }
    }

    private Node? head;

    public LinkedListVector()
    {
        head = null;
        for (int i = 0; i < 5; i++)
        {
            AddToEnd(0);
        }
    }

    public LinkedListVector(int length)
    {
        if (length < 0)
        {
            throw new ArgumentException("Длина списка не может быть отрицательной");
        }
        head = null;
        for (int i = 0; i < length; i++)
        {
            AddToEnd(0);
        }
    }
    
    public int this[int position]
    {
        get
        {
            if (position < 1 || position > Length)
            {
                throw new IndexOutOfRangeException($"Индекс вне границ списка");
            }
            return GetNode(position - 1).Data;
        }
        set
        {
            if (position < 1 || position > Length)
            {
                throw new IndexOutOfRangeException($"Индекс вне границ списка");
            }
            GetNode(position - 1).Data = value;
        }
    }
    
    public int Length
    {
        get
        {
            int count = 0;
            Node? current = head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }

    private Node GetNode(int index)
    {
        Node? current = head;
        for (int i = 0; i < index; i++)
        {
            current = current!.Next;
        }
        return current!;
    }

    public double GetNorm()
    {
        double sum = 0;
        Node? current = head;
        while (current != null)
        {
            sum += (double)current.Data * current.Data;
            current = current.Next;
        }
        return Math.Sqrt(sum);
    }
    
    public void AddToEnd(int value)
    {
        Node newNode = new Node(value);
        if (head == null)
        {
            head = newNode;
            return;
        }
        Node current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = newNode;
    }

    public void AddToBeginning(int value)
    {
        Node newNode = new Node(value, head);
        head = newNode;
    }

    public void AddAtPosition(int position, int value)
    {
        int len = Length;
        if (position < 1 || position > len + 1)
        {
            throw new IndexOutOfRangeException($"Индекс вне допустимого диапазона");
        }

        if (position == 1)
        {
            AddToBeginning(value);
            return;
        }

        Node prev = GetNode(position - 2);
        Node newNode = new Node(value, prev.Next);
        prev.Next = newNode;
    }
    
    public int RemoveFromEnd()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Список пуст");
        }

        if (head.Next == null)
        {
            int val = head.Data;
            head = null;
            return val;
        }

        Node current = head;
        while (current.Next!.Next != null)
        {
            current = current.Next;
        }
        int value = current.Next.Data;
        current.Next = null;
        return value;
    }
    
    public int RemoveFromBeginning()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Список пуст");
        }

        int value = head.Data;
        head = head.Next;
        return value;
    }

    public int RemoveAtPosition(int position)
    {
        int len = Length;
        if (position < 1 || position > len)
        {
            throw new IndexOutOfRangeException($"Индекс вне границ списка");
        }

        if (position == 1)
        {
            return RemoveFromBeginning();
        }

        Node prev = GetNode(position - 2);
        int value = prev.Next!.Data;
        prev.Next = prev.Next.Next;
        return value;
    }
    
    public void Print()
    {
        Console.Write("[ ");
        Node? current = head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine("]");
        
    }
}