using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace THD.Web.Models.Pickup
{
    public class PickupViewModel
    {
        public int Id { get; set; }

        [Display(Name = "接送名称")]
        [Required(ErrorMessage = "{0}不可以为空")]
        public string Title { get; set; }

        [Display(Name = "接送类别")]
        [Required(ErrorMessage = "{0}不可以为空")]
        public string Type { get; set; }

        [Display(Name = "接送原价")]
        [Required(ErrorMessage = "{0}不可以为空")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "{0}请填写数字")]
        public int? Price { get; set; }

        [Display(Name = "接送现价")]
        [Required(ErrorMessage = "{0}不可以为空")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "{0}请填写数字")]
        public int? PriceNew { get; set; }
        public string Area { get; set; }
        public string Info { get; set; }
        public string Contents { get; set; }
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
        public string Info4 { get; set; }
        public string Info5 { get; set; }
        public string Info6 { get; set; }
        public string Info7 { get; set; }
        public string Info8 { get; set; }
        public string Info9 { get; set; }
        public string Info10 { get; set; }
        public IFormFile FileImg1 { get; set; }
        public IFormFile FileImg2 { get; set; }
        public IFormFile FileImg3 { get; set; }
        public IFormFile FileImg4 { get; set; }
        public IFormFile FileImg5 { get; set; }
        public IFormFile FileImg6 { get; set; }
        public IFormFile FileImg7 { get; set; }
        public IFormFile FileImg8 { get; set; }
        public IFormFile FileImg9 { get; set; }
        public IFormFile FileImg10 { get; set; }
        public string Img1 { get; set; }
        public string Img2 { get; set; }
        public string Img3 { get; set; }
        public string Img4 { get; set; }
        public string Img5 { get; set; }
        public string Img6 { get; set; }
        public string Img7 { get; set; }
        public string Img8 { get; set; }
        public string Img9 { get; set; }
        public string Img10 { get; set; }
        public string Datein { get; set; }
        public string Pid { get; set; }
        public string Map { get; set; }
        public string Video { get; set; }
        public string Supplier { get; set; }
        public string Features { get; set; }
        public string Category { get; set; }
        public bool IsDelete { get; set; }
    }
}
