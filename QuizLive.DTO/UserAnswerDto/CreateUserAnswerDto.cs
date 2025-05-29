using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizLive.DTO.UserAnswerDto
{
    public class CreateUserAnswerDto
    {
        public int ExamResultId { get; set; }
        public int QuestionId { get; set; }
        public int? SelectedOptionId { get; set; } // Çoktan seçmeli ise
        public string OpenEndedAnswerText { get; set; } // Açık uçlu ise

    }
}