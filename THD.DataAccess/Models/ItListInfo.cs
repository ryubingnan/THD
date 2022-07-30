using System;
using System.Collections.Generic;
using System.Text;
using THD.DataAccess.Models.Abstract;

namespace THD.DataAccess.Models
{
    public class ItListInfo : EntityBase
    {   
        //案件名	 
        public string Title { get; set; }
        //契約期間	    
        public string Period { get; set; }
        //作業場所	    
        public string Area { get; set; }
        //契約形態	    
        public string Type { get; set; }
        //月額単価	    
        public string Price { get; set; }
        //カテゴリー	    
        public string Category { get; set; }
        //開発言語	    
        public string Language { get; set; }
        //案件特徴	    
        public string Characteristics { get; set; }
        //案件内容	    
        public string Contents { get; set; }
        //人材要件	    
        public string Human { get; set; }
        //こだわり	    
        public string Commitment { get; set; }
        //その他	            
        public string Others { get; set; }

        public string user { get; set; }
        public string update { get; set; }
    }
}
