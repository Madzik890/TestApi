using JrAPI.Encoder;
using JrAPI.Models;
using JrAPI.View;
using Microsoft.AspNetCore.Mvc;

namespace JrAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DownloadController : ControllerBase
{
    private readonly IClusterView _clusterView;
    private readonly ILogger<DownloadController> _logger;

    public DownloadController(IClusterView clusterView, ILogger<DownloadController> logger)
    {
        _clusterView = clusterView;
        _logger = logger;
    }

    [HttpGet("Icon")]
    public JrFile Icon(string name)
    {
        var cluster = _clusterView.GetClusterByName(name);
        return LoadAndEncode(cluster.Icon);
    }
    
    [HttpGet("Component")]
    public JrFile Component(string name)
    {
        var cluster = _clusterView.GetClusterByName(name);
        return LoadAndEncode(cluster.Component);
    }

    [HttpGet("Files")]
    public JrFile[] Files(string name)
    {
        var cluster = _clusterView.GetClusterByName(name);
        var clusterFiles = cluster.Files;
        var files = new JrFile[clusterFiles.Length];
        for (var i = 0; i < files.Length; i++)
        {
            files[i] = LoadAndEncode(cluster.Files[i]);
        }
        return files;
    }

    private JrFile LoadAndEncode(string path)
    {
        var buffer = System.IO.File.ReadAllText(path);
        buffer = Base64Encoder.Get(buffer);
        
        return new JrFile()
        {
            Name = path.Split('/').Last(),
            Buffer = buffer
        };
    }
}