namespace QuizLive.Entitiy.Concrete;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Navigation
    public ICollection<Exam> Exams { get; set; }
}