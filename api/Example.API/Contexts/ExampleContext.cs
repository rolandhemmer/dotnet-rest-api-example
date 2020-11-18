using Example.API.Constants;
using Example.API.Models.Element;
using Microsoft.EntityFrameworkCore;

namespace Example.API.Contexts
{
    public sealed class ExampleContext : DbContext
    {
        #region TABLES

        public DbSet<ElementModel> Elements { get; set; }

        #endregion TABLES

        #region CONSTRUCTORS

        public ExampleContext(DbContextOptions contextOptions) : base(contextOptions)
        {
        }

        #endregion CONSTRUCTORS

        #region BUILDERS

        private static void BuildElementsTable(ModelBuilder modelBuilder)
        {
            // Table name
            modelBuilder.Entity<ElementModel>()
                .ToTable(ContextConstants.ElementTableName);

            // Keys and relationships
            modelBuilder.Entity<ElementModel>()
                .HasKey(element => element.Id);

            // Conversions and types
            modelBuilder.Entity<ElementModel>()
                .Property(element => element.CreationDate)
                .HasColumnType(ContextConstants.DateTimeColumnType);

            modelBuilder.Entity<ElementModel>()
                .Property(element => element.UpdateDate)
                .HasColumnType(ContextConstants.DateTimeColumnType);

            // Indices
            modelBuilder.Entity<ElementModel>()
                .HasIndex(element => element.Id)
                .IsUnique();
        }

        #endregion BUILDERS

        #region METHODS

        public override void Dispose()
        {
            ChangeTracker.DetectChanges();
            SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuildElementsTable(modelBuilder);
        }

        #endregion METHODS
    }
}
