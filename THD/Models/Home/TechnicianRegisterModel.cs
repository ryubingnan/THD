using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace THD.Web.Models.Home
{
    /// <summary>
    /// 技术员注册
    /// TODO:目前是简写，后续完整数据，需要自己补充，暂时只是为了完善邮件发送功能
    /// </summary>
    public class TechnicianRegisterModel
    {
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
        public IFormFile WorkExperience { get; set; }

        /// <summary>
        /// 要求
        /// </summary>
        public string Ask { get; set; }

        //ご希望
        //お知らせメール
        //案件紹介メール
    }
}
