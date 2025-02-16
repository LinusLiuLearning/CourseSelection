using CourseSelection.Service.Dtos.Info;
using CourseSelection.Service.Dtos.ResultModel;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSelection.Service.Interface
{
   public interface IStudentInterface
    {
        /// <summary>
        /// 查詢學生列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<StudentResultModel> GetList(StudentSearchInfo info);

        /// <summary>
        /// 單筆學生資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        StudentResultModel Get(Guid id);

        /// <summary>
        /// 新增學生資料
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool Insert(StudentInfo info);

        /// <summary>
        /// 更新學生資料
        /// </summary>
        /// <param name="id"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        bool Update(Guid id, StudentInfo info);

        /// <summary>
        /// 刪除學生資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(Guid id);
    }
}
