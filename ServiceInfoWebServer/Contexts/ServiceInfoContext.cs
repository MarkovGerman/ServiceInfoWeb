using Microsoft.EntityFrameworkCore;
using ServiceInfoWebServer.Models;

namespace ServiceInfoWebServer.Contexts
{
    public class ServiceInfoContext : DbContext
    {
        public ServiceInfoContext(DbContextOptions<ServiceInfoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ServiceInfo> ServiceInfo { get; set; } = null!;
    }
}