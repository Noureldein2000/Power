using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Power.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power.Data.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(s => s.Id);
            //builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
            //builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(s => s.Author).WithMany(s => s.Books)
                .HasForeignKey(s => s.AuthorId).OnDelete(DeleteBehavior.NoAction);


        }

    }
}
