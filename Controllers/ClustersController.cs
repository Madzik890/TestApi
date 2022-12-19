using JrAPI.Models;
using JrAPI.View;
using Microsoft.AspNetCore.Mvc;

namespace JrAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ClustersController : ControllerBase
{
    private readonly IClusterView _clusterView;
    private readonly ILogger<ClustersController> _logger;

    public ClustersController(IClusterView clusterView, ILogger<ClustersController> logger)
    {
        _clusterView = clusterView;
        _logger = logger;
    }
    
    [HttpGet("GetAllComponents")]
    public ISet<string> GetAllComponents()
    {
        return _clusterView.GetClustersName();
    }
}