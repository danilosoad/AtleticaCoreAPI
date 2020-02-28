using AtleticaCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtleticaCore.Data.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x =>x.ID);
            builder.Property(x => x.LOGIN).HasMaxLength(15).HasColumnType("varchar(15)");
            builder.Property(x => x.SENHA).HasMaxLength(120).HasColumnType("varchar(120)");
        }
    }
}
