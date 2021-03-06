﻿using PagedList;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketPLek.DATA;
using TicketPLek.Models;

namespace TicketPLek.Controllers
{
    public class TicketController : Controller
    {
        // GET: Ticket
        string userOnline;
        // GET: Ticket
        public ActionResult Index(int page = 1, string seach = "", string type = "")
        {
            if (!chkSesionUser()) { return RedirectToAction("Login", "Login", new { returnUrl = "~/Ticket/Index" }); }

            IQueryable<VW_TICKET> View_Ticket;
            //OnUser usr = new OnUser();
            //usr = getUser(userOnline);
            seach = seach.Trim();
            //NName = NName.Trim();
            type = type.Trim();
            //TicketModel TicketList = new TicketModel();

            data_userDataContext Con = new data_userDataContext();
            DB_LEDataContext db = new DB_LEDataContext();

            ViewBag.Type = new SelectList(db.MAS_SSes, "SS_ID", "SS_NAME");

            var User = (from xx in Con.MAS_USERs
                        where xx.STCODE == userOnline
                        select xx).FirstOrDefault();

            ViewBag.DP = User.D_ID;
            ViewBag.A_ID = User.A_ID;

            List<Ticket> lstTicket = new List<Ticket>();

            using (DB_LEDataContext Context = new DB_LEDataContext())
            {
                View_Ticket = Context.VW_TICKETs.Where(s => s.TICKETNO.Contains(seach) || s.DPCODE.Contains(seach) || s.Recieve.Contains(seach)).Where(s => s.FLAG == "1").OrderByDescending(s => s.STATUS ).ThenByDescending(s=> s.ID);

                if (type != "")
                {
                    View_Ticket = View_Ticket.Where(tik => tik.STATUS == type);
                }

                if (User.D_ID != 10)
                {
                    View_Ticket = View_Ticket.Where(s => s.STCODE == userOnline);

                    foreach (var item in View_Ticket)
                    {
                        Ticket ux = new Ticket();

                        ux.ID = item.ID;
                        ux.TICKETNO = item.TICKETNO;
                        ux.DETAIL = item.DETAIL;
                        ux.CREATEDATE = DateTime.Parse(item.S_DATE.ToString()).ToShortDateString();
                        ux.CREATETIME = DateTime.Parse(item.E_DATE.ToString()).ToShortDateString();
                        ux.CRE_NICKNAME = item.CREATENAME;
                        ux.DEP = item.DPCODE;
                        ux.SSID = int.Parse( item.STATUS);
                        ux.SSNAME = item.SS_NAME;
                        ux.TicketName = item.TITLE;
                        ux.TICKETRECIEVE = item.Recieve;
                        if (item.F_DATE.ToString() !="")
                        {
                            ux.TICKETFDATE = DateTime.Parse(item.F_DATE.ToString()).ToShortDateString();
                        }
                       
                        lstTicket.Add(ux);
                    }
                }
                else
                {
                    if (User.A_ID == 3)
                    {
                        View_Ticket = View_Ticket.Where(s => s.STCODE == userOnline);
                    }
                    else
                    {
                        //View_Ticket = View_Ticket.Where(s => s.APPROVE_ID >= 2);
                    }

                    foreach (var item in View_Ticket)
                    {
                        Ticket ux = new Ticket();

                        ux.ID = item.ID;
                        ux.TICKETNO = item.TICKETNO;
                        ux.DETAIL = item.DETAIL;
                        ux.CREATEDATE = DateTime.Parse(item.S_DATE.ToString()).ToShortDateString();
                        ux.CREATETIME = DateTime.Parse(item.E_DATE.ToString()).ToShortDateString();
                        ux.CRE_NICKNAME = item.CREATENAME;
                        ux.DEP = item.DPCODE;
                        ux.SSID = int.Parse(item.STATUS);
                        ux.SSNAME = item.SS_NAME;
                        ux.TicketName = item.TITLE;
                        lstTicket.Add(ux);
                    }
                }


                //TicketList.TicketDetail = lstTicket;
            }
            //return View(lstTicket);
            //return View(lstTicket.ToPagedList(page, 10));

            ViewBag.WordSearch = seach;
            ViewBag.typeSearch = type;

            return View(lstTicket.ToPagedList(page, 10));
        }

