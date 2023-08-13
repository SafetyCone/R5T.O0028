using System;
using System.Threading.Tasks;

using R5T.T0131;
using R5T.T0159;
using R5T.T0184;
using R5T.T0222;


namespace R5T.O0028
{
    [ValuesMarker]
    public partial interface IRepositoryOperations : IValuesMarker
    {
        /// <summary>
        /// Deletes a repository.
        /// </summary>
        /// <remarks>
        /// Ensures the repository has a .gitignore file, but does nothing else.
        /// </remarks>
        public async Task Delete_Repository(
            IRepositoryName repositoryName,
            IOrganizationName organizationName,
            bool isPrivate,
            ITextOutput textOutput)
        {
            var adjustedRepositoryName = Instances.RepositoryNameOperator.AdjustRepositoryName_ForPrivacy(
                repositoryName,
                isPrivate);

            var repositoryOwnerName = Instances.OrganizationNameOperator.Get_RepositoryOwnerName(organizationName);

            textOutput.WriteInformation($"Deleting repository...");

            textOutput.WriteInformation($"{repositoryOwnerName}/{adjustedRepositoryName}: repository name");

            await Instances.RepositoryOperations.Delete_Repository(
                adjustedRepositoryName,
                repositoryOwnerName,
                textOutput);

            textOutput.WriteInformation($"Deleted repository.");
        }
    }
}
