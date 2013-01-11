using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AmbleClient.RfqGui
{
    public class SalesRfqListView:RFQListView
    {

        public SalesRfqListView()
        { 
        
        }

        public override int GetPageCount(int itemsPerPage,string filterColumn, string filterString, bool includeSubs)
        {
            if (includeSubs)
            {
                return GlobalRemotingClient.GetRfqMgr().GetThePageCountOfDataTable(itemsPerPage, UserInfo.UserId,filterColumn,filterString);
            }
            else
            { 
              return GlobalRemotingClient.GetRfqMgr().GetThePageCountOfDataTablePerSale(itemsPerPage, UserInfo.UserId,filterColumn,filterString);
            }
        }

        public override System.Data.DataTable GetDataTableAccordingToPageNumber(int itemsPerPage,int currentPage, string filterColumn, string filterString, bool includeSubs)
        {   
            if (includeSubs)
            {
                return  GlobalRemotingClient.GetRfqMgr().GetICanSeeRfqDataTableAccordingToPageNumber(UserInfo.UserId, currentPage, itemsPerPage, filterColumn, filterString);
            }
            else 
            {
                return GlobalRemotingClient.GetRfqMgr().GetMyRfqDataTableAccordingToPageNumber(UserInfo.UserId, currentPage, itemsPerPage, filterColumn, filterString);
            }

        }



    }
}
