using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lab5_6.Controllers
{
    [Route("api/[controller]")]
    
    public class HomeController : Controller
    {
        private static List<Compounding> list = new List<Compounding>();

        [HttpPost]
        public ActionResult<string> GetCompounding(int sothang, long sotien, double tylelai)
        {
            if (tylelai < 0 || sotien < 0 || sothang < 0)
            {
                return Ok("Các Value không thể âm");
            }
            else if (tylelai > 0 && sotien > 0 && sothang > 0)
            {
                var lai = sotien * Math.Pow(1 + tylelai / 100, sothang) - sotien;
                var compounding = new Compounding(){ sothang = sothang, sotien = sotien, tylelai = tylelai , lai = Math.Round(lai)};
                list.Add(compounding);
                return Ok($"Số tiền lãi kép sau {sothang} tháng là : {Math.Round(lai , 2)}");
            }
            else
            {
                return NotFound("Lỗi");
            }

        }


        
        [HttpGet]
        public ActionResult<IEnumerable<Compounding>> GetCompounding()
        {
            return Ok(list);
        }

        //Bai 4
        //hihi
        
        private static List<trigle> ListAdd = new List<trigle>();
        [Route("bai4")]
        [HttpPost/*(Name = "Bai 4")*/]
        public ActionResult<double> CalculateArea(double a, double b, double c)
            {
          
                if (a <= 0 || b <= 0 || c <= 0 || a + b <= c || a + c <= b || b + c <= a)
                {
                    return BadRequest("Các cạnh không hợp lệ");
                }

                double s = (a + b + c) / 2;
                double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
                ListAdd.Add(new trigle());
                return Ok($"Diện tích là : {Math.Round(area, 2)}");
            }
        [HttpGet("CalculateArea")]
        public ActionResult<IEnumerable<trigle>> CalculateArea()
        {
            return Ok(ListAdd);
        }


    }
    
    public class Compounding
    {
        public int sothang { get; set; }
        public long sotien { get; set; }
        public double tylelai { get; set; }
        public double lai { get; set; }
    }
    public class trigle
    {
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
        public double area { get; set; }
    }
}

