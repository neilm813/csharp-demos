/**
 * Class to represent a Node for a DoublyLinkedList.
 */
class Node {
  /**
   * Executed when the new keyword is used to construct a new node instance.
   * @param {any} data The data the new node will store.
   */
  constructor(data) {
    this.data = data;
    /**
     * By default a new node instance will not be connected to any other nodes,
     * these properties will be set after instantiation to connect the node to
     * a list. However, the head prev should remain null.
     */
    this.prev = null;
    this.next = null;
  }
}

/**
 * Class to represent a doubly linked list. Nodes can be linked together
 * WITHOUT this class to form a list, but the class is helpful to give all
 * doubly linked lists access to the same helpful methods for consistency
 * and to always keep track of the head and the tail nodes.
 *
 * Unlike a singly linked list, a doubly linked list allows you to traverse
 * backwards as well.
 */
class DoublyLinkedList {
  /**
   * Executed when the new keyword is used to construct a new DoublyLInkedList
   * instance that inherits these methods and properties.
   */
  constructor() {
    // The list is empty to start.
    this.head = null;
    this.tail = null;
  }

  /**
   * Determines if this list is empty.
   * - Time: O(1) constant.
   * - Space: O(1) constant.
   * @returns {boolean} Indicates if this list is empty.
   */
  isEmpty() {
    return this.head === null;
  }

  /**
   * Converts this list to an array of the node's data.
   * - Time: O(n) linear, n = list length.
   * - Space: O(n) linear, array grows as list length increases.
   * @returns {Array<any>} All the data of the nodes.
   */
  toArray() {
    const vals = [];
    let runner = this.head;

    while (runner) {
      vals.push(runner.data);
      runner = runner.next;
    }
    return vals;
  }

  /**
   * Adds all the given items to the back of this list.
   * @param {Array<any>} items Items to be added to the back of this list.
   * @returns {DoublyLinkedList} This list.
   */
  seedFromArr(items = []) {
    items.forEach((item) => this.insertAtBack(item));
    return this;
  }

  /**
   * Creates a new node and adds it at the front of this list.
   * - Time: O(1) constant.
   * - Space: O(1) constant.
   * @param {any} data The data for the new node.
   * @returns {DoublyLinkedList} This list.
   */
  insertAtFront(data) {
    const newNode = new Node(data);

    if (!this.head) {
      this.head = this.tail = newNode;
    } else {
      this.head.prev = newNode;
      newNode.next = this.head;
      this.head = newNode;
    }
    return this;
  }
  /**
   * Creates a new node and adds it at the back of this list.
   * - Time: O(1) constant. No loop is needed since we have direct access to
   *    the tail.
   * - Space: O(1) constant.
   * @param {any} data The data for the new node.
   * @returns {DoublyLinkedList} This list.
   */
  insertAtBack(data) {
    const newTail = new Node(data);

    if (!this.head) {
      // if no head set the newTail to be both the head and the tail
      this.head = this.tail = newTail;
    } else {
      this.tail.next = newTail;
      newTail.prev = this.tail;

      this.tail = newTail;
    }
    return this;
  }

  /**
   * Removes the middle node in this list.
   * - Time: O(0.5n) -> O(n) linear, n = list length.
   *    Since it's not constant we simplify it to O(n). Without the early
   *    exists, it would not be 0.5n.
   * - Space: O(1) constant.
   * @returns {any} The data of the removed node.
   */
  removeMiddleNode() {
    // when there is only 1 node, it is the middle, remove it.
    if (!this.isEmpty() && this.head === this.tail) {
      const removedData = this.head.data;
      this.head = null;
      this.tail = null;
      return removedData;
    }

    let forwardRunner = this.head;
    let backwardsRunner = this.tail;

    while (forwardRunner && backwardsRunner) {
      if (forwardRunner === backwardsRunner) {
        const midNode = forwardRunner;
        midNode.prev.next = midNode.next;
        midNode.next.prev = midNode.prev;
        return midNode.data;
      }

      // runners passed each other without stopping on the same node, even length, we can exit early
      if (forwardRunner.prev === backwardsRunner) {
        return null;
      }

      forwardRunner = forwardRunner.next;
      backwardsRunner = backwardsRunner.prev;
    }
    return null;
  }
}