        //Get : Create Ticket
        public ActionResult CreateTicket()
        {
            if (!chkSesionUser()) { return RedirectToAction("Login", "Login", new { returnUrl = "~/Ticket/Index" }); }
            TicketModel valus = new TicketModel();

            using (DB_LEDataContext Context = new DB_LEDataContext())
            {
                var sql = (from xx in Context.MAS_DOCs
                           orderby xx.TYPE
                           select xx);

                List<CheckBox> list = new List<CheckBox>();

                ViewBag.Count = sql.Count();
                ViewBag.Check = ViewBag.Count / 2;

                foreach (var item in sql)
                {
                    CheckBox ux = new CheckBox();
                    ux.ID = item.DOC_ID;
                    ux.Doc = item.DOC_NAME;
                    ux.Type = item.TYPE;

                    list.Add(ux);
                }

                valus.GetCheck = list;
            }
            return View(valus);
        }

        //POST: Create Ticket
        [HttpPost]
        [AllowAnonymous]
        public ActionResult CreateTicket(TicketModel newItem)
        {
            if (!chkSesionUser()) { return RedirectToAction("Login", "Login", new { returnUrl = "~/Ticket/Index" }); }

            string tketNo = ticketNo();

            using (DB_LEDataContext Context = new DB_LEDataContext())
            {
                TASK_MAIN Insert_Main = new TASK_MAIN();

                CultureInfo us = CultureInfo.GetCultureInfo("en-US");

                //System.Globalization.CultureInfo cultureinfo =        new System.Globalization.CultureInfo("nl-NL");
                DateTime dt = DateTime.Parse(newItem.Add.TicketSdate.ToString(), us);

                Insert_Main.TICKETNO = tketNo;
                Insert_Main.TITLE = newItem.Add.TicketName;
                Insert_Main.DETAIL = newItem.Add.Detail;
                Insert_Main.CREATEDATE = DateTime.Now;
                Insert_Main.CREATECODE = userOnline;
                Insert_Main.S_DATE = DateTime.Parse(newItem.Add.TicketSdate.ToString(), us); 
                Insert_Main.E_DATE = DateTime.Parse(newItem.Add.TicketFdate.ToString(), us); 
                Insert_Main.STCODE = userOnline;
                Insert_Main.STATUS = "3";
                Insert_Main.FLAG = "1";
                //Insert_Main.APPROVE_ID = 1;

                Context.TASK_MAINs.InsertOnSubmit(Insert_Main);
                Context.SubmitChanges();

                //var sql = (from xx in Context.TASK_MAINs
                //           where xx.TICKETNO == tketNo
                //           select xx).FirstOrDefault();

                //var doc = from xx in Context.MAS_DOCs
                //          select xx;
                //int i = 0;
                //foreach (var item in doc)
                //{
                //    TASK_SUB Insert_Sub = new TASK_SUB();

                //    if (newItem.GetCheck[i].Checked == true)
                //    {
                //        Insert_Sub.LE_ID = sql.ID;
                //        Insert_Sub.DOC_ID = newItem.GetCheck[i].ID;
                //        Insert_Sub.DETAIL_SUB = newItem.GetCheck[i].NAME;

                //        Context.TASK_SUBs.InsertOnSubmit(Insert_Sub);
                //        Context.SubmitChanges();
                //    }
                //    i++;
                //}
            }

            return RedirectToAction("Index", "Ticket");
        }

