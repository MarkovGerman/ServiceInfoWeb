using System.Linq;
using ServiceInfoWebServer.Enums;
using ServiceInfoWebServer.Models;

public static class IQueryableExtensions
{
    public static IQueryable<ServiceInfo> FilterEnvironment(this IQueryable<ServiceInfo> list, ServiceEnvironment? environment)
    {
        return list.Where(serviceInfo => !environment.HasValue || serviceInfo.ServiceEnvironment == environment.Value);
    }

    public static IQueryable<ServiceInfo> FilterHost(this IQueryable<ServiceInfo> list, string? host)
    {
        return list.Where(serviceInfo => string.IsNullOrEmpty(host) || serviceInfo.Host.Contains(host));
    }
}