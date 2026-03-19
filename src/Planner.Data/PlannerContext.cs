using Microsoft.EntityFrameworkCore;
using Planner.Data.Models;

namespace Planner.Data;

public partial class PlannerContext : DbContext
{
    public PlannerContext(DbContextOptions<PlannerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Todo> Todos { get; set; }

    public virtual DbSet<TodoCategory> TodoCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_uuidv7");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("categories_pkey");

            entity.ToTable("categories", "planner");

            entity.Property(e => e.CategoryId)
                .HasDefaultValueSql("uuid_generate_v7()")
                .HasColumnName("category_id");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Todo>(entity =>
        {
            entity.HasKey(e => e.TodoId).HasName("todos_pkey");

            entity.ToTable("todos", "planner");

            entity.Property(e => e.TodoId)
                .HasDefaultValueSql("uuid_generate_v7()")
                .HasColumnName("todo_id");
            entity.Property(e => e.CompletionDate).HasColumnName("completion_date");
            entity.Property(e => e.Description)
                .HasMaxLength(1024)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .HasColumnName("name");
            entity.Property(e => e.ParentTodoId).HasColumnName("parent_todo_id");
            entity.Property(e => e.Priority)
                .HasDefaultValue(0)
                .HasColumnName("priority");

            entity.HasOne(d => d.ParentTodo).WithMany(p => p.InverseParentTodo)
                .HasForeignKey(d => d.ParentTodoId)
                .HasConstraintName("todos_parent_todo_id_fkey");
        });

        modelBuilder.Entity<TodoCategory>(entity =>
        {
            entity.HasKey(e => new { e.TodoId, e.CategoryId }).HasName("todo_categories_pkey");

            entity.ToTable("todo_categories", "planner");

            entity.Property(e => e.TodoId).HasColumnName("todo_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryZIndex)
                .HasDefaultValue(0)
                .HasColumnName("category_z_index");

            entity.HasOne(d => d.Category).WithMany(p => p.TodoCategories)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("todo_categories_category_id_fkey");

            entity.HasOne(d => d.Todo).WithMany(p => p.TodoCategories)
                .HasForeignKey(d => d.TodoId)
                .HasConstraintName("todo_categories_todo_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
