using System.Threading.Tasks;

using GitLabApiClient.Internal.Paths;
using GitLabApiClient.Models.Files.Responses;

namespace GitLabApiClient
{
    public interface IFilesClient
    {
        Task<File> GetAsync(ProjectId projectId, string filePath, string reference = "master");
        Task<bool> ExistsAsync(ProjectId projectId, string filePath, string reference = "master");

        /// <summary>
        /// Downloads the repository archive (zip format) for a specific reference (branch, tag, or commit SHA).
        /// </summary>
        /// <param name="projectId">The ID, path or <see cref="Project"/> of the project.</param>
        /// <param name="reference">The reference (branch name, tag name, or commit SHA) to download.</param>
        /// <param name="outputPath">The local file path where the archive will be saved.</param>
        Task GetRepositoryArchiveAsync(ProjectId projectId, string reference, string outputPath);
    }
}
