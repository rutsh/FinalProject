using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.Models
{
    public partial class EconomyContext : DbContext
    {
        public EconomyContext()
        {
        }

        public EconomyContext(DbContextOptions<EconomyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Expense> Expense { get; set; }
        public virtual DbSet<FixedExpense> FixedExpense { get; set; }
        public virtual DbSet<FixedIncome> FixedIncome { get; set; }
        public virtual DbSet<Income> Income { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAB-D-04;Database=Economy;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__categori__23CAF1D8E28449F9");

                entity.ToTable("categories");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.CategoryFixed).HasColumnName("categoryFixed");

                entity.Property(e => e.CategoryName)
                    .HasColumnName("categoryName")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.ToTable("expense");

                entity.Property(e => e.ExpenseId).HasColumnName("expenseId");

                entity.Property(e => e.ExpenseCategory).HasColumnName("expenseCategory");

                entity.Property(e => e.ExpenseSum).HasColumnName("expenseSum");

                entity.Property(e => e.ExpenseTime)
                    .HasColumnName("expenseTime")
                    .HasColumnType("date");

                entity.Property(e => e.ExpenseUser).HasColumnName("expenseUser");

                entity.HasOne(d => d.ExpenseCategoryNavigation)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.ExpenseCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__expense__expense__34C8D9D1");

                entity.HasOne(d => d.ExpenseUserNavigation)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.ExpenseUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__expense__expense__33D4B598");
            });

            modelBuilder.Entity<FixedExpense>(entity =>
            {
                entity.HasKey(e => e.FixedExId)
                    .HasName("PK__fixedExp__6AF028561848854B");

                entity.ToTable("fixedExpense");

                entity.Property(e => e.FixedExId).HasColumnName("fixedExId");

                entity.Property(e => e.FixedExCategory).HasColumnName("fixedExCategory");

                entity.Property(e => e.FixedExPrev).HasColumnName("fixedExPrev");

                entity.Property(e => e.FixedExSum).HasColumnName("fixedExSum");

                entity.Property(e => e.FixedExTime)
                    .HasColumnName("fixedExTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.FixedExUser).HasColumnName("fixedExUser");

                entity.HasOne(d => d.FixedExCategoryNavigation)
                    .WithMany(p => p.FixedExpense)
                    .HasForeignKey(d => d.FixedExCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__fixedExpe__fixed__2E1BDC42");

                entity.HasOne(d => d.FixedExPrevNavigation)
                    .WithMany(p => p.InverseFixedExPrevNavigation)
                    .HasForeignKey(d => d.FixedExPrev)
                    .HasConstraintName("FK__fixedExpe__fixed__2D27B809");

                entity.HasOne(d => d.FixedExUserNavigation)
                    .WithMany(p => p.FixedExpense)
                    .HasForeignKey(d => d.FixedExUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__fixedExpe__fixed__2C3393D0");
            });

            modelBuilder.Entity<FixedIncome>(entity =>
            {
                entity.HasKey(e => e.FixedInId)
                    .HasName("PK__fixedInc__0518B27B07F94C7B");

                entity.ToTable("fixedIncome");

                entity.Property(e => e.FixedInId).HasColumnName("fixedInId");

                entity.Property(e => e.FixedInPrev).HasColumnName("fixedInPrev");

                entity.Property(e => e.FixedInSum).HasColumnName("fixedInSum");

                entity.Property(e => e.FixedInTime)
                    .HasColumnName("fixedInTime")
                    .HasColumnType("date");

                entity.Property(e => e.FixedInUser).HasColumnName("fixedInUser");

                entity.HasOne(d => d.FixedInPrevNavigation)
                    .WithMany(p => p.InverseFixedInPrevNavigation)
                    .HasForeignKey(d => d.FixedInPrev)
                    .HasConstraintName("FK__fixedInco__fixed__29572725");

                entity.HasOne(d => d.FixedInUserNavigation)
                    .WithMany(p => p.FixedIncome)
                    .HasForeignKey(d => d.FixedInUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__fixedInco__fixed__286302EC");
            });

            modelBuilder.Entity<Income>(entity =>
            {
                entity.ToTable("income");

                entity.Property(e => e.IncomeId).HasColumnName("incomeId");

                entity.Property(e => e.IncomeSum).HasColumnName("incomeSum");

                entity.Property(e => e.IncomeTime)
                    .HasColumnName("incomeTime")
                    .HasColumnType("date");

                entity.Property(e => e.IncomeUser).HasColumnName("incomeUser");

                entity.HasOne(d => d.IncomeUserNavigation)
                    .WithMany(p => p.Income)
                    .HasForeignKey(d => d.IncomeUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__income__incomeUs__30F848ED");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__users__CB9A1CFF80B4E1FE");

                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.UserFamilySize).HasColumnName("userFamilySize");

                entity.Property(e => e.UserMail)
                    .HasColumnName("userMail")
                    .HasMaxLength(40);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(30);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("userPassword")
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
