
namespace HtmlRefactoringWindowsApp.Magazines
{
    public class MagazineBrands
    {
        private List<MagazineBrand> magazineBrands;

        private int count = 0;

        public int Count 
        { 
            get { return magazineBrands.Count; } 
        }

        public MagazineBrand this[int index]
        {
            get { return magazineBrands[index]; }
        }


        public MagazineBrands(string brandsText)
        {
            magazineBrands = new List<MagazineBrand>();
            ReadMagazineBrands(brandsText);
        }

            private void ReadMagazineBrands(string brandsText)
            {
                var brands = brandsText.Split('\n', StringSplitOptions.TrimEntries);

                foreach (var brand in brands)
                {
                    if (!string.IsNullOrWhiteSpace(brand))
                        magazineBrands.Add(new MagazineBrand(brand));
                }
            }
    }
}