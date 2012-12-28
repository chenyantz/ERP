using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmbleClient.Finances
{
    public class CustomerVenderPrimaryKey
    {
        private int cvtype;
        private string cvname;
        private int ownerName;
        private string cvNumber;

        public int Cvtype { get { return cvtype; } }
        public string CvName { get { return cvname; } }
        public int OwnerName { get { return ownerName; } }
        public string CvNumber { get { return cvNumber; } }

        public CustomerVenderPrimaryKey(int cvtype, string cvname, int ownerName, string cvNumber)
        {
            this.cvtype = cvtype;
            this.cvname = cvname;
            this.ownerName = ownerName;
            this.cvNumber = cvNumber;

        }

    }
}
