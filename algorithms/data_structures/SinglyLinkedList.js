/**
 * Class to represents a single item of a SinglyLinkedList that can be
 * linked to other Node instances to form a list of linked nodes.
 */
class Node {
  /**
   * Constructs a new Node instance. Executed when the 'new' keyword is used.
   * @param {any} data The data to be added into this new instance of a Node.
   *    The data can be anything, just like an array can contain strings,
   *    numbers, objects, etc.
   * @returns {Node} A new Node instance is returned automatically without
   *    having to be explicitly written (implicit return).
   */
  constructor(data) {
    this.data = data;
    /**
     * This property is used to link this node to whichever node is next
     * in the list. By default, this new node is not linked to any other
     * nodes, so the setting / updating of this property will happen sometime
     * after this node is created.
     */
    this.next = null;
  }
}

/**
 * Class to represent a list of linked nodes. Nodes CAN be linked together
 * without this class to form a linked list, but this class helps by providing
 * a place to keep track of the start node (head) of the list at all times and
 * as a place to add methods (functions inside an object) so that every new
 * linked list that is instantiated will inherit helpful the same helpful
 * methods, just like every array you create inherits helpful methods.
 */
class SinglyLinkedList {
  /**
   * Constructs a new instance of an empty linked list that inherits all the
   * methods.
   * @returns {SinglyLinkedList} The new list that is instantiated is implicitly
   *    returned without having to explicitly write "return".
   */
  constructor() {
    this.head = null;
  }

  /**
   * Calls insertAtBack on each item of the given array.
   * - Time: O(n * m) n = list length, m = arr.length.
   * - Space: O(1) constant.
   * @param {Array<any>} vals The data for each new node.
   * @returns {SinglyLinkedList} This list.
   */
  seedFromArr(vals) {
    for (const item of vals) {
      this.insertAtBack(item);
    }
    return this;
  }

  /**
   * Converts this list into an array containing the data of each node.
   * - Time: O(n) linear.
   * - Space: O(n).
   * @returns {Array<any>} An array of each node's data.
   */
  toArr() {
    const arr = [];
    let runner = this.head;

    while (runner) {
      arr.push(runner.data);
      runner = runner.next;
    }
    return arr;
  }

  print() {
    console.log(this.toArr());
  }

  /**
   * Determines if this list is empty.
   * - Time: (?).
   * - Space: (?).
   * @returns {boolean}
   */
  isEmpty() {
    return this.head === null;
  }

  /**
   * Creates a new node with the given data and inserts it at the back of
   * this list.
   * - Time: (?).
   * - Space: (?).
   * @param {any} data The data to be added to the new node.
   * @returns {SinglyLinkedList} This list.
   */
  insertAtBack(data) {
    const newBack = new Node(data);

    if (this.isEmpty()) {
      this.head = newBack;
      return this;
    }

    let runner = this.head;

    while (runner.next !== null) {
      runner = runner.next;
    }

    runner.next = newBack;
    return this;
  }
  /**
   * Creates a new node with the given data and inserts that node at the front
   * of this list.
   * - Time: (?).
   * - Space: (?).
   * @param {any} data The data for the new node.
   * @returns {SinglyLinkedList} This list.
   */
  insertAtFront(data) {}

  /**
   * Removes the first node of this list.
   * - Time: (?).
   * - Space: (?).
   * @returns {any} The data from the removed node.
   */
  removeHead() {}
}

const emptyList = new SinglyLinkedList();

const singleNodeList = new SinglyLinkedList().seedFromArr([1]);
const biNodeList = new SinglyLinkedList().seedFromArr([1, 2]);
const firstThreeList = new SinglyLinkedList().seedFromArr([1, 2, 3]);
const secondThreeList = new SinglyLinkedList().seedFromArr([4, 5, 6]);
const unorderedList = new SinglyLinkedList().seedFromArr([
  -5, -10, 4, -3, 6, 1, -7, -2,
]);

// node 4 connects to node 1, back to head
const perfectLoopList = new SinglyLinkedList().seedFromArr([1, 2, 3, 4]);
perfectLoopList.head.next.next.next = perfectLoopList.head;

// node 4 connects to node 2
const loopList = new SinglyLinkedList().seedFromArr([1, 2, 3, 4]);
loopList.head.next.next.next = loopList.head.next;

const sortedDupeList = new SinglyLinkedList().seedFromArr([
  1, 1, 1, 2, 3, 3, 4, 5, 5,
]);

firstThreeList.print();
