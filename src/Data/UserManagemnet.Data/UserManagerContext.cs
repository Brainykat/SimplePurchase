using System;

namespace UserManagemnet.Data
{
    public class UserManagerContext : IdentityDbContext<User>
    {
        public UserManagerContext(DbContextOptions<UserManagerContext> options) : base(options)
        {
        }
        //Let IdentityDbContext take care of everything here
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("User");
        }
    }
}
