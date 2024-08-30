using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowBigIsTheShift
{
    public class NumericShiftDetector
    {
        private int[] nums;

        public int GetShiftPosition(int[] initialArray)
        {
            nums = initialArray;
            int length = initialArray.Length;
            if (initialArray[0] < initialArray[length - 1]) return 0;
            return findShift(0, length - 1);
        }

        public int findShift(int left, int right)
        {
            if (left == right) return left;
            int mid = (left + right) / 2;

            if (nums[mid] > nums[mid + 1]) return mid + 1;
            if (nums[mid] < nums[mid - 1]) return mid;

            if (nums[mid] > nums[right]) return findShift(mid + 1, right);
            else return findShift(left, mid);
        }
    }
}
