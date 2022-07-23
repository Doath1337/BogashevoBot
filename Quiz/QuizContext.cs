using Microsoft.EntityFrameworkCore;

namespace Quiz
{
    public class QuizContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<QuizResult> QuizResults { get; set; }

        public DbSet<QuestionForUser> GivenQuestionsForUser {get; set;}

        public string DbPath { get; }

        public QuizContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "quiz.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

    }
}
