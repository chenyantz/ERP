using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleClient.Order.SoMgr;

namespace AmbleClient.Order
{

    public enum OrderItemsState
    { 
     Normal,
     New,
     Modified
    };




    
    public class Operation
    {
     public  List<JobDescription> jobs;
     public  string operationName;
     public  delegate void OperationMethod(int soId);
     public OperationMethod operationMethod;
    }
    
    
    
    public abstract class SoState
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
          listJobDes.Add(JobDescription.SalesManager);
          listJobDes.Add(JobDescription.Boss);
          listJobDes.Add(JobDescription.Admin);
          return listJobDes;
     }
      public void UpdateState(int soId, int soState)
      {
          SoMgr.SoMgr.UpdateSoState(soId, UserInfo.UserId, soState);

      }
      public List<Operation> GetOperationList()
      {
          return operationList;
      }

    }


  public class SoNew : SoState
  {
      public SoNew()
      {
          var opJobs=new List<JobDescription>();
          opJobs.Add(JobDescription.SalesManager);
          opJobs.Add(JobDescription.Boss);
          opJobs.Add(JobDescription.Admin);

          var operation = new Operation
          {
            jobs=opJobs,
            operationName="Reject SO",
            operationMethod=this.RejectSo
          };

          var operation1 = new Operation
          {
              jobs = opJobs,
              operationName = "Approve SO",
              operationMethod = this.ApproveSo

          };

          operationList.Add(operation);
          operationList.Add(operation1);
      
      }

      public override List<JobDescription> WhoCanUpdate()
      {
          var listJobDes = new List<JobDescription>();
          listJobDes.Add(JobDescription.Sales);
          listJobDes.Add(JobDescription.SalesManager);
          listJobDes.Add(JobDescription.Boss);
          listJobDes.Add(JobDescription.Admin);
          return listJobDes;

      }

      public override int GetStateValue()
      {
          return 0;
      }

      public override string GetStateString()
      {
          return "New";
      }

      public void RejectSo(int soId)
      {
          UpdateState(soId,new SoRejected().GetStateValue());
      }
      public void ApproveSo(int soId)
      {
          UpdateState(soId,new SoApprove().GetStateValue());
      }

  }


  public class SoRejected : SoState
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

  public class SoApprove : SoState
  {
      public SoApprove()
      {
          var opJobs=new List<JobDescription>();
          opJobs.Add(JobDescription.SalesManager);
          opJobs.Add(JobDescription.Boss);
          opJobs.Add(JobDescription.Admin);
          var operation = new Operation
          {
            jobs=opJobs,
            operationName="Cancel SO",
            operationMethod=this.CancelSo
          };
       }
      public override int GetStateValue()
      {
          return 2;
      }
      public override string GetStateString()
      {
          return "Approved";
      }
      public void CancelSo(int soId)
      {
          UpdateState(soId, new SoCancelled().GetStateValue());
      
      }
  }


    public class SoCancelled:SoState
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

    public class SoWaitingForShip : SoState
    {
        public SoWaitingForShip()
        {
        
        var opJobs1=new List<JobDescription>();
          opJobs1.Add(JobDescription.Financial);
          opJobs1.Add(JobDescription.FinancialManager);
          opJobs1.Add(JobDescription.Boss);
          opJobs1.Add(JobDescription.Admin);

          var operation = new Operation
          {
              jobs = opJobs1,
              operationName = "Payment Received Before Ship",
              operationMethod =this.SetStatePaymentRecvBeforeShip
          };

         var opJobs2=new List<JobDescription>();
          opJobs2.Add(JobDescription.Logistics);
          opJobs2.Add(JobDescription.LogisticsManager);
          opJobs2.Add(JobDescription.Boss);
          opJobs2.Add(JobDescription.Admin);

          var operation1 = new Operation
          {
              jobs = opJobs2,
              operationName = "Shipment Completed Before Pay",
              operationMethod = this.SetStateShipmentCompleteBeforePay

          };
          var operation2 = new Operation
          {
              jobs=opJobs2,
              operationName="Partial Shipment Before Pay",
              operationMethod=this.SetStatePartialShipmentBeforePay
          };
          operationList.Add(operation);
          operationList.Add(operation1);
          operationList.Add(operation2);

        }

        public void SetStatePaymentRecvBeforeShip(int soid)
        {
            UpdateState(soid, new SoPayMentRecvBeforeShip().GetStateValue());
        
        }

        public void SetStateShipmentCompleteBeforePay(int soid)
        {
            UpdateState(soid, new SoShipCompletedBeforePay().GetStateValue());
        }

        public void SetStatePartialShipmentBeforePay(int soid)
        {
            UpdateState(soid, new SoPartialShipBeforePay().GetStateValue());
        
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

    public class SoPayMentRecvBeforeShip : SoState
    {
        public SoPayMentRecvBeforeShip()
        {
            var opJobs = new List<JobDescription>();
            opJobs.Add(JobDescription.Logistics);
            opJobs.Add(JobDescription.LogisticsManager);
            opJobs.Add(JobDescription.Boss);
            opJobs.Add(JobDescription.Admin);

            var operation1 = new Operation
            {
                jobs = opJobs,
                operationName = "Shipment Completed After Pay",
                operationMethod = this.SetStateShipmentCompleteAfterPay

            };
            var operation2 = new Operation
            {
                jobs = opJobs,
                operationName = "Partial Shipment After Pay",
                operationMethod = this.SetStatePartialShipmentAfterPay
            };
            operationList.Add(operation1);
            operationList.Add(operation2);
        }
         
     private void SetStateShipmentCompleteAfterPay(int soid)
     {
         UpdateState(soid, new SoShipCompletedAfterPay().GetStateValue());
      }

     private void SetStatePartialShipmentAfterPay(int soid)
     {
         UpdateState(soid, new SoPartialShipAfterPay().GetStateValue());
     }

     public override int GetStateValue()
        {
            return 5;
        }
        public override string GetStateString()
        {
            return "PayMent Received Before Ship";
        }
    
    }

    public class SoShipCompletedAfterPay : SoState
    {
        public SoShipCompletedAfterPay()
        {
            var opJobs = new List<JobDescription>();
            opJobs.Add(JobDescription.FinancialManager);
            opJobs.Add(JobDescription.Boss);
            opJobs.Add(JobDescription.Admin);

            var operation1 = new Operation
            {
                jobs = opJobs,
                operationName = "Close SO",
                operationMethod = this.CloseSo

            };
            operationList.Add(operation1);

        }

        private void CloseSo(int soid)
        {
            UpdateState(soid, new SoClose().GetStateValue());
        
        }

        public override int GetStateValue()
        {
            return 6;
        }
        public override string GetStateString()
        {
            return "Shipment Complete after Pay";
        }
    
    }

    public class SoPartialShipAfterPay : SoState
    {
        public SoPartialShipAfterPay()
        {
            var opJobs = new List<JobDescription>();
            opJobs.Add(JobDescription.Logistics);
            opJobs.Add(JobDescription.LogisticsManager);
            opJobs.Add(JobDescription.Boss);
            opJobs.Add(JobDescription.Admin);

            var operation1 = new Operation
            {
                jobs = opJobs,
                operationName = "Shipment Completed After Pay",
                operationMethod = this.SetStateShipmentCompleteAfterPay

            };

            operationList.Add(operation1);

        }

        private void SetStateShipmentCompleteAfterPay(int soid)
        {
            UpdateState(soid, new SoShipCompletedAfterPay().GetStateValue());
        }

        public override int GetStateValue()
        {
            return 7;
        }
        public override string GetStateString()
        {
            return "Partial Shipment after Pay";
        }
    
    }
    public class SoShipCompletedBeforePay : SoState
    {
        public SoShipCompletedBeforePay()
        {
            var opJobs = new List<JobDescription>();
            opJobs.Add(JobDescription.Financial);
            opJobs.Add(JobDescription.FinancialManager);
            opJobs.Add(JobDescription.Boss);
            opJobs.Add(JobDescription.Admin);

            var operation1 = new Operation
            {
                jobs = opJobs,
                operationName = "Payment Received After Ship",
                operationMethod = this.SetStatePaymentReceviedAfterShip

            };

            operationList.Add(operation1);
       
        
        }

        private void SetStatePaymentReceviedAfterShip(int soid)
        {
            UpdateState(soid, new SoPayMentRecvAfterShip().GetStateValue());
        }

        public override int GetStateValue()
        {
            return 8;
        }
        public override string GetStateString()
        {
            return "Shipment Complete Before Pay";
        }

    }

    public class SoPartialShipBeforePay : SoState
    {
        public SoPartialShipBeforePay()
        {
            var opJobs = new List<JobDescription>();
            opJobs.Add(JobDescription.Logistics);
            opJobs.Add(JobDescription.LogisticsManager);
            opJobs.Add(JobDescription.Boss);
            opJobs.Add(JobDescription.Admin);

            var operation1 = new Operation
            {
                jobs = opJobs,
                operationName = "Shipment Completed Before Pay",
                operationMethod = this.SetStateShipmentCompleteBeforePay

            };

            operationList.Add(operation1);

        }

        private void SetStateShipmentCompleteBeforePay(int soid)
        {
            UpdateState(soid, new SoShipCompletedAfterPay().GetStateValue());
        }




        public override int GetStateValue()
        {
            return 9;
        }
        public override string GetStateString()
        {
            return "Partial Shipment Before Pay";
        }

    }

    public class SoPayMentRecvAfterShip : SoState
    {
        public SoPayMentRecvAfterShip()
        {
            var opJobs = new List<JobDescription>();
            opJobs.Add(JobDescription.FinancialManager);
            opJobs.Add(JobDescription.Boss);
            opJobs.Add(JobDescription.Admin);

            var operation1 = new Operation
            {
                jobs = opJobs,
                operationName = "Close SO",
                operationMethod = this.CloseSo

            };
            operationList.Add(operation1);

        }

        private void CloseSo(int soid)
        {
            UpdateState(soid, new SoClose().GetStateValue());

        }

        public override int GetStateValue()
        {
            return 10;
        }
        public override string GetStateString()
        {
            return "PayMent Received After Ship";
        }

    }

    public class SoClose : SoState
    {
        public override int GetStateValue()
        {
            return 11;
        }
        public override string GetStateString()
        {
            return "Closed";
        }
    
     }



  public  class SoOrderStateList
  {
     List<SoState> soStateList=new List<SoState>();

     public SoOrderStateList()
      { 

       soStateList.Add(new SoNew());
       soStateList.Add(new SoRejected());
       soStateList.Add(new SoApprove());
       soStateList.Add(new SoCancelled());
       soStateList.Add(new SoWaitingForShip());
       soStateList.Add(new SoPayMentRecvBeforeShip());
       soStateList.Add(new SoShipCompletedAfterPay());
       soStateList.Add(new SoPartialShipAfterPay());
       soStateList.Add(new SoShipCompletedBeforePay());
       soStateList.Add(new SoPartialShipBeforePay());
       soStateList.Add(new SoPayMentRecvAfterShip());
       soStateList.Add(new SoClose());
     
      }

      
      public List<SoState> GetWholeSoStateList()
      {
          return soStateList;     
      }

      public SoState GetSoStateAccordingToValue(int dbValue)
      {
          foreach (SoState state in soStateList)
          {
              if (state.GetStateValue() == dbValue)
              {
                  return state;
              }
          
          
          }
          return null;
      }

      public string GetSoStateStringAccordingToValue(int dbValue)
      {
          foreach (SoState state in soStateList)
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
