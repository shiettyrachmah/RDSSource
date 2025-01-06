using Microsoft.EntityFrameworkCore;

namespace ApiSiram.Models
{
    public class SIRAMDBContext : DbContext
    {
        static SIRAMDBContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        public SIRAMDBContext(DbContextOptions<SIRAMDBContext> options) : base(options) { }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<DetailActivity> DetailActivities { get; set; }
        public virtual DbSet<ActivityLog> ActivityLogs { get; set; }
        public virtual DbSet<AppSetting> AppSettings { get; set; }
        public virtual DbSet<Demographic> Demographics { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MsField> MsFields { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleHasPermission> RoleHasPermissions { get; set; }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        public virtual DbSet<Divisi> Divisis { get; set; }
        public virtual DbSet<Komando> Komandos { get; set; }
        public virtual DbSet<Personel> Personels { get; set; }
        public virtual DbSet<Pangkat> Pangkats { get; set; }
        public virtual DbSet<Jabatan> Jabatans { get; set; }


        public virtual DbSet<VPersonel> VPersonels { get; set; }
    }
}
