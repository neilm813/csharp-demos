/* 
Given two arrays of hashtags, find the overlapping hashtags.
*/

const tags1 = [
  "photooftheday",
  "nofilter",
  "tbt",
  "picoftheday",
  "love",
  "nature",
];
const tags2 = ["swag", "nofilter", "selfie", "picoftheday", "love"];

/**
 * Finds the shared hashtags between the two given arrays.
 * - Time: O(n * m) n = tagsA.length, m = tagsB.length.
 * - Space: O(n) linear.
 * @param {Array<string>} tagsA
 * @param {Array<string>} tagsB
 * @returns {Array<string>} The shared hashtags.
 */
function findSharedHashtagsSlow(tagsA, tagsB) {
  const matchingTags = [];

  for (let i = 0; i < tagsA.length; i++) {
    for (let j = 0; j < tagsB.length; j++) {
      if (tagsA[i] === tagsB[j]) {
        matchingTags.push(tagsA[i]);
      }
    }
  }

  return matchingTags;
}

/**
 * Finds the shared hashtags between the two given arrays.
 * - Time: O(n + m) -> O(n) n = tagsA.length, m = tagsB.length.
 * - Space: O(2n) -> O(n) linear.
 * @param {Array<string>} tagsA
 * @param {Array<string>} tagsB
 * @returns {Array<string>} The shared hashtags.
 */
function findSharedHashtagsSlow(tagsA, tagsB) {
  const matchingTags = [];
  const seenTagsA = {};

  for (const tagA of tagsA) {
    seenTagsA[tagA] = true;
  }

  for (const tagB of tagsB) {
    if (seenTagsA.hasOwnProperty(tagB)) {
      matchingTags.push(tagB);
    }
  }

  return matchingTags;
}

console.log(findSharedHashtagsSlow(tags1, tags2));
