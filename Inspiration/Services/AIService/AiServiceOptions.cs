using System.ComponentModel.DataAnnotations;

namespace Inspiration.Services.AIService;

public class AiServiceOptions
{
    [Required]
    public string ApiKey { get; set; } = string.Empty;
}
