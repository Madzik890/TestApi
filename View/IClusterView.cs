using JrAPI.Models;

namespace JrAPI.View;

public interface IClusterView
{
    ISet<string> GetClustersName();
    Cluster GetClusterByName(string name);
}