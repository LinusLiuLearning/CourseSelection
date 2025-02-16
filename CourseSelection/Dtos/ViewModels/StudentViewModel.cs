namespace CourseSelection.Dtos
{
    public class StudentViewModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 學號
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年齡
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 性別:1-男;2-女
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 年級
        /// </summary>
        public string Grade { get; set; }
    }
}
