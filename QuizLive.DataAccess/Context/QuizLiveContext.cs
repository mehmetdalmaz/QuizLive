using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.DataAccess.Context;

public class QuizLiveContext: IdentityDbContext<AppUser, IdentityRole<int>, int>
{
    override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=192.168.1.31;Initial Catalog=QuizLive.DataBase;User ID=sa;Password=kayseri38;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<UserAnswer>()
        .HasOne(ua => ua.ExamResult)
        .WithMany(er => er.UserAnswers)
        .HasForeignKey(ua => ua.ExamResultId)
        .OnDelete(DeleteBehavior.Cascade); // Sınav sonucu silindiğinde cevaplar da silinsin.

    modelBuilder.Entity<UserAnswer>()
        .HasOne(ua => ua.Question)
        .WithMany()
        .HasForeignKey(ua => ua.QuestionId)
        .OnDelete(DeleteBehavior.Restrict); // Burada cascade silme kapalı, silme sınav sonucu bazında olsun.
}

    public DbSet<Question> Questions { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Option> Options { get; set; }
    public DbSet<UserAnswer> UserAnswers { get; set; }
    public DbSet<ExamResult> ExamResults { get; set; }
}