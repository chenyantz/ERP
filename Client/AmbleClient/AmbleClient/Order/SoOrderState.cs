using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmbleClient.Order
{
    
    
    public class Operation
    {
     public  JobDescription job;
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

      public void UpdateState(int soId, SoState soState)
      {
          int value = soState.GetStateValue();


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
          var operation = new Operation
          {
            job=JobDescription.saleManager,
            operationName="Rejected SO",
            operationMethod=this.RejectSo
          };
          var operation1 = new Operation
          {
              job = JobDescription.saleManager,
              operationName = "Approve SO",
              operationMethod = this.ApproveSo

          };

          operationList.Add(operation);
          operationList.Add(operation1);
      
      }

      public override int GetStateValue()
      {
          return 0;
      }

      public void RejectSo(int soId)
      {
          UpdateState(soId,new SoRejected());
      }
      public void ApproveSo(int soId)
      {
          UpdateState(soId, new SoApprove());
      }

  }


  public class SoRejected : SoState
  { 
  
  
  }

  public class SoApprove : SoState
  { 
  
  
  }






  public class SoOrderStateList
  { 
   //public static SoOrderState GetSO
  
  
  
  
  }


}
