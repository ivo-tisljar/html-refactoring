using HtmlRefactoringWindowsApp.Magazines;

namespace HtmlRefactoringTests
{
    public class MagazineBrands
    {
        public int Count { get { return 0; } }

        public MagazineBrands(string brands)
        {
            if (!string.IsNullOrWhiteSpace(brands))
            {
                var magazineBrand = new MagazineBrand(brands);
            }
        }
    }
}