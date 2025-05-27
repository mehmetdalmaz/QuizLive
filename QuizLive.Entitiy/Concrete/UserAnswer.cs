namespace QuizLive.Entitiy.Concrete;

public class UserAnswer
{
    public int Id { get; set; }

    public int ExamResultId { get; set; }
    public ExamResult ExamResult { get; set; }

    public int QuestionId { get; set; }
    public Question Question { get; set; }

    public int? SelectedOptionId { get; set; } // Çoktan seçmeli için
    public Option SelectedOption { get; set; }

    public string OpenEndedAnswerText { get; set; } // Açık uçlu için

}