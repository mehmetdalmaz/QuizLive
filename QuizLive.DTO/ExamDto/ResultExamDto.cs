using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizLive.DTO.ExamDto
{
    public class ResultExamDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DurationInMinutes { get; set; }

        public string CourseName { get; set; }
    }
}