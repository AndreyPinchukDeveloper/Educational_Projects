﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain;
using System.Security.Cryptography.X509Certificates;

namespace Notes.Persistance.EntityTypeConfigurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(note => note.Id);
            builder.HasIndex(note => note.Id).IsUnique();
            builder.Property(note => note.Title).HasMaxLength(250);
        }
    }
}
