﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DAO;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class RemoteDatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Username=user9; Password=X8C8NTnD; Database=user9; Host=45.67.56.214; Port=5454");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .HasOne(it => it.IdStatus);
            modelBuilder.Entity<Attendance>()
                .HasOne(it => it.IdStudent);
            modelBuilder.Entity<GroupsAndSubject>()
                .HasOne(it => it.SubjectId);
            modelBuilder.Entity<GroupsAndSubject>()
                .HasOne(it => it.GroupId);
            modelBuilder.Entity<Students>()
                .HasOne(it => it.IdGroup);
        }
        DbSet<Attendance> Attendances { get; set; }
        DbSet<Groups> Groupses { get; set; }
        DbSet<Students> Studentses { get; set; }
        DbSet<GroupsAndSubject> GroupsAndSubjects { get; set;}
        DbSet<Statuses> Statuss { get; set; }
        DbSet<Subjects> Subjectses { get; set; }
    }
}
