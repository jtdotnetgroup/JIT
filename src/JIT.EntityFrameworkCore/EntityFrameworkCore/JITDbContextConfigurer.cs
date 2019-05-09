using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace JIT.EntityFrameworkCore
{
    public static class JITDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<JITDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<JITDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
