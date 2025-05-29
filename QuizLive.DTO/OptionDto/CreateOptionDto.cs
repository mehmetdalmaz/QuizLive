using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizLive.DTO.OptionDto
{
    public class CreateOptionDto
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

    }
}