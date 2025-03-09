using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperEvaluation.Core.Data
{
   public static class TreatApplyDateTimeConversion
    {

        private static DateTime TreatDate(DateTime date)
        {
            return date.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(date, DateTimeKind.Utc).ToUniversalTime()
                : date.ToUniversalTime();
        }

        private static DateTime TreatDateRead(DateTime date)
        {
            return DateTime.SpecifyKind(date, DateTimeKind.Utc);
        }

        private static DateTime? TreatDate(DateTime? date)
        {
            if (!date.HasValue)
                return null;

            return date.Value.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(date.Value, DateTimeKind.Utc).ToUniversalTime()
                : date.Value.ToUniversalTime();
        }

        private static DateTime? TreatDateRead(DateTime? date)
        {
            return date.HasValue ? DateTime.SpecifyKind(date.Value, DateTimeKind.Utc) : (DateTime?)null;
        }
        public static void ApplyDateTimeConversion( this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;
                if (clrType == null) continue;

                var properties = clrType.GetProperties()
                    .Where(p => p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?));

                foreach (var property in properties)
                {
                    if (property.PropertyType == typeof(DateTime))
                    {
                        modelBuilder.Entity(entityType.Name).Property<DateTime>(property.Name)
                            .HasConversion(
                                v => TreatDate(v),
                                v => TreatDateRead(v)
                            );
                    }
                    else if (property.PropertyType == typeof(DateTime?))
                    {
                        modelBuilder.Entity(entityType.Name).Property<DateTime?>(property.Name)
                            .HasConversion(
                                v => TreatDate(v),
                                v => TreatDateRead(v)
                            );
                    }
                }
            }
        }
    }
}
