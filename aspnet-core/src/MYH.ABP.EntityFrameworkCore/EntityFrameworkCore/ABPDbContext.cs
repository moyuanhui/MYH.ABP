using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MYH.ABP.Authorization.Roles;
using MYH.ABP.Authorization.Users;
using MYH.ABP.MultiTenancy;

namespace MYH.ABP.EntityFrameworkCore
{
    public class ABPDbContext : AbpZeroDbContext<Tenant, Role, User, ABPDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ABPDbContext(DbContextOptions<ABPDbContext> options)
            : base(options)
        {
        }
    }
}
