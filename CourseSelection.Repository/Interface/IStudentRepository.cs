using CourseSelection.Repository.Dtos.Condition;
using CourseSelection.Repository.Dtos.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSelection.Repository.Interface
{
    public interface IStudentRepository
    {
        /// <summary>
        /// 查詢學生列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<StudentDataModel> GetList(StudentCondition info);

        /// <summary>
        /// 查詢單筆學生資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        StudentDataModel Get(Guid id);

        /// <summary>
        /// 新增學生資料
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool Insert(StudentCondition info);

        /// <summary>
        /// 更新學生資料
        /// </summary>
        /// <param name="id"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        bool Update(Guid id, StudentCondition info);

        /// <summary>
        /// 刪除學生資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(Guid id);
    }
}
