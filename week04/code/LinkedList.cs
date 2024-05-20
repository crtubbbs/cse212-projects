using System.Collections;

public class LinkedList : IEnumerable<int> {
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value) {
        // Create new node
        Node newNode = new Node(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null) {
            _head = _tail = newNode;
        } 
        // If the list is not empty, then only head will be affected.
        else {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value) {
        // Create new node
        Node newNode = new Node(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null) {
            _head = _tail = newNode;
        } 
        // If the list is not empty, then only tail will be affected.
        else {
            _tail!.Next = newNode; // Connect the previous tail to the new node
            newNode.Prev = _tail; // Connect the new node to the previous tail
            _tail = newNode; // Update the tail to point to the new node
        }
    }

    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead() {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list. This condition will also
        // cover an empty list. It's okay to set to null again.
        if (_head == _tail) {
            _head = _tail = null;
        } 
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null) {
            _head = _head.Next; // Update the head to point to the second node
            _head!.Prev = null; // Disconnect the second node from the first node
        }
    }

    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail() {
        // If the list is empty, do nothing
        if (_tail is null) return;
        // If the list has only one item in it, then set head and tail to null.
        if (_head == _tail) {
            _head = _tail = null;
        } 
        // If the list has more than one item in it, then only the tail will be affected.
        else {
            _tail = _tail.Prev; // Update the tail to point to the second-to-last node
            _tail!.Next = null; // Disconnect the last node from the second-to-last node
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue) {
        // Search for the node that matches 'value' by starting at the head of the list.
        for (Node? curr = _head; curr is not null; curr = curr.Next) {
            if (curr.Data == value) {
                // If the location of 'value' is at the end of the list,
                // then we can call InsertTail to add 'newValue'
                if (curr == _tail) {
                    InsertTail(newValue);
                } 
                // For any other location of 'value', need to create a new node and reconnect the links to insert.
                else {
                    Node newNode = new Node(newValue) {
                        Prev = curr, // Connect new node to the node containing 'value'
                        Next = curr.Next // Connect new node to the node after 'value'
                    };
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }
                return; // Exit the function after we insert
            }
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value) {
        // Search for the node that matches 'value' by starting at the head of the list.
        for (Node? curr = _head; curr is not null; curr = curr.Next) {
            if (curr.Data == value) {
                if (curr == _head) {
                    RemoveHead(); // If the node to be removed is the head
                } else if (curr == _tail) {
                    RemoveTail(); // If the node to be removed is the tail
                } else {
                    curr.Prev!.Next = curr.Next; // Connect the previous node to the next node
                    curr.Next!.Prev = curr.Prev; // Connect the next node to the previous node
                }
                return; // Exit the function after removing the node
            }
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value with 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue) {
        // Search for the node that matches 'oldValue' by starting at the head of the list.
        for (Node? curr = _head; curr is not null; curr = curr.Next) {
            if (curr.Data == oldValue) {
                curr.Data = newValue; // Replace the value
            }
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator() {
        // Start at the beginning since this is a forward iteration.
        for (Node? curr = _head; curr is not null; curr = curr.Next) {
            yield return curr.Data; // Provide (yield) each item to the user
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse() {
        // Start at the end since this is a backward iteration.
        for (Node? curr = _tail; curr is not null; curr = curr.Prev) {
            yield return curr.Data; // Provide (yield) each item to the user
        }
    }

    /// <summary>
    /// Returns a string representation of the linked list
    /// </summary>
    public override string ToString() {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public bool HeadAndTailAreNull() => _head is null && _tail is null;

    // Just for testing.
    public bool HeadAndTailAreNotNull() => _head is not null && _tail is not null;


    private class Node {
        public int Data { get; set; }
        public Node? Next { get; set; }
        public Node? Prev { get; set; }

        public Node(int data) {
            Data = data;
        }
    }
}
