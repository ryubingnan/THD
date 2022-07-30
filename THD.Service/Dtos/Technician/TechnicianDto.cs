using System;
using System.Collections.Generic;
using System.Text;

namespace THD.Service.Dtos
{
    public class TechnicianDto
    {
        public int Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 假名
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 工作经历 文件
        /// </summary>
        public string WorkExperienceFilePath { get; set; }

        /// <summary>
        /// 要求
        /// </summary>
        public string Ask { get; set; }

        //ご希望
        //お知らせメール
        //案件紹介メール


        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
