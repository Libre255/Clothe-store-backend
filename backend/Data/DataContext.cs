﻿namespace backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                        
        }

        public DbSet<Clothe> Clothes => Set<Clothe>();
    }
}
