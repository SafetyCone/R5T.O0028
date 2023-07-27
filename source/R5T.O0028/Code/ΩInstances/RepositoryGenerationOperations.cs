using System;


namespace R5T.O0028
{
    public class RepositoryGenerationOperations : IRepositoryGenerationOperations
    {
        #region Infrastructure

        public static IRepositoryGenerationOperations Instance { get; } = new RepositoryGenerationOperations();


        private RepositoryGenerationOperations()
        {
        }

        #endregion
    }
}
