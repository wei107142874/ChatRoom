using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ZDSoft.CR.Domain
{
    public class UserInfo
    {
        public UserInfo(){ }

        public UserInfo(string name, string connectionId)
        {
            this.UserName = name;
            this.ConnectionID = connectionId;
        }


        [Key]
        public string ConnectionID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public string HeadUrl { get; set; }
        public char UserType { get; set; }
        public string LoginDate
        {
            get;
            set;
        }
        public DateTime RegisteredDate { get; set; }
        public DateTime ZhuxiaoDate { get; set; }

        public int ct { get; set; }
    }
}
