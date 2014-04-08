using System.Collections.Generic;
using System.Linq;
using Algorithms.Sources.SkipLists;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class SkipListsTests
    {
        [Test]
        public void General()
        {
            for (int i = 0; i < 10000; i++)
            {
                test();
            }
        }

        private void test()
        {
            var list = new SkipList();
            var toInsert = new[] { 7, 2, 9, 1, 10 };
            foreach (var value in toInsert)
            {
                list.Insert(value);
            }

            // test whether the elements were inserted
            var listValues = list.GetElements();
            var sortedList = toInsert.ToList();
            sortedList.Sort();
            Assert.That(listValues.ToList(), Is.EquivalentTo(sortedList));

            list.PrintConfiguration();

            // test the existence of different values
            var mapExistence = new Dictionary<int, bool> 
                          {
                              { 0, false },
                              { 1, true },
                              { 2, true },
                              { 3, false },
                              { 4, false },
                              { 5, false },
                              { 6, false },
                              { 7, true },
                              { 8, false },
                              { 9, true },
                              { 10, true }
                          };
            foreach (var pair in mapExistence)
            {
                Assert.AreEqual(list.Exists(pair.Key), pair.Value);
            }

            // find closest elementvar mapExistence = new Dictionary<int, bool> 
            var mapClosest = new Dictionary<int, int> 
                          {
                              { 0, 1 },
                              { 1, 1 },
                              { 2, 2 },
                              { 3, 2 },
                              { 4, 2 },
                              { 5, 7 },
                              { 6, 7 },
                              { 7, 7 },
                              { 8, 7 },
                              { 9, 9 },
                              { 10, 10 }
                          };
            foreach (var pair in mapClosest)
            {
                Assert.AreEqual(list.FindClosestElement(pair.Key), pair.Value);
            }

            // find k-th largest element
            var mapKth = new Dictionary<int, int?> 
                          {
                              { 1, 1 },
                              { 2, 2 },
                              { 3, 7 },
                              { 4, 9 },
                              { 5, 10 }
                          };
            foreach (var pair in mapKth)
            {
                Assert.AreEqual(list.FindKLargestElement(pair.Key), pair.Value);
            }

            // count elements in range
            var rangeList = new List<dynamic>
                {
                    new
                        {
                            Left = 0,
                            Right = 11,
                            Count = 5
                        },
                    new
                        {
                            Left = 1,
                            Right = 10,
                            Count = 5     
                        },
                    new
                        {
                            Left = 2,
                            Right = 10,
                            Count = 4     
                        },
                    new
                        {
                            Left = 3,
                            Right = 10,
                            Count = 3     
                        },
                    new
                        {
                            Left = 7,
                            Right = 10,
                            Count = 3     
                        },
                    new
                        {
                            Left = 8,
                            Right = 10,
                            Count = 2     
                        },
                    new
                        {
                            Left = 9,
                            Right = 10,
                            Count = 2     
                        },
                    new
                        {
                            Left = 10,
                            Right = 10,
                            Count = 1     
                        },
                    new
                        {
                            Left = 10,
                            Right = 11,
                            Count = 1     
                        },
                    new
                        {
                            Left = 11,
                            Right = 11,
                            Count = 0     
                        },
                    new
                        {
                            Left = 1,
                            Right = 9,
                            Count = 4     
                        },
                    new
                        {
                            Left = 1,
                            Right = 8,
                            Count = 3     
                        },
                    new
                        {
                            Left = 1,
                            Right = 7,
                            Count = 3     
                        },
                    new
                        {
                            Left = 1,
                            Right = 6,
                            Count = 2     
                        },
                    new
                        {
                            Left = 1,
                            Right = 2,
                            Count = 2     
                        },
                    new
                        {
                            Left = 1,
                            Right = 1,
                            Count = 1     
                        },
                    new
                        {
                            Left = 3,
                            Right = 7,
                            Count = 1     
                        },
                    new
                        {
                            Left = 3,
                            Right = 9,
                            Count = 2     
                        },
                    new
                        {
                            Left = 1,
                            Right = 6,
                            Count = 2     
                        },
                    new
                        {
                            Left = 3,
                            Right = 4,
                            Count = 0     
                        }
                };

            foreach (var element in rangeList)
            {
               Assert.AreEqual(list.CountElementsInRange(element.Left, element.Right), element.Count);
            }


            // remove each element from the map
            foreach (var key in mapExistence.Keys)
            {
                list.Remove(key);
                Assert.IsFalse(list.Exists(key));
            }
        }
    }
}