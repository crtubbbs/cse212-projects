public static class Priority {
    public static void Test() {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        var priorityQueue = new PriorityQueue();
        Console.WriteLine(priorityQueue);

        // Test Cases

        // Test 1
        // Scenario: Enqueue items with different priorities and dequeue to ensure correct order.
        // Expected Result: The items should be dequeued in the order of their priorities.
        Console.WriteLine("Test 1");
        priorityQueue.Enqueue("Item 1", 2);
        priorityQueue.Enqueue("Item 2", 1);
        priorityQueue.Enqueue("Item 3", 3);
        Console.WriteLine("Dequeue 1: " + priorityQueue.Dequeue());
        Console.WriteLine("Dequeue 2: " + priorityQueue.Dequeue());
        Console.WriteLine("Dequeue 3: " + priorityQueue.Dequeue());

        // Defect(s) Found: No defects found.

        Console.WriteLine("---------");

        // Test 2
        // Scenario: Enqueue items with the same priority and dequeue to ensure FIFO order.
        // Expected Result: Items with the same priority should be dequeued in the order they were enqueued.
        Console.WriteLine("Test 2");
        priorityQueue.Enqueue("Item 1", 2);
        priorityQueue.Enqueue("Item 2", 2);
        priorityQueue.Enqueue("Item 3", 2);
        Console.WriteLine("Dequeue 1: " + priorityQueue.Dequeue());
        Console.WriteLine("Dequeue 2: " + priorityQueue.Dequeue());
        Console.WriteLine("Dequeue 3: " + priorityQueue.Dequeue());

        // Defect(s) Found: No defects found.

        Console.WriteLine("---------");

        // Test 3
        // Scenario: Try to dequeue from an empty queue.
        // Expected Result: InvalidOperationException should be thrown.
        Console.WriteLine("Test 3");
        try
        {
            priorityQueue.Dequeue();
            Console.WriteLine("Dequeue successful!");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }

        // Defect(s) Found: No defects found.

        Console.WriteLine("---------");

        // Add more Test Cases As Needed Below
    }
}
