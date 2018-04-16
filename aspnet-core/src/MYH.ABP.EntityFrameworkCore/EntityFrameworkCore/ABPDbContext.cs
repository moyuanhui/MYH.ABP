using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MYH.ABP.Authorization.Roles;
using MYH.ABP.Authorization.Users;
using MYH.ABP.MultiTenancy;
using MYH.ABP.PhoneBook.Persons;
using MYH.ABP.PhoneBook.PhoneNum;
using MYH.ABP.Member;

namespace MYH.ABP.EntityFrameworkCore
{
    public class ABPDbContext : AbpZeroDbContext<Tenant, Role, User, ABPDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ABPDbContext(DbContextOptions<ABPDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }

        public DbSet<PhoneNumber> PhoneNumber { get; set; }

        public DbSet<MemberEntity> MemberEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person", "PB");
            modelBuilder.Entity<PhoneNumber>().ToTable("PhoneNumber", "PB");
            modelBuilder.Entity<MemberEntity>().ToTable("MemberEntity", "EWMS");
            base.OnModelCreating(modelBuilder);
        }
    }
}
