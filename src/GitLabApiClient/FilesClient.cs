using System.Net;
using System.Threading.Tasks;

using GitLabApiClient.Internal.Http;
using GitLabApiClient.Internal.Paths;
using GitLabApiClient.Internal.Utilities;
using GitLabApiClient.Models.Files.Responses;

namespace GitLabApiClient
{
    public sealed class FilesClient : IFilesClient
    {
        private readonly GitLabHttpFacade _httpFacade;

        internal FilesClient(GitLabHttpFacade httpFacade) => _httpFacade = httpFacade;

        public async Task<File> GetAsync(ProjectId projectId, string filePath, string reference = "master")
        {
            return await _httpFacade.Get<File>($"projects/{projectId}/repository/files/{filePath.UrlEncode()}?ref={reference}");
        }

        public async Task<bool> ExistsAsync(ProjectId projectId, string filePath, string reference = "master")
        {
            var response = await _httpFacade.Head($"projects/{projectId}/repository/files/{filePath.UrlEncode()}?ref={reference}");
            return response.StatusCode switch
            {
                HttpStatusCode.OK => true,
                HttpStatusCode.NotFound => false,
                _ => throw new GitLabException(response.StatusCode, "")
            };
        }

        public async Task GetRepositoryArchiveAsync(ProjectId projectId, string reference, string outputPath)
        {
            Guard.NotEmpty(reference, nameof(reference));
            Guard.NotEmpty(outputPath, nameof(outputPath));

            await _httpFacade.GetFile($"projects/{projectId}/repository/archive.zip?sha={reference}", outputPath);
        }
    }
}
