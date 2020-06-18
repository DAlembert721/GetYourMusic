using Microsoft.EntityFrameworkCore;

namespace GetYourMusic.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ApplySnakeCaseNamingConvention(this ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                if (entity.BaseType == null)
                    entity.SetTableName(entity.GetTableName().ToSnakeCase());
                foreach (var property in entity.GetProperties())
                    property.SetColumnName(property.GetColumnName().ToSnakeCase());
                foreach (var key in entity.GetKeys())
                    key.SetName(key.GetName().ToSnakeCase());
                foreach (var foreignKey in entity.GetForeignKeys())
                    foreignKey.SetConstraintName(foreignKey.GetConstraintName().ToSnakeCase());
                foreach (var index in entity.GetIndexes())
                    index.SetName(index.GetName().ToSnakeCase());
            }
        }
    }
}
