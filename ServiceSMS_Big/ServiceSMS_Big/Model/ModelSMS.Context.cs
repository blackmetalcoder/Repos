﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceSMS_Big.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class anicuraEntities : DbContext
    {
        public anicuraEntities()
            : base("name=anicuraEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DPT_KLINKOD> DPT_KLINKOD { get; set; }
        public virtual DbSet<DPT_RESURS> DPT_RESURS { get; set; }
        public virtual DbSet<DPT_TIDBOK> DPT_TIDBOK { get; set; }
    }
}
