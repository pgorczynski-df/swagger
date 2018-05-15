using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Examples;

namespace SwaggerPhun.Controllers
{
    /// <summary>
    ///     REST API endpoint used for managing file comments
    /// </summary>
    /// <response code="400">If arguments are missing or invalid</response> 
    /// <response code="401">If the authentication header is missing or user was not authenticated</response> 
    /// <response code="500">If a server-side error occured</response> 
    [Route("[controller]")]
    [ProducesResponseType(typeof(ErrorDescriptor), 400)]
    [ProducesResponseType(typeof(ErrorDescriptor), 401)]
    [ProducesResponseType(typeof(ErrorDescriptor), 403)]
    [ProducesResponseType(typeof(ErrorDescriptor), 500)]
    public class FileCommentController : Controller
    {
        /// <summary>
        /// Returns the list of comments for a given file
        /// </summary>
        /// <param name="fileId">The id of the file</param>
        /// <returns></returns>
        /// <response code="400">If arguments are missing or invalid</response> 
        /// <response code="401">If the authentication header is missing or user was not authenticated</response> 
        /// <response code="403">When the user has no rights to see the file</response> 
        /// <response code="500">If a server-side error occured</response> 
        [HttpGet("{fileId}")]
        [ProducesResponseType(typeof(FileCommentCollectionDto), 200)]
        public FileCommentCollectionDto Get([FromRoute]int fileId)
        {
            return new FileCommentCollectionDto();
        }

        /// <summary>
        /// Adds a new comment to the file
        /// </summary>
        /// <param name="fileId">The id of the file</param>
        /// <param name="commentDto">The comment dto</param>
        /// <returns>Id of the newly created comment</returns>
        /// <response code="201">When file was created successfully</response> 
        /// <response code="400">If arguments are missing or invalid</response> 
        /// <response code="401">If the authentication header is missing or user was not authenticated</response> 
        /// <response code="403">When the user has no rights to see or comment the file</response> 
        /// <response code="500">If a server-side error occured</response> 
        [HttpPost("{fileId}")]
        [ProducesResponseType(201)]
        [SwaggerResponseHeader(201, "Location", "string", "url of the file created")]
        public int Post([FromRoute]int fileId, [FromBody] FileCommentDto commentDto)
        {
            return 1;
        }

        /// <summary>
        /// Updates an existing comment
        /// </summary>
        /// <param name="fileId"></param>
        /// <param name="commentId"></param>
        /// <param name="commentDto"></param>
        /// <response code="403">When the invoking user in not the author of the comment</response> 
        /// <response code="400">If arguments are missing or invalid</response> 
        /// <response code="401">If the authentication header is missing or user was not authenticated</response> 
        /// <response code="403">When the user has no rights to see or comment the file or is not the comment author</response> 
        /// <response code="500">If a server-side error occured</response> 
        [HttpPatch("{fileId}/{commentId}")]
        [ProducesResponseType(204)]
        public void Patch([FromRoute]int fileId, [FromRoute]int commentId, [FromBody] FileCommentDto commentDto)
        {
        }

        /// <summary>
        /// Deletes an existing comment
        /// </summary>
        /// <param name="fileId"></param>
        /// <param name="commentId"></param>
        /// <response code="400">If arguments are missing or invalid</response> 
        /// <response code="401">If the authentication header is missing or user was not authenticated</response> 
        /// <response code="403">When the user has no rights to see or comment the file</response> 
        /// <response code="500">If a server-side error occured</response> 
        [HttpDelete("{fileId}/{commentId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ErrorDescriptor), 403)]
        public void Delete([FromRoute]int fileId, [FromRoute]int commentId)
        {
        }
    }

    public class FileCommentCollectionDto
    {
        public string SelfLink { get; set; }

        public string Kind { get; set; }

        public FileCommentDto[] Contents { get; set; }
    }

    /// <summary>
    /// DTO object representing the comment
    /// </summary>
    public class FileCommentDto
    {
        /// <summary>
        /// The content text of the comment
        /// </summary>
        [Required] public string Text { get; set; }
    }

    /// <summary>
    /// Error descriptor object returned for non-2xx responses
    /// </summary>
    public class ErrorDescriptor
    {
        /// <summary>
        /// Verbose message that helps a developer understand the problem
        /// </summary>
        public string TechnicalMessage { get; set; }

        /// <summary>
        /// Concise message that is appropriate to display to a user
        /// </summary>
        public string UserMessage { get; set; }

        /// <summary>
        ///  ID of an error message that can be used to lookup more info in an error report
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// URL to documentation about the error
        /// </summary>
        public string MoreInfo { get; set; }
    }
}