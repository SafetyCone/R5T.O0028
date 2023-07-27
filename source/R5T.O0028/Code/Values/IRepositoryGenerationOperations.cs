using System;
using System.Threading.Tasks;

using R5T.T0131;
using R5T.T0159;
using R5T.T0184;
using R5T.T0222;


namespace R5T.O0028
{
    [ValuesMarker]
    public partial interface IRepositoryGenerationOperations : IValuesMarker
    {
        /// <summary>
        /// Creates an empty repository.
        /// </summary>
        /// <remarks>
        /// Ensures the repository has a .gitignore file, but does nothing else.
        /// </remarks>
        public async Task<RepositoryCreationResult> Create_Repository(
            IRepositoryName repositoryName,
            IRepositoryDescription repositoryDescription,
            IOrganizationName organizationName,
            bool isPrivate,
            ITextOutput textOutput)
        {
            var adjustedRepositoryName = Instances.RepositoryNameOperator.AdjustRepositoryName_ForPrivacy(
                repositoryName,
                isPrivate);

            //var repositoryOwnerName = Instances.

            throw new NotImplementedException();
        }
    }
}
