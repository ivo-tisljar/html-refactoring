using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlRefactoringWindowsApp.Enums
{
    public enum Segment
    {
        Paragraph = 0,
        Title = 1,
        TitleOrParagraph = 2,
        Table = 3,
        Image = 4,
        Unspecified = 5,
        Whatever = 6
    }

    public static class SegmentExtensions
    {
        private struct SegmentData
        {
            public string Name;
        }

        private static readonly SegmentData[] segmentData = new SegmentData[]
        {
            new SegmentData { Name ="Paragraph" },
            new SegmentData { Name ="Title" },
            new SegmentData { Name ="Title or Paragraph" },
            new SegmentData { Name ="Table" },
            new SegmentData { Name ="Image" },
            new SegmentData { Name ="Unspecified" },
            new SegmentData { Name ="Whatever" }
        };

        public static string GetName(this Segment segment)
        {
            if (segment.IsDefined())
            {
                return segmentData[(int)segment].Name;
            }
            throw new ArgumentOutOfRangeException($"Invalid value! Value {segment} is NOT valid for type Segment.");
        }

        public static bool IsDefined(this Segment segment)
        {
            return segment >= Segment.Paragraph && segment <= Segment.Whatever;
        }
    }
}
