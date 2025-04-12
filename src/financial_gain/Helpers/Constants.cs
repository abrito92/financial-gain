namespace financial_gain.Helpers
{
    /// <summary>
    /// Constants to be used in conditional comparions
    /// </summary>
    public static class Constants
    {

        /// <summary>
        /// This are the constants used for operations that are possible for our user to do. 
        /// </summary>
        public static class Operations
        {
            public const string Buy = "buy";
            public const string Sell = "sell";
        }

        /// <summary>
        /// This constants are general baseline values to be used for comparison and can be used in other points of the code. 
        /// We can achieve the same result using Environment Variables, something to keep in mind in future iterations.
        /// </summary>
        public static class Values
        {
            public const int IsentionBaseline = 20000;
        }
    }
}
