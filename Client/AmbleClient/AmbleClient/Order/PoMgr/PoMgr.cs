using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmbleClient.Order.PoView;

namespace AmbleClient.Order.PoMgr
{
   public class PoMgr
    {
      static private PoEntities poEntity=new PoEntities();


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
           return poList;
         
       }


       public static int GetPoNumberAccordingToSoId(int soId)
       {
           return poEntity.po.Where(poMain => poMain.soId == soId).Count();
       }
       
       
       public static List<po> GetPoAccordingToSoId(int soId)
       {
           List<po> poList = new List<po>();

               var poListFromDb = poEntity.po.Where(poMain => poMain.soId == soId);
               poList.AddRange(poListFromDb);
           return poList;
       
       }


       public static po GetPoAccordingToPoId(int poId)
       {

               var poList = from poMain in poEntity.po
                            where poMain.poId == poId
                            select poMain;
               return poList.First();
         
       
       }


       public static List<poitems> GetPoItemsAccordingToPoId(int poId)
       {
           List<poitems> poitems = new List<poitems>();

               var poitemsList = from poItem in poEntity.poitems
                                 where poItem.poId == poId
                                 select poItem;
               foreach(poitems poitem in poitemsList)
               {
                poitems.Add(poitem);
               
               }
               return poitems;
       }



       public static void SavePoMain(po poMain)
       {

               poEntity.po.AddObject(poMain);
               poEntity.SaveChanges();


       }


       public static int GetTheInsertId(int userId)
       {
              var maxId=(from poMain in poEntity.po
                        where (int)poMain.pa==userId
                        select poMain.poId).Max();

              return maxId;
       }



       public static void SavePoItems(int poId, List<poitems> poitemsList)
       {
               foreach (poitems poitem in poitemsList)
               {
                   poEntity.poitems.AddObject(poitem);
               }
               poEntity.SaveChanges();
       
       }


       public static void UpdatePoState(int poId, int state)
       {
               po poMain = (poEntity.po.First(item => item.poId == poId));
               poMain.poStates = (sbyte)state;
               poEntity.SaveChanges();
       }


       public static int GetSoIdAccordingToPoId(int poId)
       {

           var soId = from poItem in poEntity.po
                      where poItem.poId == poId
                      select poItem.soId;

             return (int)soId.First();

       }

       public static void DeletePoItembyPoItemId(int poItemId)
       {
           poitems item = poEntity.poitems.Where(i => i.PoItemsId == poItemId).First();
           poEntity.poitems.DeleteObject(item);
           poEntity.SaveChanges();
       }




       public static void UpdatePo(po poMain)
       {
           po poItem = poEntity.po.Where(item => item.poId == poMain.poId).First();
           poItem = poMain;
           poEntity.SaveChanges();
       }

       public static void UpDatePoItems(List<PoItemContentAndState> poItemStateList)
       {
           foreach (PoItemContentAndState pics in poItemStateList)
           {
               switch (pics.state)
               { 
                   case OrderItemsState.Normal:
                       break;
                   
                   case OrderItemsState.New:
                       poEntity.poitems.AddObject(pics.poItem);
                       break;

                   case OrderItemsState.Modified:
                       poitems item = poEntity.poitems.Where(pitem =>(pitem.PoItemsId == pics.poItem.PoItemsId)).First();
                       item = pics.poItem;
                       break;
               }
           }

           poEntity.SaveChanges();
       }





    }
}
