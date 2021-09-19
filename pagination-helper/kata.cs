using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace katas.pagination_helper
{
    public class PagnationHelper<T>
    {
        private Dictionary<int, List<T>> _pages = new Dictionary<int, List<T>>();
        private Dictionary<int, int> _indexPages = new Dictionary<int, int>();
        private readonly IList<T> _collection;

        // TODO: Complete this class

        /// <summary>
        /// Constructor, takes in a list of items and the number of items that fit within a single page
        /// </summary>
        /// <param name="collection">A list of items</param>
        /// <param name="itemsPerPage">The number of items that fit within a single page</param>
        public PagnationHelper(IList<T> collection, int itemsPerPage)
        {
            _collection = collection;

            var page = 0;
            _pages[0] = new List<T>();

            for (var i = 0; i < collection.Count; i++)
            {
                if ( i > 1 && i % itemsPerPage == 0)
                {
                    page++;

                    if (!_pages.ContainsKey(page))
                    {
                        _pages.Add(page, new List<T>());
                    }
                }
                _pages[page].Add(collection[i]);
                _indexPages.Add(i, page);
            }
        }

        /// <summary>
        /// The number of items within the collection
        /// </summary>
        public int ItemCount
        {
            get => _collection.Count;
        }

        /// <summary>
        /// The number of pages
        /// </summary>
        public int PageCount
        {
            get => _pages.Count;
        }

        /// <summary>
        /// Returns the number of items in the page at the given page index
        /// </summary>
        /// <param name="pageIndex">The zero-based page index to get the number of items for</param>
        /// <returns>The number of items on the specified page or -1 for pageIndex values that are out of range</returns>
        public int PageItemCount(int pageIndex) => _pages.TryGetValue(pageIndex, out var page) ? page.Count : -1;

        /// <summary>
        /// Returns the page index of the page containing the item at the given item index.
        /// </summary>
        /// <param name="itemIndex">The zero-based index of the item to get the pageIndex for</param>
        /// <returns>The zero-based page index of the page containing the item at the given item index or -1 if the item index is out of range</returns>
        public int PageIndex(int itemIndex) => _indexPages.TryGetValue(itemIndex, out var page) ? page : -1;
    }

    [TestFixture]
    public class SolutionTest
    {
        private readonly IList<int> collection = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24};
        private PagnationHelper<int> helper;

        [SetUp]
        public void SetUp()
        {
            helper = new PagnationHelper<int>(collection, 10);
        }

        [Test]
        [TestCase(-1, ExpectedResult=-1)]
        [TestCase(1, ExpectedResult=10)]
        [TestCase(3, ExpectedResult=-1)]
        public int PageItemCountTest(int pageIndex)
        {
            return helper.PageItemCount(pageIndex);
        }

        [Test]
        [TestCase(-1, ExpectedResult=-1)]
        [TestCase(12, ExpectedResult=1)]
        [TestCase(24, ExpectedResult=-1)]
        public int PageIndexTest(int itemIndex)
        {
            return helper.PageIndex(itemIndex);
        }

        [Test]
        public void ItemCountTest()
        {
            Assert.AreEqual(24, helper.ItemCount);
        }

        [Test]
        public void PageCountTest()
        {
            Assert.AreEqual(3, helper.PageCount);
        }
    }
}