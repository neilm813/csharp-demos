// Import our stack data structure to use in this file.
const Stack = require("./Stack");

/**
 * Class to represent a Queue but is implemented using two stacks to store the
 * queued items without using any other objects or arrays to store the items.
 * Retains the FIFO (First in First Out) ordering when adding / removing items.
 */
class TwoStackQueue {
  constructor() {
    this.stack1 = new Stack();
    this.stack2 = new Stack();
  }

  /**
   * Adds a new item to the back of the queue.
   * - Time: O(?).
   * - Space: O(?).
   * @param {any} item To be added.
   * @returns {number} The new number of items in the queue.
   */
  enqueue(item) {}

  /**
   * Removes the next item in the line / queue.
   * - Time: O(?).
   * - Space: O(?).
   * @returns {any} The removed item.
   */
  dequeue() {}
}
