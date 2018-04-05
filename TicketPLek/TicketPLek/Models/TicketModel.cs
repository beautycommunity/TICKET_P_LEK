using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace TicketPLek.Models
{
    

    public class TicketModel
    {
        public List<CheckBox> Detail { get; set; }
        public Ticket TicketSub { get; set; }
        public List<Ticket> TicketDetail { get; set; }
        public DetailTciket Add { get; set; }
        public List<CheckBox> GetCheck { get; set; }
    }

    public class CheckBox
    {
        public int row { get; set; }

        [Display(Name = "เอกสารที่ขอ")]
        public int ID { get; set; }

        [Display(Name = "วัตถุประสงค์ในการใช้เอกสาร")]
        public string NAME { get; set; }

        [Display(Name = "เอกสารที่ขอ")]
        public string Doc { get; set; }

        [Display(Name = "ประเภท")]
        public string Type { get; set; }

        public bool Checked { get; set; }
    }

    public class DetailTciket
    {
   

        [Required(ErrorMessage = "กรุณาเพิ่มรายละเอียด")]
        [Display(Name = "รายละเอียด")]
        public string Detail { get; set; }

        [Required(ErrorMessage = "กรุณาเพิ่มหัวข้อ")]
        [Display(Name = "หัวข้อ")]
        public string TicketName { get; set; }

        [Required(ErrorMessage = "กรุณาเพิ่มผู้รับผิดชอบ")]
        [Display(Name = "ผู้รับผิดชอบ")]
        public string TicketIT { get; set; }

        [Required(ErrorMessage = "กรุณาเพิ่มวันที่กำหนดเสร็จ")]
        [Display(Name = "วันที่กำหนดเสร็จ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/YYYY}", ApplyFormatInEditMode = true)]
        public DateTime TicketFdate { get; set; }

        [Required(ErrorMessage = "กรุณาเพิ่มวันที่รับงาน")]
        [Display(Name = "วันที่รับงาน")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime TicketSdate { get; set; }


        public bool Checked { get; set; }
    }

    public class Ticket
    {
        public int? ID { get; set; }

        [Display(Name = "เลขที่")]
        public string TICKETNO { get; set; }

        [Display(Name = "ผู้รับงาน")]
        public string TICKETRECIEVE { get; set; }

        [Display(Name = "ผู้แจ้ง")]
        public string CRE_NICKNAME { get; set; }

        [Display(Name = "สถานะ")]
        public string SSNAME { get; set; }

        [Display(Name = "ไอดีสถานะ")]
        public int? SSID { get; set; }

        [Display(Name = "แผนก")]
        public string DEP { get; set; }

        [Display(Name = "วันที่รับ")]
        public string CREATEDATE { get; set; }

        [Display(Name = "กำหนดเสร็จ")]
        public string CREATETIME { get; set; }

        [Display(Name = "วันที่เสร็จ")]
        public string TICKETFDATE { get; set; }

        [Display(Name = "รายละเอียด")]
        public string DETAIL { get; set; }

        public bool Checked { get; set; }

        [Display(Name = "ผู้แจ้ง")]
        public string NAME_OPEN { get; set; }

        [Display(Name = "วันที่แจ้ง")]
        public string DATE_OPEN { get; set; }

        [Display(Name = "หัวข้อ")]
        public string TicketName { get; set; }

    }

}