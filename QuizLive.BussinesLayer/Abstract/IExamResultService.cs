using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using QuizLive.DTO.ExamResultDto;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.DataAccess.Abstract
{
    public interface IExamResultService: IGenericService<ExamResult>
    {
           
    // Sınav başlatma
    Task<int> StartExamAsync(CreateExamResultDto dto);

    // Sınav bitirme
    Task<bool> FinishExamAsync(UpdateExamResultDto dto);

    // Puan hesaplama
    Task<int> CalculateScoreAsync(int examResultId);

    // Kullanıcıya göre sonuçları getir
    Task<List<ResultExamResultDto>> GetExamResultsByUserAsync(int userId);

    // Sınava göre sonuçları getir
    Task<List<ResultExamResultDto>> GetExamResultsByExamIdAsync(int examId);


    }
}