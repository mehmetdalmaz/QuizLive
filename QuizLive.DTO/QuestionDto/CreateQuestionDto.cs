using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizLive.DTO.OptionDto;
using QuizLive.Entitiy.Enums;

namespace QuizLive.DTO.QuestionDto
{
    public class CreateQuestionDto
    {
    public string Text { get; set; }
    public int ExamId { get; set; }
    public QuestionType QuestionType { get; set; }
    public List<CreateOptionDto> Options { get; set; } 
    }
}