/**
 * Class to represent a queue using an array to store the queued items.
 * Follows a FIFO (First In First Out) order where new items are added to the
 * back and items are removed from the front.
 */
class Queue {
  /**
   * The constructor is executed when instantiating a new Queue() to construct
   * a new instance.
   * @returns {Queue} This new Queue instance is returned without having to
   *    explicitly write 'return' (implicit return).
   */
  constructor() {
    this.items = [];
  }

  // methods go here
  hello() {
    console.log("world");
  }
}
