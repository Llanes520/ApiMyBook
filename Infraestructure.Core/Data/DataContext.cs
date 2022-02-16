using Infraestructure.Entity.Models;
using Infraestructure.Entity.Models.Master;
using Infraestructure.Entity.Models.Library;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Core.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<UserEntity> UserEntity { get; set; }
        public DbSet<RolEntity> RolEntity { get; set; } 
        public DbSet<RolUserEntity> RolUserEntity { get; set; } 
        public DbSet<PermissionEntity> PermissionEntity { get; set; } 
        public DbSet<RolPermissionEntity> RolPermissionEntity { get; set; } 
        public DbSet<TypePermissionEntity> TypePermissionEntity { get; set; }

        public DbSet<EditorialEntity> EditorialEntity { get; set; }
        public DbSet<BookEntity> BookEntity { get; set; }
         
        public DbSet<StateEntity> StateEntity { get; set; }
        public DbSet<TypeBookEntity> TypeBookEntity { get; set; }
        public DbSet<TypeStateEntity> TypeStateEntity { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.Entity<TypeStateEntity>().Property(t => t.IdTypeState).ValueGeneratedNever();
            modelBuilder.Entity<TypePermissionEntity>().Property(t => t.IdTypePermission).ValueGeneratedNever();
            modelBuilder.Entity<StateEntity>().Property(t => t.IdState).ValueGeneratedNever();
            modelBuilder.Entity<RolEntity>().Property(t => t.IdRol).ValueGeneratedNever();
            modelBuilder.Entity<PermissionEntity>().Property(t => t.IdPermission).ValueGeneratedNever();
        }


    }
}
