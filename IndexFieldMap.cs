namespace SolarCalculator
{
    /// <summary>
    ///   A mapping holding the column index for the field name
    /// </summary>
    public class IndexFieldMap
    {
        public IndexFieldMap(int index, string field)
        {
            Index = index;
            Field = field;
        }

        /// <summary>
        ///   Gets or sets the index.
        /// </summary>
        /// <value> The index. </value>
        public int Index { get; set; }

        /// <summary>
        ///   Gets or sets the field name.
        /// </summary>
        /// <value> The field. </value>
        public string Field { get; set; }
    }
}