using Microsoft.AspNetCore.Identity;

namespace QuizLive.Entitiy.Concrete;

public class AppUser : IdentityUser<int>
{
    public string FullName { get; set; }

    public ICollection<ExamResult> ExamResults { get; set; }
}