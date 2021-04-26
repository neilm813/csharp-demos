/* 
Dedupe an array in O(n) time (no nested looping).
*/

const nums = [2, 1, 5, 1, 2, 4, 5];

/**
 * Deduplicates the given array into a new array such that the new array
 * contains each number only once.
 * - Time: O(n^2) quadratic, n = nums.length.
 * - Space: O(n) linear.
 * @param {Array<number>} nums
 * @returns {Array<number>} Each number without duplicates.
 */
function dedupeSlow(nums) {
  const deduped = [];

  for (let i = 0; i < nums.length; i++) {
    const currentNum = nums[i];
    let dupeFound = false;

    for (let j = 0; j < deduped.length; j++) {
      const comparisonNum = nums[j];

      if (currentNum === comparisonNum) {
        dupeFound = true;
        break;
      }
    }

    if (!dupeFound) {
      deduped.push(currentNum);
    }
  }
  return deduped;
}

/**
 * Deduplicates the given array into a new array such that the new array
 * contains each number only once.
 * - Time: O(n) linear, n = nums.length.
 * - Space: O(2n) -> O(n) linear.
 * @param {Array<number>} nums
 * @returns {Array<number>} Each number without duplicates.
 */
function dedupe(nums) {
  const deduped = [];
  const seen = {};

  for (let i = 0; i < nums.length; i++) {
    const num = nums[i];

    if (!seen.hasOwnProperty(num)) {
      deduped.push(num);
    }
    seen[num] = true;
  }
  return deduped;
}

console.log(dedupe(nums));
