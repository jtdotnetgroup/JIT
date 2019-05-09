using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using JIT.Configuration;
using JIT.Web;

namespace JIT.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class JITDbContextFactory : IDesignTimeDbContextFactory<JITDbContext>
    {
        public JITDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<JITDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            JITDbContextConfigurer.Configure(builder, configuration.GetConnectionString(JITConsts.ConnectionStringName));

            return new JITDbContext(builder.Options);
        }
    }
}
