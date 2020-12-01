﻿using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class EducatorConfiguration : EntityTypeConfiguration<Educator>
    {
        public EducatorConfiguration()
        {
            Property(educator => educator.LastName)
                .IsRequired()
                .HasMaxLength(15);

            Property(e => e.FirstName)
                .HasMaxLength(15);

            //HasKey(x => x.Id);
        }
    }
}
