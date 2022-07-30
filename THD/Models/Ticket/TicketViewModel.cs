using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace THD.Web.Models.Ticket
{
    public class TicketViewModel
    {
        public int Id { get; set; }

        [Display(Name = "票券名称")]
        [Required(ErrorMessage = "{0}不可以为空")]
        public string Title { get; set; }
        public string Area { get; set; }

        [Display(Name = "票券类别")]
        [Required(ErrorMessage = "{0}不可以为空")]
        public string Type { get; set; }

        [Display(Name = "票券原价")]
        [Required(ErrorMessage = "{0}不可以为空")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "{0}请填写数字")]
        public int? Price { get; set; }

        [Display(Name = "票券现价")]
        [Required(ErrorMessage = "{0}不可以为空")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "{0}请填写数字")]
        public int? PriceNew { get; set; }
        public string Contents { get; set; }
        public string Notice { get; set; }
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
        public string Info11 { get; set; }
        public string Info12 { get; set; }
        public string Info13 { get; set; }
        public string Info14 { get; set; }
        public string Info15 { get; set; }
        public string Info16 { get; set; }
        public string Info17 { get; set; }
        public string Info18 { get; set; }
        public string Info19 { get; set; }
        public string Info20 { get; set; }
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
        public IFormFile FileImg11 { get; set; }
        public IFormFile FileImg12 { get; set; }
        public IFormFile FileImg13 { get; set; }
        public IFormFile FileImg14 { get; set; }
        public IFormFile FileImg15 { get; set; }
        public IFormFile FileImg16 { get; set; }
        public IFormFile FileImg17 { get; set; }
        public IFormFile FileImg18 { get; set; }
        public IFormFile FileImg19 { get; set; }
        public IFormFile FileImg20 { get; set; }
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
        public string Img11 { get; set; }
        public string Img12 { get; set; }
        public string Img13 { get; set; }
        public string Img14 { get; set; }
        public string Img15 { get; set; }
        public string Img16 { get; set; }
        public string Img17 { get; set; }
        public string Img18 { get; set; }
        public string Img19 { get; set; }
        public string Img20 { get; set; }
        public string Pid { get; set; }
        public string Datein { get; set; }
        public string Supplier { get; set; }
        public string Features { get; set; }
        public string Modus { get; set; }

        [Display(Name = "票券分类")]
        [Required(ErrorMessage = "{0}不可以为空")]
        public string Category { get; set; }
    }
}
