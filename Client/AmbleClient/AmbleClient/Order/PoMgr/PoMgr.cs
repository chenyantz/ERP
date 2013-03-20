using System;
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
               userIds.AddRange(accountMgr.GetAllSubsId(userId,UserCombine.GetUserCanBeBuyers()));
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


       public static po GetPoAccordingToPoId(int poId)
       {
          using (PoEntities poEntity = new PoEntities())
           {
               var poList = from poMain in poEntity.po
                            where poMain.poId == poId
                            select poMain;
               return poList.First();
         
           }
       }


       public static List<poitems> GetPoItemsAccordingToPoId(int poId)
       {
           List<poitems> poitems = new List<poitems>();
           using (PoEntities poEntity = new PoEntities())
           {
               var poitemsList = from poItem in poEntity.poitems
                                 where poItem.poId == poId
                                 select poItem;
               foreach(poitems poitem in poitemsList)
               {
                poitems.Add(poitem);
               
               }
               return poitems;
           }
       }



       public static void SavePoMain(po poMain)
       {
           using (PoEntities poEntity = new PoEntities())
           {
               poEntity.po.AddObject(poMain);
               poEntity.SaveChanges();
           }

       }


       public static int GetTheInsertId(int userId)
       {
          using (PoEntities poEntity = new PoEntities())
           {
              var maxId=(from poMain in poEntity.po
                        where (int)poMain.pa==userId
                        select poMain.poId).Max();

              return maxId;
           }
       
       
       
       }



       public static void SavePoItems(int poId, List<poitems> poitemsList)
       {
           using (PoEntities poEntity = new PoEntities())
           {
               foreach (poitems poitem in poitemsList)
               {
                   poEntity.poitems.AddObject(poitem);
               }
               poEntity.SaveChanges();
           }
       
       }


       public static void UpdatePoState(int poId, int state)
       {
           using (PoEntities poEntity = new PoEntities())
           {
               po poMain = (poEntity.po.First(item => item.poId == poId));
               poMain.poStates = (sbyte)state;
               poEntity.SaveChanges();
           }
       }









    }
}