        public ActionResult TicketDetail(TicketModel Tic, int TicketId, string Url)
        {
            if (!chkSesionUser()) { return RedirectToAction("Login", "Login", new { returnUrl = "~/Ticket/Index" }); }

            TicketModel valus = new TicketModel();

            data_userDataContext Con = new data_userDataContext();

            var User = (from xx in Con.MAS_USERs
                        where xx.STCODE == userOnline
                        select xx).FirstOrDefault();

            ViewBag.DP = User.D_ID;
            ViewBag.A_ID = User.A_ID;
            ViewBag.Back = Url;

            using (DB_LEDataContext Context = new DB_LEDataContext())
            {
                var Main = (from xx in Context.VW_TICKETs
                            where xx.ID == TicketId
                            select xx).FirstOrDefault();

                var Sub = (from xx in Context.TASK_SUBs
                           join yy in Context.MAS_DOCs on xx.DOC_ID equals yy.DOC_ID
                           where xx.LE_ID == TicketId
                           orderby xx.DETAIL_SUB
                           select new { xx, yy });

                List<CheckBox> lstSub = new List<CheckBox>();

                int row = 1;
                //foreach (var item in Sub)
                //{
                //    CheckBox ux = new CheckBox();

                //    ux.row = row;
                //    ux.Doc = item.yy.DOC_NAME;
                //    ux.NAME = item.xx.DETAIL_SUB;
                //    ux.Type = item.yy.TYPE;

                //    lstSub.Add(ux);
                //    row++;
                //}

                valus.Detail = lstSub;

                Ticket lis = new Ticket();

                lis.TICKETNO = Main.TICKETNO;
                lis.DETAIL = Main.DETAIL;
                lis.CREATEDATE = DateTime.Parse(Main.S_DATE.ToString()).ToShortDateString();
                lis.CREATETIME = DateTime.Parse(Main.E_DATE.ToString()).ToShortDateString();
                lis.CRE_NICKNAME = Main.CREATENAME;
                lis.DEP = Main.DPCODE;
                lis.SSID = int.Parse(Main.STATUS);
                lis.SSNAME = Main.SS_NAME;
                lis.NAME_OPEN = Main.FNAME + " " + Main.LNAME;
                lis.DATE_OPEN = DateTime.Parse(Main.CREATEDATE.ToString()).ToShortDateString();
                lis.TICKETRECIEVE = Main.Recieve;
                lis.TicketName = Main.TITLE;
                if (Main.F_DATE.ToString()=="")
                {
                    lis.TICKETFDATE = "";
                }
                else
                {
                    lis.TICKETFDATE = DateTime.Parse(Main.F_DATE.ToString()).ToShortDateString();
                }
               
                //lis.NAME_HDEP = Main.HDEP_NAME;

                //if (Main.HDEP_DATE != null)
                //{
                //    lis.DATE_HDEP = DateTime.Parse(Main.HDEP_DATE.ToString()).ToShortDateString();
                //}

                //lis.NAME_RECEIVE = Main.RECEIVE_NAME;
                //if (Main.RECEIVE_DATE != null)
                //{
                //    lis.DATE_RECEIVE = DateTime.Parse(Main.RECEIVE_DATE.ToString()).ToShortDateString();
                //}

                //lis.NAME_CLOSE = Main.CLOSE_NAME;
                //if (Main.CLOSE_DATE != null)
                //{
                //    lis.DATE_CLOSE = DateTime.Parse(Main.CLOSE_DATE.ToString()).ToShortDateString();
                //}

                //lis.APP_ID = Main.APPROVE_ID;
                valus.TicketSub = lis;

            }

            ViewBag.TicNo = TicketId;


            return View(valus);
        }

        public ActionResult Delete(int Id)
        {
            try
            {
                using (DB_LEDataContext Context = new DB_LEDataContext())
                {
                    var sql_Main = Context.TASK_MAINs.Where(s => s.ID == Id).FirstOrDefault();
                    sql_Main.STATUS = "1";
                    sql_Main.FLAG = "0";
                    Context.SubmitChanges();
                    
                }
            }

            catch
            {

            }

            return RedirectToAction("Index", "Ticket");
        }

        public ActionResult TicketReceive(int Id)
        {
            try
            {
                if (!chkSesionUser()) { return RedirectToAction("Login", "Login", new { returnUrl = "~/Ticket/Index" }); }

                data_userDataContext Con = new data_userDataContext();
                var User = (from xx in Con.MAS_USERs
                            join yy in Con.MAS_DEPs on xx.D_ID equals yy.DP_ID
                            where xx.STCODE == userOnline
                            select new { xx, yy }).FirstOrDefault();

                using (DB_LEDataContext Context = new DB_LEDataContext())
                {
                    var sql_Main = Context.TASK_MAINs.Where(s => s.ID == Id).FirstOrDefault();

                    sql_Main.STATUS = "2";
                    //sql_Main.RECEIVE_NAME = User.xx.FNAME + " " + User.xx.LNAME;
                    //sql_Main.RECEIVE_DATE = DateTime.Now;
                    //sql_Main.APPROVE_ID = 3;

                    Context.SubmitChanges();
                }
            }
            catch
            {

            }

            return RedirectToAction("TicketDetail", "Ticket", new { TicketId = Id });
        }

