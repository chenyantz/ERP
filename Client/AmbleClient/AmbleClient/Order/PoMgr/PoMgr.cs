﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmbleClient.Order.PoMgr
{
   public class PoMgr
    {
       public static List<po> GetPoAccordingToFilter(int userId, bool includedSubs, string filterColumn, string filterString, List<int> stateList)
       { 
         //get the sub;
           List<po> poList = new List<po>();
           if (stateList.Count == 0) return poList;

           List<int> userIds = new List<int>();

           if (includedSubs)
           {
               var accountMgr = new AmbleClient.Admin.AccountMgr.AccountMgr();
               userIds.AddRange(accountMgr.GetAllSubsId(userId));
           }
           else
           {
               userIds.Add(userId);
           }

           using(PoEntities poEntity=new PoEntities())
           {
            
               if(filterColumn.Trim().Length==0||filterString.Trim().Length==0)
               {
                var poListFromDb= from poItem in poEntity.po 
                                  where (userIds.Contains((int)poItem.pa)) &&(stateList.Contains((int)poItem.poStates))
                                  select poItem;

                poList.AddRange(poListFromDb);

              }

               if (filterColumn.Trim() == "vendorName" && filterString.Trim().Length != 0)
               {
                   var poListFromDb = from poItem in poEntity.po
                                      where (userIds.Contains((int)poItem.pa)) && (stateList.Contains((int)poItem.poStates)&&
                                      (poItem.vendorName.Contains(filterString.Trim())))
                                       select poItem;

                   poList.AddRange(poListFromDb);
               
               }
              




           }
           return poList;
         
       }

    }
}
