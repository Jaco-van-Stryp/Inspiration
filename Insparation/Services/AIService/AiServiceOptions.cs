using System.ComponentModel.DataAnnotations;

namespace Insparation.Services.AIService;

public class AiServiceOptions
{
    [Required]
    public string ApiKey { get; set; } = string.Empty;
}
