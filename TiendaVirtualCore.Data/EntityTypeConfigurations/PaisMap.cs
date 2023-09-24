using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Data.EntityTypeConfigurations
{
    public class PaisMap
    {
        public PaisMap(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("Paises");
            builder.HasKey(p => p.PaisId);
        }
    }
}
