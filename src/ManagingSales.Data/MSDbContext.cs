/*
 *   Copyright (c) 2024 Dzianis Prokharchyk

 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.

 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.

 *   You should have received a copy of the GNU General Public License
 *   along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

using System;
using ManagingSales.Data.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ManagingSales.Data
{
    public class MSDbContext : DbContext
    {
        #region Props

        public DbSet<WindowEntity> Windows { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<SubElement> SubElements { get; set; }

        #endregion


        #region Ctors

        public MSDbContext(DbContextOptions<MSDbContext> options)
            : base(options)
        {
        }

        #endregion


        #region Methods

        private void ConfigureWindowEntity(EntityTypeBuilder<WindowEntity> builder)
        {
            builder.ToTable("Window");

            builder.Property(ci => ci.Id)
                .HasColumnType("bigint")
                .UseHiLo("window_hilo")
                .IsRequired();
        }

        private void ConfigureSubElementEntity(EntityTypeBuilder<SubElement> builder)
        {
            var converter = new ValueConverter<TypeElement, string>(
                   v => v.ToString(),
                   v => (TypeElement)Enum.Parse(typeof(TypeElement), v));

            builder.Property(ci => ci.Id)
               .HasColumnType("bigint")
               .UseHiLo("sub_element_hilo")
               .IsRequired();

            builder
                .Property(e => e.Type)
                .HasConversion(converter);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WindowEntity>(ConfigureWindowEntity);
            modelBuilder.Entity<SubElement>(ConfigureSubElementEntity);
        }

        #endregion
    }
}

