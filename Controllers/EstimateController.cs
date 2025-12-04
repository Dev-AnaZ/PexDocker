using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DevCostAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstimateController : ControllerBase
{
    private readonly IValidator<EstimateRequest> _validator;
    private readonly ILogger<EstimateController> _logger;

    public EstimateController(IValidator<EstimateRequest> validator, ILogger<EstimateController> logger)
    {
        _validator = validator;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Calculate([FromBody] EstimateRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        var total = request.Hours * request.Rate;
        var totalWithTax = total * 1.15m; 

        _logger.LogInformation("Cálculo: {Project} = {Total}", request.ProjectName, totalWithTax);

        return Ok(new { 
            Project = request.ProjectName, 
            TotalCost = totalWithTax, 
            Message = "Processado no Docker com Sucesso!" 
        });
    }
}

public class EstimateRequest
{
    public string ProjectName { get; set; } = string.Empty;
    public int Hours { get; set; }
    public decimal Rate { get; set; }
}

public class EstimateValidator : AbstractValidator<EstimateRequest>
{
    public EstimateValidator()
    {
        RuleFor(x => x.ProjectName).NotEmpty();
        RuleFor(x => x.Hours).GreaterThan(0);
        RuleFor(x => x.Rate).GreaterThan(0);
    }
}