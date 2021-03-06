﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using SimpleBlog.Models;
using NHibernate;

namespace SimpleBlog
{
    public static class Database
    {
        private const string SessionKey = "SimpleBlog.Database.SessionKey";
        private static ISessionFactory _sessionFactory;
        public static ISession Session {
            get {return (ISession) HttpContext.Current.Items[SessionKey];}
        } 

        // invoked at application startup and used to configure NHibernate
        // hosts mapping and connection string to db
        public static void Configure() 
        {
            var config = new Configuration();

            // configure connection string
            // automatically looks at Web.config and uses that for connection string
            config.Configure();
            
            // add our mappings
            var mapper = new ModelMapper();
            mapper.AddMapping<UserMap>();
            mapper.AddMapping<RoleMap>();
            mapper.AddMapping<TagMap>();
            mapper.AddMapping<PostMap>();
            config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

            // create session factory
            _sessionFactory = config.BuildSessionFactory();
        }

        // invoked at the beginning of each request
        public static void OpenSession() {
            HttpContext.Current.Items[SessionKey] = _sessionFactory.OpenSession(); 
        }

        // retrieve the session and then close it
        public static void CloseSession() {
            var session = HttpContext.Current.Items[SessionKey] as ISession;
            if (session != null)
                session.Close();
            
            HttpContext.Current.Items.Remove(SessionKey);
        }


    }
}