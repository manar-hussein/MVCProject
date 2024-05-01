using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    internal class EployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Id).UseIdentityColumn();
            builder.Property(E => E.Name).IsRequired().HasColumnType("varchar").HasMaxLength(20);

            builder.Property(E => E.Salary).IsRequired().HasColumnType("decimal(12,2)");

            builder.Property(E => E.Address).HasColumnType("varchar");

            builder.Property(E => E.Gender).HasConversion(

                (Gender) => Gender.ToString(),
                (stringOfGender) => (Gender)Enum.Parse(typeof(Gender), stringOfGender, true)
                ).IsRequired();

            builder.Property(E => E.Email).IsRequired().HasColumnType("varchar").HasMaxLength(50);
        }
    }
}
