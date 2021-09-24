using FluentAssertions;
using NUnit.Framework;

namespace katas.calendar
{
    [TestFixture]
    public class Solution
    {
        public static bool IsAvailable(int[][] meetings, int start, int end)
        {
            foreach (var meetingRange in meetings)
            {
                var meetingStart = meetingRange[0];
                var meetingEnd = meetingRange[1];

                if (meetingStart == start)
                {
                    return false;
                }

                if (meetingStart < start)
                {
                    if (meetingEnd > start && (meetingEnd <= end || meetingEnd > end))
                    {
                        return false;
                    }
                }
                else if (meetingStart > start && meetingEnd > start)
                {
                    if (meetingEnd <= end)
                    {
                        return false;
                    }

                    if (meetingStart < end)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        [Test]
        public void CalendarTests()
        {
            int[][] meetings =
            {
                new[] { 1230, 1300 },
                new[] { 845, 900 },
                new[] { 1300, 1500 }
            };

            IsAvailable(meetings, 915, 1215).Should().Be(true);
            IsAvailable(meetings, 900, 1230).Should().Be(true);
            IsAvailable(meetings, 850, 1240).Should().Be(false);
            IsAvailable(meetings, 1200, 1300).Should().Be(false);
            IsAvailable(meetings, 700, 1600).Should().Be(false);
            IsAvailable(meetings, 800, 845).Should().Be(true);
            IsAvailable(meetings, 1500, 1800).Should().Be(true);
            IsAvailable(meetings, 845, 859).Should().Be(false);
            IsAvailable(meetings, 846, 900).Should().Be(false);
            IsAvailable(meetings, 846, 859).Should().Be(false);
            IsAvailable(meetings, 845, 900).Should().Be(false);
            IsAvailable(meetings, 2359, 2400).Should().Be(true);
            IsAvailable(meetings, 930, 1600).Should().Be(false);
            IsAvailable(meetings, 800, 850).Should().Be(false);
            IsAvailable(meetings, 1400, 1600).Should().Be(false);
            IsAvailable(meetings, 1300, 1501).Should().Be(false);
            IsAvailable(meetings, 1600, 1700).Should().Be(true);
            IsAvailable(meetings, 100, 500).Should().Be(true);
        }
    }
}