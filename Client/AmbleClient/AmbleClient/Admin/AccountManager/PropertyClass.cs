using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmbleClient.Admin.AccountMgr
{
    /// <summary>
    /// 表示若干属性的类
    /// </summary>
    /// 
    [Serializable]
    public class PropertyClass
    {
        private  int userId;
        /// <summary>
        /// 操作员代码
        /// </summary>
        public  int UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
            }
        }

        private  string accountName;
        /// <summary>
        /// 操作员名称
        /// </summary>
        public  string AccountName
        {
            get
            {
                return accountName;
            }
            set
            {
                accountName=value;
            }
        }

        private  string accountPassword;
        /// <summary>
        /// 操作员密码
        /// </summary>
        public  string AccountPassword
        {
            get
            {
                return accountPassword;
            }
            set
            {
                accountPassword = value;
            }
        }

        private  string email;
        /// <summary>
        /// email
        /// </summary>
        public  string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        private  int superviser;
    
        public  int Superviser
        {
            get
            {
                return superviser;
            }
            set
            {
                superviser = value;
            }
        }

        private  int job;
        public  int Job
        {
            get { return job; }
            set { job = value; }
        
        
        }

        
    }
}
