namespace WhackAMoleApp
{
    using SQLite.CodeFirst;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class HighScoreContext : DbContext
    {
        public DbSet<HighScore> HighScores { get; set; }

        public HighScoreContext(): base("name=HighScoreContext"){ }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<HighScoreContext>(modelBuilder);
            //var sqliteConnectionInitializer = new SqliteDropCreateDatabaseWhenModelChanges<HighScoreContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }
    }

    public class HighScore
    {
        [Key]
        public long Id { get; set; }
        public DateTime Entered { get; set; }
        public string Name { get; set; }
        public double Score { get; set; }

        public string Difficulty { get; set; }

        public double TotalMoles { get; set; }
        public double TotalHit { get; set; }
        public double TotalMissed { get; set; }

    }
}