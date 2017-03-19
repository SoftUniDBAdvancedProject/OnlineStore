﻿namespace Store.Data
{
    using System.Data.Entity;
    using EntityConfigurations;
    using Migrations;

    public class StoreContext : Context
    {
        public StoreContext()
            : base("OnlineStoreConection", false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StoreContext, Configuration>());
        }

        public static StoreContext Create()
        {
            return new StoreContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new OrderProductEntityConfiguration());
            modelBuilder.Configurations.Add(new CartProductEntityConfiguration());
            modelBuilder.Configurations.Add(new UserEntityConfiguration());
            modelBuilder.Configurations.Add(new CountryEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}