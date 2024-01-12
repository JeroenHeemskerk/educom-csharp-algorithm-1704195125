using NUnit.Framework;
using Organizer;

namespace BornToMove.OrganizerTest;

public class RotateSortTest
{
        [Test]
        public void testSortEmpty() 
        {
            // prepare
            RotatePivotSort<int> sort = new RotatePivotSort<int>();
            List<int> input = new List<int>() {};
            IComparer<int> comparer = Comparer<int>.Default;


            // run
            var result = sort.RotateSort(input, comparer);

            // validate
            Assert.That(result, Is.Not.Null);                             
            Assert.That(result, Has.Exactly(0).Items);                     
            Assert.That(result, Is.EquivalentTo(new int[] { }));
            Assert.That(input, Is.EquivalentTo(new int[] { }));
        }

        [Test]
        public void testSortOneElement() 
        {
            // prepare
            RotatePivotSort<int> sort = new RotatePivotSort<int>();
            List<int> input = new List<int>() {2};
            IComparer<int> comparer = Comparer<int>.Default;


            // run
            var result = sort.RotateSort(input, comparer);

            // validate
            Assert.That(result, Is.Not.Null);                             
            Assert.That(result, Has.Exactly(1).Items);                     
            Assert.That(result, Is.EquivalentTo(new int[] { 2 }));
            Assert.That(input, Is.EquivalentTo(new int[] { 2 }));
        }

        [Test]
        public void testSortTwoElements() 
        {
            // prepare
            RotatePivotSort<int> sort = new RotatePivotSort<int>();
            List<int> input = new List<int>() { 8, 2 };
            IComparer<int> comparer = Comparer<int>.Default;


            // run
            var result = sort.RotateSort(input, comparer);

            // validate
            Assert.That(result, Is.Not.Null);                             
            Assert.That(result, Has.Exactly(2).Items);                     
            Assert.That(result, Is.EquivalentTo(new int[] { 2, 8 }));
            Assert.That(input, Is.EquivalentTo(new int[] { 8, 2 }));
        }

        [Test]
        public void testSortThreeEqual() 
        {
            // prepare
            RotatePivotSort<int> sort = new RotatePivotSort<int>();
            List<int> input = new List<int>() { 8, 8, 8 };
            IComparer<int> comparer = Comparer<int>.Default;


            // run
            var result = sort.RotateSort(input, comparer);

            // validate
            Assert.That(result, Is.Not.Null);                             
            Assert.That(result, Has.Exactly(3).Items);                     
            Assert.That(result, Is.EquivalentTo(new int[] { 8, 8, 8 }));
            Assert.That(input, Is.EquivalentTo(new int[] { 8, 8, 8 }));
        }

        [Test]
        public void testSortUnsortedArray() 
        {
            // prepare
            RotatePivotSort<int> sort = new RotatePivotSort<int>();
            List<int> input = new List<int>() { 8, 2, 4 };
            IComparer<int> comparer = Comparer<int>.Default;


            // run
            var result = sort.RotateSort(input, comparer);

            // validate
            Assert.That(result, Is.Not.Null);                             
            Assert.That(result, Has.Exactly(3).Items);                     
            Assert.That(result, Is.EquivalentTo(new int[] { 2, 4, 8 }));
            Assert.That(input, Is.EquivalentTo(new int[] { 8, 2, 4 }));
        }

        [Test]
        public void testSortUnsortedArrayOfSeven() 
        {
            // prepare
            RotatePivotSort<int> sort = new RotatePivotSort<int>();
            List<int> input = new List<int>() { 2, 4, 8, -2, 4, 8, 2 };
            IComparer<int> comparer = Comparer<int>.Default;


            // run
            var result = sort.RotateSort(input, comparer);

            // validate
            Assert.That(result, Is.Not.Null);                             
            Assert.That(result, Has.Exactly(7).Items);                     
            Assert.That(result, Is.EquivalentTo(new int[] { -2, 2, 2, 4, 4, 8, 8 }));
            Assert.That(input, Is.EquivalentTo(new int[] { 2, 4, 8, -2, 4, 8, 2 }));
        }
                
}