        public ActionResult ApproveTicket(int page = 1, string seach = "", string type = "")
        {
            if (!chkSesionUser()) { return RedirectToAction("Login", "Login", new { returnUrl = "~/Ticket/Index" }); }

            IQueryable<VW_TICKET> View_Ticket;
            //OnUser usr = new OnUser();
            //usr = getUser(userOnline);
            seach = seach.Trim();
            //NName = NName.Trim();
            type = type.Trim();
            //TicketModel TicketList = new TicketModel();

            data_userDataContext Con = new data_userDataContext();
            DB_LEDataContext db = new DB_LEDataContext();

            ViewBag.Type = new SelectList(db.MAS_SSes, "SS_ID", "SS_NAME");

            var User = (from xx in Con.MAS_USERs
                        join yy in Con.MAS_DEPs on xx.D_ID equals yy.DP_ID
                        where xx.STCODE == userOnline
                        select new { xx, yy }).FirstOrDefault();

            ViewBag.DP = User.xx.D_ID;

            List<Ticket> lstTicket = new List<Ticket>();

            using (DB_LEDataContext Context = new DB_LEDataContext())
            {
                View_Ticket = Context.VW_TICKETs.Where(s => s.TICKETNO.Contains(seach) || s.DPCODE.Contains(seach) || s.Recieve.Contains(seach)).Where(s => s.STATUS == "1").Where(s => s.FLAG == "1").Where(s => s.DPCODE == User.yy.DPCODE).OrderBy(s => s.STATUS);


                foreach (var item in View_Ticket)
                {
                    Ticket ux = new Ticket();

                    ux.ID = item.ID;
                    ux.TICKETNO = item.TICKETNO;
                    ux.DETAIL = item.DETAIL;
                    ux.CREATEDATE = DateTime.Parse(item.S_DATE.ToString()).ToShortDateString();
                    ux.CREATETIME = DateTime.Parse(item.E_DATE.ToString()).ToLongTimeString();
                    ux.CRE_NICKNAME = item.Recieve;
                    ux.DEP = item.DPCODE;
                    ux.SSID = int.Parse(item.STATUS);
                    ux.SSNAME = item.SS_NAME;
                    ux.TicketName = item.TITLE;
                    lstTicket.Add(ux);
                }
            }

            ViewBag.WordSearch = seach;
            ViewBag.typeSearch = type;

            return View(lstTicket.ToPagedList(page, 10));
        }

        public ActionResult Approve(int Id)
        {
            if (!chkSesionUser()) { return RedirectToAction("Login", "Login", new { returnUrl = "~/Ticket/Index" }); }

            data_userDataContext Con = new data_userDataContext();
            var User = (from xx in Con.MAS_USERs
                        join yy in Con.MAS_DEPs on xx.D_ID equals yy.DP_ID
                        where xx.STCODE == userOnline
                        select new { xx, yy }).FirstOrDefault();

            using (DB_LEDataContext Context = new DB_LEDataContext())
            {
                var insert_Approve = Context.TASK_MAINs.Where(s => s.ID == Id).FirstOrDefault();

                insert_Approve.CLOSECODE = userOnline;
                insert_Approve.CLOSEDATE = DateTime.Now;
                insert_Approve.F_DATE = DateTime.Now;
                insert_Approve.STATUS = "2";

                Context.SubmitChanges();
            }

            return RedirectToAction("TicketDetail", "Ticket", new { TicketId = Id });
        }

        public ActionResult TicketClose(int Id)
        {
            if (!chkSesionUser()) { return RedirectToAction("Login", "Login", new { returnUrl = "~/Ticket/Index" }); }

            data_userDataContext Con = new data_userDataContext();
            var User = (from xx in Con.MAS_USERs
                        join yy in Con.MAS_DEPs on xx.D_ID equals yy.DP_ID
                        where xx.STCODE == userOnline
                        select new { xx, yy }).FirstOrDefault();

            using (DB_LEDataContext Context = new DB_LEDataContext())
            {
                var insert_Close = Context.TASK_MAINs.Where(s => s.ID == Id).FirstOrDefault();

                //insert_Close.CLOSE_NAME = User.xx.FNAME + " " + User.xx.LNAME;
                //insert_Close.CLOSE_DATE = DateTime.Now;
                //insert_Close.APPROVE_ID = 4;
                insert_Close.STATUS = "3";
                Context.SubmitChanges();
            }

            return RedirectToAction("TicketDetail", "Ticket", new { TicketId = Id });
        }

