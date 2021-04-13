# [Data Structures](../data_structures) Algo Schedule

---

## [Week 1 - Singly Linked Lists](../data_structures/SinglyLinkedList.js)

## [Week 2 - Stacks and Queues](../data_structures)

- [Stacks and Queues Intro](../data_structures/StacksAndQueues.md)
- [Stack](../data_structures/Stack.js)
- [LinkedListStack](../data_structures/LinkedListStack.js)
- [Queue](../data_structures/Queue.js)
- [LinkedListQueue](../data_structures/LinkedListQueue.js)

### W2 Mon

- A Stack is a LIFO (Last in First Out) data structure
- Design a class to represent a stack using an array to store the items
- Recreate the stack class using a singly linked list to store the items instead of an array
- Create these methods for each of the Stack classes with O(1) time complexity:
  - push (adds new item and returns new size)
  - pop (returns removed item)
  - isEmpty
  - size
  - peek (return top item without removing)

### W2 Tue

- A Queue is a FIFO (First in First Out) data structure
- Design a class to represent a queue using an array to store the items.
- Recreate the queue class using a singly linked list to store the items.
- Create these methods for each classes:
  - enqueue (add item, return new size)
  - dequeue (remove and return item)
  - isEmpty
  - size
  - front (return first item without removing)
- Time complexities should be as follows:
  - Array Queue: enqueue: O(1), dequeue: O(n), size: O(1), front: O(1)
  - Linked List Queue: enqueue: O(1), dequeue: O(1), size: O(1), front: O(1)
