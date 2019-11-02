using JetBrains.Annotations;
using Messeger.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messeger.DAL
{
    public class Messeger_DBContext : DbContext
    {
        public Messeger_DBContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Member> Members{ get; set; }
        public virtual DbSet<MessageMember> MessageMembers { get; set; }
        public virtual DbSet<MessageDetails> MessageDetails  { get; set; }
        public virtual DbSet<Message>Messages { get; set; }
    }
}
