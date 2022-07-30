using THD.Web.Core.Extensions;

using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace THD.Web.Models.Tour
{
    public class TourViewModel
    {
        public int Id { get; set; }

        [Display(Name = "案件名")]
        [Required(ErrorMessage = "{0}をご入力ください。")]
        public string Title { get; set; }



        [Display(Name = "契約期間")]
        [Required(ErrorMessage = "{0}をご入力ください。")]
        public string Period { get; set; }



        [Display(Name = "作業場所")]
        [Required(ErrorMessage = "{0}をご入力ください。")]
        public string Area { get; set; }



        [Display(Name = "契約形態")]
        [Required(ErrorMessage = "{0}をご入力ください。")]
        public string Type { get; set; }



        [Display(Name = "月額単価")]
        [Required(ErrorMessage = "{0}をご入力ください。")]
        public string Price { get; set; }



        [Display(Name = "カテゴリー")]
        [Required(ErrorMessage = "{0}をご入力ください。")]
        public string Category { get; set; }



        [Display(Name = "開発言語")]
        [Required(ErrorMessage = "{0}をご入力ください。")]
        public string Language { get; set; }



        [Display(Name = "案件特徴")]
        [Required(ErrorMessage = "{0}をご入力ください。")]
        public string Characteristics { get; set; }



        [Display(Name = "案件内容")]
        [Required(ErrorMessage = "{0}をご入力ください。")]
        public IFormFile Contents { get; set; }



        [Display(Name = "人材要件")]
        [Required(ErrorMessage = "{0}をご入力ください。")]
        public IFormFile Human { get; set; }



        [Display(Name = "こだわり")]
        public IFormFile Commitment { get; set; }



        [Display(Name = "その他")]
        public IFormFile Others { get; set; }
    }
}
