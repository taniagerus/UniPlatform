using AutoMapper;
using UniPlatform.DB.Entities;
using UniPlatform.ViewModels;

namespace UniPlatform.ProfileMappers
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<TestOption, OptionViewModel>()
                .ForMember(dest => dest.IsCorrect, opt => opt.MapFrom(src => false))
                .ReverseMap();

            CreateMap<Question, QuestionViewModel>();

            CreateMap<QuestionViewModel, Question>()
                .ForMember(
                    dest => dest.CorrectAnswer,
                    opt =>
                        opt.MapFrom(src =>
                            src.Type == TestType.TextAnswer ? src.CorrectAnswer : string.Empty
                        )
                )
                .ForMember(
                    dest => dest.TestOptions,
                    opt =>
                        opt.MapFrom(src =>
                            src.TestOptions.Select(option => new TestOption
                                {
                                    OptionText = option.OptionText,
                                    IsCorrect = option.IsCorrect,
                                })
                                .ToList()
                        )
                );

            CreateMap<TestAssignmentViewModel, TestAssignment>()
                .ForMember(s => s.Questions, d => d.MapFrom(m => m.Questions));
            CreateMap<TestAssignment, TestAssignmentViewModel>()
                .ForMember(
                    dest => dest.CategoryQuestions,
                    opt => opt.MapFrom(src => MapCategories(src.Categories))
                )
                .ForMember(
                    dest => dest.Questions,
                    opt => opt.MapFrom(src => src.Questions.Select(q => q.Question))
                )
                .ReverseMap()
                .ForMember(
                    dest => dest.Categories,
                    opt =>
                        opt.MapFrom(src =>
                            string.Join(";", src.CategoryQuestions.Select(cq => cq.Category))
                        )
                )
                .ForMember(dest => dest.Questions, opt => opt.Ignore());
        }

        private List<CategoryQuestionCountViewModel> MapCategories(string categories)
        {
            if (string.IsNullOrEmpty(categories))
                return new List<CategoryQuestionCountViewModel>();

            return categories
                .Split(';')
                .Select(category => new CategoryQuestionCountViewModel { Category = category })
                .ToList();
        }
    }
}
