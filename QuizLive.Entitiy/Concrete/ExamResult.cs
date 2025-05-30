namespace QuizLive.Entitiy.Concrete;

public class ExamResult
{
    public int Id { get; set; }

    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }

    public int ExamId { get; set; }
    public Exam Exam { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }

    public int Score { get; set; }

    public ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
}