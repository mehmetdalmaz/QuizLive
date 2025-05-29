using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizLive.DTO.OptionDto;
using QuizLive.Entitiy.Enums;

namespace QuizLive.DTO.QuestionDto
{
    public class ResultQuestionDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public QuestionType QuestionType { get; set; }

        public List<ResultOptionDto> Options { get; set; }

    }
}