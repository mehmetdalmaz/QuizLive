using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizLive.DTO.UserAnswerDto
{
    public class UpdateUserAnswerDto
    {
        public int Id { get; set; }
        public int ExamResultId { get; set; }
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }

        public int? SelectedOptionId { get; set; }
        public string SelectedOptionText { get; set; }

        public string OpenEndedAnswerText { get; set; }
        public bool IsCorrect { get; set; } // varsa, sistem değerlendirmişse

    }
}