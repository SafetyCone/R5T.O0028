using System;
using System.Threading.Tasks;

using R5T.F0000.Extensions.ForObject;
using R5T.T0131;
using R5T.T0159;
using R5T.T0184;
using R5T.T0198.Extensions;
using R5T.T0200.Extensions;
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

            var repositoryOwnerName = Instances.OrganizationNameOperator.Get_RepositoryOwnerName(organizationName);

            textOutput.WriteInformation($"Creating repository...");

            textOutput.WriteInformation($"{repositoryOwnerName}/{adjustedRepositoryName}: repository name");

            await Instances.RepositoryOperations.Create_Repository_WithGitIgnore(
                adjustedRepositoryName,
                repositoryDescription,
                repositoryOwnerName,
                isPrivate,
                textOutput,
                this.Handle_CreationResult(out var repositoryCreationResult));

            textOutput.WriteInformation($"Created repository.");

            textOutput.WriteInformation($"GitHub URL:\n\t{repositoryCreationResult.GitHubRepositoryUrl}");
            textOutput.WriteInformation($"Local Git directory path:\n\t{repositoryCreationResult.LocalGitRepositoryDirectoryPath}");

            return repositoryCreationResult;
        }

        public Action<L0036.T000.N001.IGitHubRepositoryContext, string> Handle_CreationResult(out RepositoryCreationResult repositoryCreationResult)
        {
            repositoryCreationResult = new RepositoryCreationResult();

            return this.Handle_CreationResult(repositoryCreationResult);
        }

        public Action<L0036.T000.N001.IGitHubRepositoryContext, string> Handle_CreationResult(RepositoryCreationResult repositoryCreationResult)
        {
            return (gitHubRepositoryContext, localGitRepositoryDirectoryPath) =>
            {
                repositoryCreationResult.GitHubRepositoryUrl = $@"https://github.com/{gitHubRepositoryContext.OwnerName}/{gitHubRepositoryContext.RepositoryName}".ToGitHubRepositoryUrl();
                repositoryCreationResult.LocalGitRepositoryDirectoryPath = localGitRepositoryDirectoryPath
                    .Change(Instances.PathOperator.Ensure_IsDirectoryIndicated)
                    .ToLocalGitRepositoryDirectoryPath();
            };
        }
    }
}
