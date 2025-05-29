using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizLive.DTO.UserAnswerDto
{
    public class ResultUserAnswerDto
    {
        public int Id { get; set; } // Güncellenecek cevabın Id'si
        public int? SelectedOptionId { get; set; }
        public string OpenEndedAnswerText { get; set; }

    }
}