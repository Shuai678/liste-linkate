using System;

public class Node
{
    public Node(string element)
    {
        Element = element;
        Next = null;
    }

    public string Element { get; set; }
    public Node Next { get; set; }

    public override string ToString()
    {
        return "{" + Element + "}";
    }
}

public class MyList
{
    private Node Head { get; set; }

    public MyList()
    {
        Head = null;
    }

    public void AddHead(string el)
    {
        Node n = new Node(el);
        n.Next = Head;
        Head = n;
    }

    public void AddTail(string el)
    {
        Node n = new Node(el);
        if (Head == null)
        {
            Head = n;
            return;
        }
        Node i = Head;
        while (i.Next != null)
        {
            i = i.Next;
        }
        i.Next = n;
    }

    // Rimuove l'elemento in testa e lo restituisce
    public string RemoveHead()
    {
        if (Head == null)
        {
            throw new Exception("La lista è vuota.");
        }
        string removed = Head.Element;
        Head = Head.Next;
        return removed;
    }

    // Rimuove l'elemento in coda e lo restituisce
    public string RemoveTail()
    {
        if (Head == null)
        {
            throw new Exception("La lista è vuota.");
        }
        // Se la lista contiene un solo elemento
        if (Head.Next == null)
        {
            string removed = Head.Element;
            Head = null;
            return removed;
        }
        // Scorro la lista fino al penultimo nodo
        Node current = Head;
        while (current.Next.Next != null)
        {
            current = current.Next;
        }
        // current.Next è l'ultimo nodo
        string removedTail = current.Next.Element;
        current.Next = null;
        return removedTail;
    }

    public override string ToString()
    {
        string s = "[";
        Node i = Head;
        while (i != null)
        {
            s = s + " " + i.ToString() + " ";
            i = i.Next;
        }
        s = s + "]";
        return s;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        MyList l = new MyList();
        l.AddTail("Aronne");
        l.AddTail("Tomas");
        l.AddTail("Domenico");

        Console.WriteLine("Lista iniziale: " + l.ToString());

        // Rimozione della testa
        string removedHead = l.RemoveHead();
        Console.WriteLine("Elemento rimosso dalla testa: " + removedHead);
        Console.WriteLine("Lista dopo RemoveHead: " + l.ToString());

        // Rimozione della coda
        string removedTail = l.RemoveTail();
        Console.WriteLine("Elemento rimosso dalla coda: " + removedTail);
        Console.WriteLine("Lista dopo RemoveTail: " + l.ToString());
    }
}
