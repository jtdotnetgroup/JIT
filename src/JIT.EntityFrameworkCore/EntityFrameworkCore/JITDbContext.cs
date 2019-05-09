using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using JIT.Authorization.Roles;
using JIT.Authorization.Users;
using JIT.MultiTenancy;

namespace JIT.EntityFrameworkCore
{
    public class JITDbContext : AbpZeroDbContext<Tenant, Role, User, JITDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public JITDbContext(DbContextOptions<JITDbContext> options)
            : base(options)
        {
        }
    }
}
