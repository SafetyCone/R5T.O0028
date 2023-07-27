using System;

using R5T.T0198;
using R5T.T0200;


namespace R5T.O0028
{
    public class RepositoryCreationResult
    {
        public IGitHubRepositoryUrl GitHubRepositoryUrl { get; set; }
        public ILocalGitRepositoryDirectoryPath LocalGitRepositoryDirectoryPath { get; set; }
    }
}
