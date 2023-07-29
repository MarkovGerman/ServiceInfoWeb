using System.ComponentModel.DataAnnotations.Schema;
using ServiceInfoWebServer.Enums;

namespace ServiceInfoWebServer.Models
{
    public class ServiceInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Host { get; set; }
        public string StackName { get; set; }
        public string LocalDns { get; set; }
        public int LocalPort { get; set; }
        public int LocalSecondPort { get; set; }
        public string PublicDns { get; set; }
        public int PublicPort { get; set; }
        public string PublicUrl { get; set; }
        public ServiceEnvironment ServiceEnvironment { get; set; }
        public ServiceType ServiceType { get; set; }
        public bool IsActive { get; set; }
    }
}