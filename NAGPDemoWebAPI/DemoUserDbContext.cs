using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using NAGPDemoWebAPI.Models;

namespace NAGPDemoWebAPI
{
	public class DemoUserDbContext : DbContext
	{
		public DbSet<NAGPDemoUser> DemoUsers { get; set; }

		public DemoUserDbContext(DbContextOptions<DemoUserDbContext> dbContextOptions) : base(dbContextOptions)
		{
			try
			{
				var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
				if (databaseCreator != null)
				{
					// create database if cannot connect
					if (!databaseCreator.CanConnect()) databaseCreator.Create();

					//create tables if no tables exist
					if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}

