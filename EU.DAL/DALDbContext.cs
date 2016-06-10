using EU.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EU.DAL
{
    public partial class DALDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoleRelation> UserRoleRelations { get; set; }
        public DbSet<UserConfig> UserConfig { get; set; }
        /// <summary>
        /// 文章
        /// </summary>
        public DbSet<Article> Article { get; set; }
        public DbSet<Attachment> Attachment { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbSet<CommonModel> CommonModel { get; set; }

        public DALDbContext():base("yyerp")
        {
            Database.CreateIfNotExists();
        }
    }
}
