using System;
using System.Collections.Generic;

public class TakingTurnsQueue {
    private Queue<Person> queue = new Queue<Person>();

    public int Length {
        get { return queue.Count; }
    }

    public void AddPerson(string name, int turns) {
        queue.Enqueue(new Person(name, turns));
    }

    public void GetNextPerson() {
        if (queue.Count == 0) {
            Console.WriteLine("Error: Queue is empty");
            return;
        }

        Person person = queue.Dequeue();
        Console.WriteLine(person.Name);

        if (person.Turns >= 1 || person.Turns == 0) { // Fix: Handling infinite turns correctly
            person.Turns--; // Decrement turns
            queue.Enqueue(person); // Re-add to queue
        }
    }

    private class Person {
        public string Name { get; }
        public int Turns { get; set; }

        public Person(string name, int turns) {
            Name = name;
            Turns = turns;
        }
    }
}