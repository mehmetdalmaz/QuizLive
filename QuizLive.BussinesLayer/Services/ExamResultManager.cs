using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using QuizLive.DataAccess.Abstract;
using QuizLive.DTO.ExamResultDto;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.BussinesLayer.Services
{
    public class ExamResultManager : IExamResultService
    {
        private readonly IExamResultDal _ExamResultDal;
        private readonly IUserAnswerDal _userAnswerDal;
        private readonly IQuestionDal _questionDal;
        private readonly IMapper _mapper;
        public ExamResultManager(IExamResultDal ExamResultDal
            , IUserAnswerDal userAnswerDal
            , IQuestionDal questionDal
            , IMapper mapper)
        {
            _mapper = mapper;
            _userAnswerDal = userAnswerDal;
            _questionDal = questionDal;
            _ExamResultDal = ExamResultDal;

        }

        public async Task<int> CalculateScoreAsync(int examResultId)
        {
            var userAnswers = await _userAnswerDal.GetAllAsync();

            var resultAnswers = userAnswers.Where(x => x.ExamResultId == examResultId).ToList();

            var questionIds = resultAnswers.Select(x => x.QuestionId).Distinct().ToList();

            var allQuestions = await _questionDal.GetAllAsync();

            var relatedQuestions = allQuestions.Where(x => questionIds.Contains(x.Id)).ToList();

            int correctCount = resultAnswers.Count(answer =>
            {
                var question = relatedQuestions.FirstOrDefault(q => q.Id == answer.QuestionId);
                return question != null && question.Options == answer.SelectedOption;
            });

            int score = correctCount * 5;

            return score;

        }

        public async Task<bool> FinishExamAsync(UpdateExamResultDto dto)
        {
            var examResult = await _ExamResultDal.GetByIdAsync(dto.Id);
            if (examResult == null)
                return false;

            var calculatedScore = await CalculateScoreAsync(dto.Id);

            examResult.EndTime = dto.EndTime;
            examResult.Score = calculatedScore;  // dto.Score yerine hesaplanan puanı ata

            await _ExamResultDal.UpdateAsync(examResult);
            return true;

        }

        public async Task<List<ResultExamResultDto>> GetExamResultsByExamIdAsync(int examId)
        {
            var results = await _ExamResultDal.GetExamResultsWithExamAndUserAsync(x => x.ExamId == examId);
            return _mapper.Map<List<ResultExamResultDto>>(results);

        }

        public async Task<List<ResultExamResultDto>> GetExamResultsByUserAsync(int userId)
        {
            var List = await _ExamResultDal.GetExamResultsWithExamAndUserAsync(x => x.AppUserId == userId);

            return _mapper.Map<List<ResultExamResultDto>>(List);

        }

        public async Task<int> StartExamAsync(CreateExamResultDto dto)
        {
            var examResult = _mapper.Map<ExamResult>(dto);
            examResult.StartTime = DateTime.UtcNow;
            await _ExamResultDal.AddAsync(examResult);
            return examResult.Id;


        }

        public async Task TAddAsync(ExamResult entity)
        {
            await _ExamResultDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(int id)
        {
            await _ExamResultDal.DeleteAsync(id);
        }

        public async Task<List<ExamResult>> TGetAllAsync()
        {
            return await _ExamResultDal.GetAllAsync();
        }

        public async Task<ExamResult> TGetByIdAsync(int id)
        {
            return await _ExamResultDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(ExamResult entity)
        {
            await _ExamResultDal.UpdateAsync(entity);
        }
    }
}