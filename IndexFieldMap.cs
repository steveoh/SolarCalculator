namespace SolarCalculator
{
    public class IndexFieldMap
    {
        public IndexFieldMap(int index, string field)
        {
            Index = index;
            Field = field;
        }

        public int Index { get; set; }
        public string Field { get; set; }
    }
}