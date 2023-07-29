using System.ComponentModel.DataAnnotations.Schema;
using ServiceInfoWebServer.Enums;
using ServiceInfoWebServer.Models;

namespace ServiceInfoWebServer.DTO
{
    public class GetServiceInfoResponse: ServiceInfo
    {
        public string LocalUrl => $"http://{LocalDns}:{LocalPort}";
    }
}