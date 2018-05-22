namespace Algorithm
{
    /// <summary>
    /// This enum is used by <see cref="M:Finder.Find"/> to choose which type of query to do.
    /// </summary>
    public enum SearchType
    {
        /// <summary>
        /// Given a list of people, find the pair with the smallest age difference between them.
        /// </summary>
        SmallestDifference,

        /// <summary>
        /// Given a list of people, find the pair with the greatest age difference between them.
        /// </summary>
        GreatestDifference
    }
}