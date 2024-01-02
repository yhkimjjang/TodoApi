using Microsoft.EntityFrameworkCore;
using TodoApi.Domains.Category.Entities;
using TodoApi.Domains.Todo.Entities;
using TodoApi.Domains.UserInfo.Entities;

public class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options) : base(options) {}

    public DbSet<UserInfoEntity> userInfos => Set<UserInfoEntity>();
    public DbSet<TodoEntity> Todos => Set<TodoEntity>();
    public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
    public DbSet<CategoryTodoEntity> CategoryTodos => Set<CategoryTodoEntity>();
    public DbSet<InvitationEntity> Invitations => Set<InvitationEntity>();
    public DbSet<UserCategoryGroupEntity> UserCategoryGroups => Set<UserCategoryGroupEntity>();
    public DbSet<UserFriendEntity> UserFriends => Set<UserFriendEntity>();
    public DbSet<UserPasswordEntity> UserPasswords => Set<UserPasswordEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // UserInfo 설정
        modelBuilder.Entity<UserInfoEntity>(e =>
        {
            e.HasKey(e => e.Seq);
            e.HasIndex(e => e.UserId)
                .IsUnique();

            e.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(10);

            e.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            e.Property(e => e.SocialUseYn)
            .HasDefaultValue(true);

            e.Property(e => e.IsUseYn)
            .HasDefaultValue(true);

            e.Property(e => e.CreateDate)
            .HasDefaultValue(DateTime.Now);

            e.HasMany(e => e.Todos)
            .WithOne(e => e.UserInfo)
            .IsRequired(false);

            e.HasMany(e => e.UserFriends)
            .WithOne(e => e.UserInfo)
            .HasForeignKey(fk => fk.UserId)
            .HasPrincipalKey(e => e.UserId)
            .IsRequired();
            

            e.HasMany(e => e.Invitations)
            .WithOne(e => e.UserInfo)
            .HasForeignKey(fk => fk.UserId)
            .HasPrincipalKey(e => e.UserId)
            .IsRequired();

            e.HasMany(e => e.UserCategoryGroups)
            .WithOne(e => e.UserInfo)
            .HasForeignKey(fk => fk.UserId)
            .HasPrincipalKey(e => e.UserId)
            .IsRequired();

            e.HasOne(e => e.UserPassword)
            .WithOne(e => e.UserInfo)
            .HasForeignKey<UserPasswordEntity>(fk => fk.UserId)
            .HasPrincipalKey<UserInfoEntity>(e => e.UserId)
            .IsRequired();
        });

        // UserPassword 설정
        modelBuilder.Entity<UserPasswordEntity>(e => 
        {
            e.HasKey(e => e.Seq);

            e.Property(e => e.Password)
            .HasMaxLength(20)
            .IsRequired();

            e.Property(e => e.SaltValue)
            .HasMaxLength(10)
            .IsRequired();

            e.Property(e => e.UserId)
            .HasMaxLength(10)
            .IsRequired();
        });

        // UserCategoryGroup 설정
        modelBuilder.Entity<UserCategoryGroupEntity>(e => 
        {
            e.HasKey(e => e.Seq);

            e.Property(e => e.UserId)
            .HasMaxLength(10)
            .IsRequired();

            e.Property(e => e.CategoryId)
            .HasMaxLength(10)
            .IsRequired();
        });

        // UserFriend 설정
        modelBuilder.Entity<UserFriendEntity>(e => 
        {
            e.HasKey(e => e.Seq);

            e.Property(e => e.FriendId)
            .HasMaxLength(10)
            .IsRequired();

            e.Property(e => e.IsUserYn)
            .HasDefaultValue(true);

            e.Property(e => e.CreateUser)
            .HasMaxLength(10)
            .IsRequired();

            e.Property(e => e.CreateDAte)
            .HasDefaultValue(DateTime.Now)
            .IsRequired();

            e.Property(e => e.UserId)
            .HasMaxLength(10)
            .IsRequired();
        });

        // invitation 설정
        modelBuilder.Entity<InvitationEntity>(e => 
        {
            e.HasKey(e => e.Seq);

            e.Property(e => e.RecieverEmail)            
            .HasMaxLength(100)
            .IsRequired();

            e.Property(e => e.InvitationKey)
            .HasMaxLength(15)
            .IsRequired();

            e.Property(e => e.InvitationExpire)
            .IsRequired();

            e.Property(e => e.UserId)
            .HasMaxLength(10)
            .IsRequired();
        });

        // Todo 설정
        modelBuilder.Entity<TodoEntity>(e => 
        {
            e.HasKey(e => e.Seq);

            e.HasIndex(e => e.TodoId)
            .IsUnique();

            e.Property(e => e.TodoId)
            .HasMaxLength(10)
            .IsRequired();

            e.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(20);

            e.Property(e => e.Content)
            .IsRequired()
            .HasMaxLength(500);

            e.Property(e => e.CreateUser)
            .IsRequired();

            e.Property(e => e.CreateDate)
            .IsRequired();

            e.HasMany(e => e.CategoryTodos)
            .WithOne(e => e.Todo)
            .HasForeignKey(fk => fk.TodoId)
            .HasPrincipalKey(e => e.TodoId)
            .IsRequired();
        });

        // Category 설정
        modelBuilder.Entity<CategoryEntity>(e => 
        {
            e.HasKey(e => e.Seq);
            
            e.HasIndex(e => e.CategoryId)
            .IsUnique();

            e.Property(e => e.CategoryId)
            .HasMaxLength(10)
            .IsRequired();

            e.Property(e => e.CategoryName)
            .HasMaxLength(20)
            .IsRequired();

            e.Property(e => e.IsUseYn)
            .HasDefaultValue(true);

            e.Property(e => e.CreateUser)
            .IsRequired();

            e.Property(e => e.CreateDate)
            .HasDefaultValue(DateTime.Now);

            e.Property(e => e.CaregoryOwner)
            .IsRequired();

            e.HasMany(e => e.CategoryTodos)
            .WithOne(e => e.Category)
            .HasForeignKey(fk => fk.CategoryId)
            .HasPrincipalKey(e => e.CategoryId)
            .IsRequired();
        });
    
        // CategoryTood 설정
        modelBuilder.Entity<CategoryTodoEntity>(e => 
        {
            e.HasKey(e => e.Seq);

            e.Property(e => e.CategoryId)
            .HasMaxLength(10)
            .IsRequired();

            e.Property(e => e.TodoId)
            .HasMaxLength(10)
            .IsRequired();
        });
    }
}