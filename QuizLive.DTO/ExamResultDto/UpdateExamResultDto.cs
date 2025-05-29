using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizLive.DTO.ExamResultDto
{
    public class UpdateExamResultDto
    {
        public int Id { get; set; }
        public DateTime EndTime { get; set; }
        public int Score { get; set; }

    }
}