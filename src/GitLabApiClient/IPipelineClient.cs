using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLabApiClient.Internal.Paths;
using GitLabApiClient.Models.Job.Requests;
using GitLabApiClient.Models.Job.Responses;
using GitLabApiClient.Models.Pipelines.Requests;
using GitLabApiClient.Models.Pipelines.Responses;

namespace GitLabApiClient
{
    public interface IPipelineClient
    {
        Task<PipelineDetail> CancelAsync(ProjectId projectId, int pipelineId);
        Task<PipelineDetail> CreateAsync(ProjectId projectId, CreatePipelineRequest request);
        Task DeleteAsync(ProjectId projectId, int pipelineId);
        Task<IList<Pipeline>> GetAsync(ProjectId projectId, Action<PipelineQueryOptions> options = null);
        Task<PipelineDetail> GetAsync(ProjectId projectId, int pipelineId);
        Task<IList<Job>> GetJobsAsync(ProjectId projectId, int pipelineId, Action<JobQueryOptions> options = null);
        Task<IList<PipelineVariable>> GetVariablesAsync(ProjectId projectId, int pipelineId);
        Task<PipelineDetail> RetryAsync(ProjectId projectId, int pipelineId);

        /// <summary>
        /// Downloads all artifacts from a pipeline (zip format).
        /// </summary>
        /// <param name="projectId">The ID, path or <see cref="Project"/> of the project.</param>
        /// <param name="pipelineId">The ID of the pipeline.</param>
        /// <param name="outputPath">The local file path where the artifacts archive will be saved.</param>
        Task GetArtifactsArchiveAsync(ProjectId projectId, int pipelineId, string outputPath);

        /// <summary>
        /// Downloads artifacts from a specific job (zip format).
        /// </summary>
        /// <param name="projectId">The ID, path or <see cref="Project"/> of the project.</param>
        /// <param name="jobId">The ID of the job.</param>
        /// <param name="outputPath">The local file path where the artifacts archive will be saved.</param>
        Task GetJobArtifactsAsync(ProjectId projectId, int jobId, string outputPath);
    }
}
