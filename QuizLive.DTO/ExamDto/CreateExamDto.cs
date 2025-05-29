using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizLive.DTO.ExamDto
{
    public class CreateExamDto
    {
        public string Title { get; set; }
        public int DurationInMinutes { get; set; }
        public int CourseId { get; set; }

    }
}