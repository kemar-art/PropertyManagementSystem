using Microsoft.AspNetCore.Mvc;

namespace API.Models
{
    public class CustomProblemsDetails : ProblemDetails
    {
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}
