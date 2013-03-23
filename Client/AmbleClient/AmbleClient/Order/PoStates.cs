using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmbleClient.Order.SoMgr;
using AmbleClient.Order;

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
            var listJobDes = new List<JobDescription>();
            listJobDes.Add(JobDescription.buyerManager);
            listJobDes.Add(JobDescription.boss);
            listJobDes.Add(JobDescription.admin);
            return listJobDes; ;
        }
        public void UpdateState(int poId, int poState)
        {
            PoMgr.PoMgr.UpdatePoState(poId, poState);

        }
        public List<Operation> GetOperationList()
        {
            return operationList;
        }

    }

    public class PoNew : PoState
    {
      public PoNew()
      {
          var opJobs=new List<JobDescription>();
          opJobs.Add(JobDescription.buyer);
          opJobs.Add(JobDescription.buyerManager);
          opJobs.Add(JobDescription.boss);
          opJobs.Add(JobDescription.admin);

          var operation = new Operation
          {
            jobs=opJobs,
            operationName="Reject PO",
            operationMethod=this.RejectPo
          };

          var operation1 = new Operation
          {
              jobs = opJobs,
              operationName = "Approve PO",
              operationMethod = this.ApprovePo

          };

          operationList.Add(operation);
          operationList.Add(operation1);
      
      }


      public override List<JobDescription> WhoCanUpdate()
      {
          var listJobDes = new List<JobDescription>();
          listJobDes.Add(JobDescription.buyerManager);
          listJobDes.Add(JobDescription.boss);
          listJobDes.Add(JobDescription.admin);
          return listJobDes; ;
      }

      public void RejectPo(int poId)
      {
          UpdateState(poId, new PoRejected().GetStateValue());
       
      }
      public void ApprovePo(int poId)
      {
          UpdateState(poId, new PoApproved().GetStateValue());
       }
        
        
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
      public PoApproved()
      {
          var opJobs=new List<JobDescription>();
          opJobs.Add(JobDescription.buyerManager);
          opJobs.Add(JobDescription.boss);
          opJobs.Add(JobDescription.admin);

          var operation = new Operation
          {
            jobs=opJobs,
            operationName="Cancel PO",
            operationMethod=this.CancelPo
          };

          var opJobs1 = new List<JobDescription>();
          opJobs1.Add(JobDescription.buyer);
          opJobs1.Add(JobDescription.buyerManager);
          opJobs1.Add(JobDescription.boss);
          opJobs1.Add(JobDescription.admin);
          
          var operation1 = new Operation
          {
              jobs = opJobs1,
              operationName = "Waiting for Ship",
              operationMethod = this.SetPoStateWatingForShip

          };

          operationList.Add(operation);
          operationList.Add(operation1);
      
      }

      public void CancelPo(int poId)
      {
          UpdateState(poId, new PoCancelled().GetStateValue());

      }
      public void SetPoStateWatingForShip(int poId)
      {
          UpdateState(poId, new PoWaitingForShip().GetStateValue());
          SoMgr.SoMgr.UpdateSoState(PoMgr.PoMgr.GetSoIdAccordingToPoId(poId),UserInfo.UserId, new SoWaitingForShip().GetStateValue());



      }

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

        public PoWaitingForShip()
      {
          var opJobs=new List<JobDescription>();
          opJobs.Add(JobDescription.financialManager);
          opJobs.Add(JobDescription.boss);
          opJobs.Add(JobDescription.admin);

          var operation = new Operation
          {
            jobs=opJobs,
            operationName="Full Payment Before Recv",
            operationMethod=this.SetStateFullPaymentBeforeRecv
          };
          var operation1 = new Operation
          {
              jobs = opJobs,
              operationName = "Deposit",
              operationMethod = this.SetStateDeposit

          };

          var opJobs1 = new List<JobDescription>();

          opJobs1.Add(JobDescription.wareshousekeeperManager);
          opJobs1.Add(JobDescription.boss);
          opJobs1.Add(JobDescription.admin);
          
          var operation2 = new Operation
          {
              jobs = opJobs1,
              operationName = "Full Received Before Pay",
              operationMethod = this.SetStateFullRecivedBeforePay

          };
          var operation3 = new Operation
          {
              jobs = opJobs1,
              operationName = "Partial Received Before Pay",
              operationMethod = this.SetStatePartialRecivedBeforePay

          };


          operationList.Add(operation);
          operationList.Add(operation1);
          operationList.Add(operation2);
          operationList.Add(operation3);
      
      }

        public void SetStateFullPaymentBeforeRecv(int poId)
      {
          UpdateState(poId, new PoFullPaymentBeforeReceived().GetStateValue());

      }
        public void SetStateDeposit(int poId)
      {
          UpdateState(poId, new PoDeposit().GetStateValue());
      }

        public void SetStateFullRecivedBeforePay(int poId)
        {
            UpdateState(poId, new PoFullReceivedBeforePay().GetStateValue());

        }
        public void SetStatePartialRecivedBeforePay(int poId)
        {
            UpdateState(poId, new PoPartialReceivedBeforePay().GetStateValue());
        }
        
        
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
       public PoFullPaymentBeforeReceived()
       {
        var opJobs=new List<JobDescription>();
          opJobs.Add(JobDescription.wareshousekeeperManager);
          opJobs.Add(JobDescription.boss);
          opJobs.Add(JobDescription.admin);

          var operation = new Operation
          {
            jobs=opJobs,
            operationName="Full Received After Pay",
            operationMethod=this.SetStateFullReceivedAfterPay
          };
          
          var operation1 = new Operation
          {
              jobs = opJobs,
              operationName = "Partial Received After Pay",
              operationMethod = this.SetStatePartialReceivedAfterPay

          };

          operationList.Add(operation);
          operationList.Add(operation1);
      
      }

       public void SetStateFullReceivedAfterPay(int poId)
      {
          UpdateState(poId, new PoFullReceivedAfterPay().GetStateValue());

      }
       public void SetStatePartialReceivedAfterPay(int poId)
      {
          UpdateState(poId, new PoPartialReceivedAfterPay().GetStateValue());
      }

    
        
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
     public PoDeposit()
       {
        var opJobs=new List<JobDescription>();
          opJobs.Add(JobDescription.financialManager);
          opJobs.Add(JobDescription.boss);
          opJobs.Add(JobDescription.admin);

          var operation = new Operation
          {
            jobs=opJobs,
            operationName="Balance",
            operationMethod=this.Balance
          };
          
          operationList.Add(operation);
      
      }

      public void Balance(int poId)
      {
          UpdateState(poId, new PoFullReceivedAfterPay().GetStateValue());

      }
        
        
        
        
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
      public PoBalance()
       {
        var opJobs=new List<JobDescription>();
          opJobs.Add(JobDescription.wareshousekeeperManager);
          opJobs.Add(JobDescription.boss);
          opJobs.Add(JobDescription.admin);

          var operation = new Operation
          {
            jobs=opJobs,
            operationName="Full Received After Pay",
            operationMethod=this.SetStateFullReceivedAfterPay
          };
          
          var operation1 = new Operation
          {
              jobs = opJobs,
              operationName = "Partial Received After Pay",
              operationMethod = this.SetStatePartialReceivedAfterPay

          };

          operationList.Add(operation);
          operationList.Add(operation1);
      
      }

       public void SetStateFullReceivedAfterPay(int poId)
      {
          UpdateState(poId, new PoFullReceivedAfterPay().GetStateValue());

      }
       public void SetStatePartialReceivedAfterPay(int poId)
      {
          UpdateState(poId, new PoPartialReceivedAfterPay().GetStateValue());
      }



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

      public PoFullReceivedAfterPay()
      {
          var opJobs=new List<JobDescription>();
          opJobs.Add(JobDescription.wareshousekeeperManager);
          opJobs.Add(JobDescription.boss);
          opJobs.Add(JobDescription.admin);

          var operation = new Operation
          {
            jobs=opJobs,
            operationName="Close PO",
            operationMethod=this.ClosePo
          };

          operationList.Add(operation);
      
      }

      public void ClosePo(int poId)
      {
          UpdateState(poId, new PoClosed().GetStateValue());

      }



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
        public PoPartialReceivedAfterPay()
      {
          var opJobs=new List<JobDescription>();
          opJobs.Add(JobDescription.wareshousekeeperManager);
          opJobs.Add(JobDescription.boss);
          opJobs.Add(JobDescription.admin);

          var operation = new Operation
          {
            jobs=opJobs,
            operationName="Full Received After Pay",
            operationMethod=this.SetStateFullReceivedAfterPay
          };

          operationList.Add(operation);
      
      }

        public void SetStateFullReceivedAfterPay(int poId)
      {
          UpdateState(poId, new PoFullReceivedAfterPay().GetStateValue());

      }
        
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
      public PoFullReceivedBeforePay()
      {
          var opJobs=new List<JobDescription>();
          opJobs.Add(JobDescription.financialManager);
          opJobs.Add(JobDescription.boss);
          opJobs.Add(JobDescription.admin);

          var operation = new Operation
          {
            jobs=opJobs,
            operationName="Full Payment After Recv",
            operationMethod=this.SetStateFullPaymentAfterRecv
          };

          operationList.Add(operation);
      
      }

      public void SetStateFullPaymentAfterRecv(int poId)
      {
          UpdateState(poId, new PoFullPaymentAfterReceived().GetStateValue());

      }
        
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
        public PoPartialReceivedBeforePay()
      {
          var opJobs1 = new List<JobDescription>();
          opJobs1.Add(JobDescription.wareshousekeeperManager);
          opJobs1.Add(JobDescription.boss);
          opJobs1.Add(JobDescription.admin);
          
          var operation2 = new Operation
          {
              jobs = opJobs1,
              operationName = "Full Received Before Pay",
              operationMethod = this.SetStateFullRecivedBeforePay

          };

          operationList.Add(operation2);
      
      }


        public void SetStateFullRecivedBeforePay(int poId)
        {
            UpdateState(poId, new PoFullReceivedBeforePay().GetStateValue());

        }

        
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

      public PoFullPaymentAfterReceived()
      {
          var opJobs=new List<JobDescription>();
          opJobs.Add(JobDescription.wareshousekeeperManager);
          opJobs.Add(JobDescription.boss);
          opJobs.Add(JobDescription.admin);

          var operation = new Operation
          {
            jobs=opJobs,
            operationName="Close PO",
            operationMethod=this.ClosePo
          };

          operationList.Add(operation);
      
      }

      public void ClosePo(int poId)
      {
          UpdateState(poId, new PoClosed().GetStateValue());

      } 
        
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
