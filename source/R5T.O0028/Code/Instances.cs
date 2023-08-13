using System;


namespace R5T.O0028
{
    public static class Instances
    {
        public static F0143.F001.IOrganizationNameOperator OrganizationNameOperator => F0143.F001.OrganizationNameOperator.Instance;
        public static F0002.IPathOperator PathOperator => F0002.PathOperator.Instance;
        public static IRepositoryGenerationOperations RepositoryGenerationOperations => O0028.RepositoryGenerationOperations.Instance;
        public static F0142.IRepositoryNameOperator RepositoryNameOperator => F0142.RepositoryNameOperator.Instance;
        public static O0016.IRepositoryOperations RepositoryOperations => O0016.RepositoryOperations.Instance;
    }
}