        private string ticketNo()
        {
            string runNo = "PL"; //IT17000009
            string strRun = "";
            string yy = DateTime.Now.Year.ToString();
            string mm = DateTime.Now.Month.ToString();
            int intRun = 1;


            yy = yy.Substring(yy.Length - 2, 2);
            if (mm.Length == 1) { mm = "0" + mm; }

            runNo = runNo + yy + mm;

            using (DB_LEDataContext Context = new DB_LEDataContext())
            {
                try
                {
                    var queryX = Context.TASK_MAINs.OrderByDescending(s => s.TICKETNO)
                    .Where(s => s.TICKETNO.Contains(runNo))
                    .FirstOrDefault();
                    strRun = queryX.TICKETNO;
                }
                catch
                {
                    strRun = runNo + yy + mm+"0000";
                }

            }

            strRun = strRun.Substring(strRun.Length - 4, 4);
            intRun = Int32.Parse(strRun);
            intRun = intRun + 1;

            strRun = intRun.ToString();
        
            switch (strRun.Length)
            {
                case 1:
                    strRun = "000" + strRun;
                    break;
                case 2:
                    strRun = "00" + strRun;
                    break;
                case 3:
                    strRun = "0" + strRun;
                    break;
            }

            runNo = runNo + strRun;

            return runNo;
        }

        /*------------------------------------------------------------- Login ------------------------------------------------*/

        public bool chkSesionUser()
        {
            bool chk = true;

            userOnline = GetCookie();

            if (userOnline == string.Empty)
            {
                try
                {
                    userOnline = Session["User"].ToString();
                    if (userOnline.Length < 1)
                    {
                        chk = false;
                    }
                }
                catch
                {
                    chk = false;
                }
            }

            using (data_userDataContext Context = new data_userDataContext())
            {
                try
                {
                    var sql = (from xx in Context.MAS_USERs
                               where xx.STCODE == userOnline
                               select xx).FirstOrDefault();

                    if (sql != null)
                    {
                        Session["SharedName"] = "สวัสดี " + sql.FNAME;
                        Session["Name"] = sql.FNAME;
                    }
                    else
                    {
                        Session["SharedName"] = "เข้าสู่ระบบ";
                    }
                }
                catch
                {
                    Session["SharedName"] = "เข้าสู่ระบบ";
                }
            }

            return chk;
        }

        private void SetCookie(string User)
        {
            try
            {
                Request.Cookies["bbStcode"].Value = User;
            }
            catch
            {
                HttpCookie BeautyCookies = new HttpCookie("bbStcode");
                BeautyCookies.Value = User;
                BeautyCookies.Expires = DateTime.Now.AddDays(1);

                Response.Cookies.Add(BeautyCookies);
            }
            //Request.Cookies["bbStcode"].Value = User;   
        }

        private string GetCookie()
        {
            string cookievalue = string.Empty;

            if (Request.Cookies["bbStcode"] != null)
            {
                cookievalue = Request.Cookies["bbStcode"].Value.ToString();
            }

            return cookievalue;
        }

        private void RemoveCookie()
        {
            if (Request.Cookies["bbStcode"] != null)
            {
                Response.Cookies["bbStcode"].Expires = DateTime.Now.AddDays(-1);
            }
        }

