using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmbleClient.Order
{

    public abstract class PoState
    {
        protected List<Operation> operationList = new List<Operation>();
        public virtual int GetStateValue()
        {
            return -1;
        }
        public virtual string GetStateString()
        {
            return "empty";
        }

        public virtual List<JobDescription> WhoCanUpdate()
        {
            return null;
        }
        public void UpdateState(int soId, int soState)
        {
           // SoMgr.SoMgr.UpdateSoState(soId, UserInfo.UserId, soState);

        }
        public List<Operation> GetOperationList()
        {
            return operationList;
        }

    }

    public class PoNew : PoState
    {
        public override int GetStateValue()
        {
            return 0;
        }
        public override string GetStateString()
        {
            return "New";
        }    
    
    }
    public class PoRejected : PoState
    {
        public override int GetStateValue()
        {
            return 1;
        }
        public override string GetStateString()
        {
            return "Rejected";
        }    
    
    }
    public class PoApproved : PoState
    {
        public override int GetStateValue()
        {
            return 2;
        }
        public override string GetStateString()
        {
            return "Approved";
        }    
    
    }
    public class PoCancelled : PoState
    {
        public override int GetStateValue()
        {
            return 3;
        }
        public override string GetStateString()
        {
            return "Cancelled";
        }    
    
    }
    public class PoWaitingForShip : PoState
    {
        public override int GetStateValue()
        {
            return 4;
        }
        public override string GetStateString()
        {
            return "Waiting For Ship";
        }  
    }
    public class PoFullPaymentBeforeReceived : PoState
    {
        public override int GetStateValue()
        {
            return 5;
        }
        public override string GetStateString()
        {
            return "Full Payment Before Recv";
        }  
    
    }
    public class PoDeposit : PoState
    {
        public override int GetStateValue()
        {
            return 6;
        }
        public override string GetStateString()
        {
            return "Deposit";
        }  
    }
    public class PoBalance : PoState
    {
        public override int GetStateValue()
        {
            return 7;
        }
        public override string GetStateString()
        {
            return "Balance";
        }  
    
    }
    public class PoFullReceivedAfterPay : PoState
    {

        public override int GetStateValue()
        {
            return 8;
        }
        public override string GetStateString()
        {
            return "Full Received After Pay";
        }  
    
    }
    public class PoPartialReceivedAfterPay : PoState
    {
        public override int GetStateValue()
        {
            return 9;
        }
        public override string GetStateString()
        {
            return "Partial Received After Pay";
        }  
    
    }
    public class PoFullReceivedBeforePay : PoState
    {
        public override int GetStateValue()
        {
            return 10;
        }
        public override string GetStateString()
        {
            return "Pull Received Before Pay";
        }  
    
    
    }
    public class PoPartialReceivedBeforePay : PoState
    {
        public override int GetStateValue()
        {
            return 11;
        }
        public override string GetStateString()
        {
            return "Partial Received Before Pay";
        }  
    
    }
    public class PoFullPaymentAfterReceived : PoState
    {
        public override int GetStateValue()
        {
            return 12;
        }
        public override string GetStateString()
        {
            return "Full Payment After Recv";
        }  
    }
    public class PoClosed : PoState
    {
        public override int GetStateValue()
        {
            return 13;
        }
        public override string GetStateString()
        {
            return "Closed";
        }  
    }



    public class PoStateList
    {
        List<PoState> poStateList = new List<PoState>();

        public PoStateList()
        {
            poStateList.Add(new PoNew());
            poStateList.Add(new PoRejected());
            poStateList.Add(new PoApproved());
            poStateList.Add(new PoCancelled());
            poStateList.Add(new PoWaitingForShip());
            poStateList.Add(new PoFullPaymentBeforeReceived());
            poStateList.Add(new PoDeposit());
            poStateList.Add(new PoBalance());
            poStateList.Add(new PoFullReceivedAfterPay());
            poStateList.Add(new PoPartialReceivedAfterPay());
            poStateList.Add(new PoFullReceivedBeforePay());
            poStateList.Add(new PoPartialReceivedBeforePay());
            poStateList.Add(new PoFullPaymentBeforeReceived());
            poStateList.Add(new PoClosed());
        }


        public List<PoState> GetWholeSoStateList()
        {
            return poStateList;
        }

        public PoState GetPoStateAccordingToValue(int dbValue)
        {
            foreach (PoState state in poStateList)
            {
                if (state.GetStateValue() == dbValue)
                {
                    return state;
                }
            }
            return null;
        }

        public string GetPoStateStringAccordingToValue(int dbValue)
        {
            foreach (PoState state in poStateList)
            {
                if (state.GetStateValue() == dbValue)
                {

                    return state.GetStateString();
                }

            }
            return "";

        }

    }





}
