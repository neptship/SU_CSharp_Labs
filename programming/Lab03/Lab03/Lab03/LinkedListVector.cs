using System;

namespace Lab03;

class LinkedListVector : IVectorable
{
    public class Node
    {
        public int data;
        public Node? next;

        public Node(int data)
        {
            this.data = data;
            next = null;
        }
        
        public Node(int data, Node? next)
        {
            this.data = data;
            this.next = next;
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
            if (position < 0 || position > Length)
            {
                throw new IndexOutOfRangeException($"Индекс вне границ списка");
            }
            return GetNode(position).data;
        }
        set
        {
            if (position < 0 || position > Length)
            {
                throw new IndexOutOfRangeException($"Индекс вне границ списка");
            }
            GetNode(position).data = value;
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
                current = current.next;
            }
            return count;
        }
    }

    private Node GetNode(int index)
    {
        Node? current = head;
        for (int i = 0; i < index; i++)
        {
            current = current!.next;
        }
        return current!;
    }

    public double GetNorm()
    {
        double sum = 0;
        Node? current = head;
        while (current != null)
        {
            sum += (double)current.data * current.data;
            current = current.next;
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
        while (current.next != null)
        {
            current = current.next;
        }
        current.next = newNode;
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
        Node newNode = new Node(value, prev.next);
        prev.next = newNode;
    }
    
    public int RemoveFromEnd()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Список пуст");
        }

        if (head.next == null)
        {
            int val = head.data;
            head = null;
            return val;
        }

        Node current = head;
        while (current.next!.next != null)
        {
            current = current.next;
        }
        int value = current.next.data;
        current.next = null;
        return value;
    }
    
    public int RemoveFromBeginning()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Список пуст");
        }

        int value = head.data;
        head = head.next;
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
        int value = prev.next!.data;
        prev.next = prev.next.next;
        return value;
    }
    
    public void Print()
    {
        Console.Write("[ ");
        Node? current = head;
        while (current != null)
        {
            Console.Write(current.data + " ");
            current = current.next;
        }
        Console.WriteLine("]");
        
    }
    
    public override string ToString()
    {
        string result = Length.ToString();
        Node? current = head;
        while (current != null)
        {
            result += " " + current.data;
            current = current.next;
        }
        return result;
    }
}