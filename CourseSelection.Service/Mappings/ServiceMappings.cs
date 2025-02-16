using AutoMapper;
using CourseSelection.Repository.Dtos.Condition;
using CourseSelection.Repository.Dtos.DataModel;
using CourseSelection.Service.Dtos.Info;
using CourseSelection.Service.Dtos.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSelection.Service.Mappings
{
    public class ServiceMappings : Profile
    {
        public ServiceMappings()
        {
            // Info -> Condition
            this.CreateMap<StudentInfo, StudentCondition>();

            // DataModel -> ResultModel
            this.CreateMap<StudentDataModel, StudentResultModel>();
        }

    }
}
