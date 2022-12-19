using JrAPI.Models;

namespace JrAPI.View;

public class ClusterView : IClusterView
{
    private ISet<Cluster> Clusters { get; } = new HashSet<Cluster>();
    private string Path { get; set; } = "/home/msucharski/Documents/JrAPI/JrAPI/bin/Debug/net6.0/Clusters";
    
    public ClusterView()
    {
        try
        {
            DetectClusters(Path);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex);
        }
    }
    
    public ISet<string> GetClustersName()
    {
        var result = new SortedSet<string>();
        foreach (var cluster in Clusters)
        {
            result.Add(cluster.Name);
        }
        return result;
    }

    public Cluster GetClusterByName(string name)
    {
        foreach (var cluster in Clusters)
        {
            if (cluster.Name == name)
                return cluster;
        }

        throw new ArgumentException("Cannot find cluster");
    }

    private void DetectClusters(string path)
    {
        var folders = Directory.GetDirectories(path);
        foreach (var folder in folders)
        {
            try
            {
                var cluster = DetectClusterComponent(folder);
                Clusters.Add(cluster);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
            }
        }
    }
    private Cluster DetectClusterComponent(string path)
    {
        return new Cluster
        {
            Name = path.Split('/').Last(),
            Component = Directory.GetFiles(path).Last(),
            Files = Directory.GetFiles(path + "/files"),
            Icon = Directory.GetFiles(path + "/icon").Last()
        };
    }
}