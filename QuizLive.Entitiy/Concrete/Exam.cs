namespace QuizLive.Entitiy.Concrete;

public class Exam
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int DurationInMinutes { get; set; } // Süre

    public int CourseId { get; set; }
    public Course Course { get; set; }

    // Navigation
    public ICollection<Question> Questions { get; set; }
    public ICollection<ExamResult> ExamResults { get; set; }
}