using AutoMapper;
using CourseSelection.Repository.Dtos.Condition;
using CourseSelection.Repository.Dtos.DataModel;
using CourseSelection.Repository.Interface;
using CourseSelection.Service.Dtos.Info;
using CourseSelection.Service.Dtos.ResultModel;
using CourseSelection.Service.Interface;
using CourseSelection.Service.Mappings;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSelection.Service.Implement
{
    /// <summary>
    /// 管理學生資料
    /// </summary>
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository __studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ServiceMappings>());
            this._mapper = config.CreateMapper();
            this.__studentRepository = studentRepository;
        }

        /// <summary>
        /// 查詢學生列表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public IEnumerable<StudentResultModel> GetList(StudentInfo info)
        {
            var condition = this._mapper.Map<StudentInfo, StudentCondition>(info);
            var data = this.__studentRepository.GetList(condition);

            var result = this._mapper.Map<
                IEnumerable<StudentDataModel>,
                IEnumerable<StudentResultModel>>(data);

            return result;
        }

        /// <summary>
        /// 抓取學生單筆資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StudentResultModel Get(Guid id)
        {
            var card = this.__studentRepository.Get(id);
            var result = this._mapper.Map<StudentDataModel, StudentResultModel>(card);
            return result;
        }

        /// <summary>
        /// 新增學生資料
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool Insert(StudentInfo info)
        {
            var condition = this._mapper.Map<StudentInfo, StudentCondition>(info);
            var result = this.__studentRepository.Insert(condition);
            return result;
        }

        /// <summary>
        /// 更新學生資料
        /// </summary>
        /// <param name="id"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool Update(Guid id, StudentInfo info)
        {
            var condition = this._mapper.Map<StudentInfo, StudentCondition>(info);
            var result = this.__studentRepository.Update(id, condition);
            return result;
        }

        /// <summary>
        /// 刪除學生資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(Guid id)
        {
            var result = this.__studentRepository.Delete(id);
            return result;
        }

    }
}
