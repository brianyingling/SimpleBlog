﻿using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace SimpleBlog.Models
{
    public class User
    {
        private const int WORK_FACTOR = 13;
        // created to prevent timed attacks to determine users
        public static void FakeHash() {
            BCrypt.Net.BCrypt.HashPassword("", WORK_FACTOR);
        }

        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Email { get; set; }
        public virtual string PasswordHash { get; set; }

        public virtual void SetPassword(string password)
        {
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password, 13);
        }

        public virtual bool CheckPassword(string password) 
        {
            return true;
            //return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }
    }

    public class UserMap : ClassMapping<User>
    {
        public UserMap() {
            Table("users");
            Id(x => x.Id, x => x.Generator(Generators.Identity));

            Property(x => x.Username, x => x.NotNullable(true));
            Property(x => x.Email, x => x.NotNullable(true));
            Property(x => x.PasswordHash, x => 
            {
                x.Column("password_hash");
                x.NotNullable(true);
            });
        }
        
    }
}