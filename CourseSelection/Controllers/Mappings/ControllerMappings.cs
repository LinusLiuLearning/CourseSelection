using AutoMapper;
using CourseSelection.Dtos;
using CourseSelection.Service.Dtos.Info;
using CourseSelection.Service.Dtos.ResultModel;

namespace CourseSelection.Controllers.Mappings
{
    public class ControllerMappings : Profile
    {
        public ControllerMappings()
        {
            // Parameter -> Info
            this.CreateMap<StudentParameter, StudentInfo>();

            // ResultModel -> ViewModel
            this.CreateMap<StudentResultModel, StudentViewModel>();
        }

    }
}
