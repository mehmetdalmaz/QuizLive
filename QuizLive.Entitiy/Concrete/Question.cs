using QuizLive.Entitiy.Enums;

namespace QuizLive.Entitiy.Concrete;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; }

    public int ExamId { get; set; }
    public Exam Exam { get; set; }

    public QuestionType QuestionType { get; set; }
    public ICollection<Option> Options { get; set; }
}