        public ActionResult Print(TicketModel Tic, int TicketId)
        {
            if (!chkSesionUser()) { return RedirectToAction("Login", "Login", new { returnUrl = "~/Ticket/Index" }); }

            TicketModel valus = new TicketModel();

            data_userDataContext Con = new data_userDataContext();

            var User = (from xx in Con.MAS_USERs
                        join yy in Con.MAS_DEPs on xx.D_ID equals yy.DP_ID
                        where xx.STCODE == userOnline
                        select new { xx, yy }).FirstOrDefault();

            ViewBag.DP = User.xx.D_ID;
            ViewBag.DPNAME = User.yy.DPCODE;
            ViewBag.FULLNAME = User.xx.FNAME + " " + User.xx.LNAME;

            using (DB_LEDataContext Context = new DB_LEDataContext())
            {
                var Main = (from xx in Context.VW_TICKETs
                            where xx.ID == TicketId
                            select xx).FirstOrDefault();

                var Sub = (from xx in Context.TASK_SUBs
                           join yy in Context.MAS_DOCs on xx.DOC_ID equals yy.DOC_ID
                           where xx.LE_ID == TicketId
                           orderby xx.DETAIL_SUB
                           select new { xx, yy });

                List<CheckBox> lstSub = new List<CheckBox>();

                int row = 1;
                foreach (var item in Sub)
                {
                    CheckBox ux = new CheckBox();

                    ux.row = row;
                    ux.Doc = item.yy.DOC_NAME;
                    ux.NAME = item.xx.DETAIL_SUB;
                    ux.Type = item.yy.TYPE;

                    lstSub.Add(ux);
                    row++;
                }

                valus.Detail = lstSub;

                Ticket lis = new Ticket();

                lis.TICKETNO = Main.TICKETNO;
                lis.DETAIL = Main.DETAIL;
                lis.CREATEDATE = DateTime.Parse(Main.S_DATE.ToString()).ToShortDateString();
                lis.CREATETIME = DateTime.Parse(Main.E_DATE.ToString()).ToShortDateString();
                lis.CRE_NICKNAME = Main.Recieve;
                lis.DEP = Main.DPCODE;
                lis.SSID = int.Parse(Main.STATUS);
                lis.SSNAME = Main.SS_NAME;
                lis.TicketName = Main.TITLE;
                lis.NAME_OPEN = Main.FNAME + " " + Main.LNAME;
                lis.DATE_OPEN = DateTime.Parse(Main.CREATEDATE.ToString()).ToShortDateString();
                //lis.NAME_HDEP = Main.HDEP_NAME;

                //if (Main.HDEP_DATE != null)
                //{
                //    lis.DATE_HDEP = DateTime.Parse(Main.HDEP_DATE.ToString()).ToShortDateString();
                //}

                //lis.NAME_RECEIVE = Main.RECEIVE_NAME;
                //if (Main.RECEIVE_DATE != null)
                //{
                //    lis.DATE_RECEIVE = DateTime.Parse(Main.RECEIVE_DATE.ToString()).ToShortDateString();
                //}

                //lis.NAME_CLOSE = Main.CLOSE_NAME;
                //if (Main.CLOSE_DATE != null)
                //{
                //    lis.DATE_CLOSE = DateTime.Parse(Main.CLOSE_DATE.ToString()).ToShortDateString();
                //}

                valus.TicketSub = lis;
            }

            ViewBag.TicNo = TicketId;

            return View(valus);
        }

        public ActionResult Manage(int page = 1, string sh = "")
        {
            if (!chkSesionUser()) { return RedirectToAction("Login", "Login", new { returnUrl = "~/Ticket/Index" }); }

            UserViewModels value = new UserViewModels();
            value.Page = page;
            value.sh = sh;

            return View(value);
        }

        public ActionResult Manage_Partial(int page = 1, string sh = "")
        {
            UserViewModels Model = new UserViewModels();

            data_userDataContext DropD = new data_userDataContext();
            var dep = (from xx in DropD.MAS_USER_As
                       orderby xx.US_ID
                       select xx).GroupBy(x => x.ANAME).Select(grp => grp.First());
            ViewBag.Dep = new SelectList(dep, "US_ID", "ANAME");

            sh = sh.Trim();

            List<USER_LOGIN> list = new List<USER_LOGIN>();

            using (data_userDataContext Context = new data_userDataContext())
            {
                IQueryable<VW_USER_FOR_LE> DataUser;
                DataUser = Context.VW_USER_FOR_LEs;

                if (sh.Length > 0)
                {
                    DataUser = DataUser.Where(x => x.STCODE.Contains(sh) || x.NAME.Contains(sh) || x.DPCODE.Contains(sh));
                }

                foreach (var dx in DataUser)
                {
                    USER_LOGIN ux = new USER_LOGIN();

                    ux.ID = dx.US_ID;
                    ux.STCODE = dx.STCODE;
                    ux.FULLNAME = dx.NAME;
                    ux.DEP = dx.DPCODE;
                    ux.A_NAME = dx.ANAME;

                    list.Add(ux);
                    //PhoneModels.RowPhone.Add(ipn);
                }
                //Model.RowUser = list;
            }

            ViewBag.sh = sh;

            return PartialView(list.ToPagedList(page, 20));
        }

        public ActionResult Edit(int Id, string STCODE, string Dep)
        {
            using (data_userDataContext Context = new data_userDataContext())
            {
                var sql = (from xx in Context.MAS_USERs
                           where xx.US_ID == Id
                           select xx).FirstOrDefault();

                sql.A_ID = byte.Parse(Dep);
                Context.SubmitChanges();
            }
            return RedirectToAction("Manage", "Ticket", new { sh = STCODE });
        }

        
    }
}