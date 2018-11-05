using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainAppWindows.ViewModels;
using MainAppWindows.Models;
using MainAppWindows.Persistency;

namespace MainAppWindows.Handler
{
    public static class StatusRaportHandler
    {
        public static void CreateStatusRaport(StatusRaport statusRaport)
        {
            statusRaport.Dato = DateTime.Now;
            statusRaport.Godkendt = false;
            PersistencyFacade.NewRaport(statusRaport);
        }

        //TODO Make it possible to get lejligheders StatusRpporter based on JUST Lejlighed_No and not the whole ViewModel
        //
        public static List<StatusRaport> GetLejlighedsSR(LejlighedViewModel lVM)
        {
            //This list is to convert the FaldstammeRaports to StatusRaports
            List<StatusRaport> tempStatusRaportList = new List<StatusRaport>();
            tempStatusRaportList.AddRange(PersistencyFacade.GetFaldstammeRaports(lVM.LejlighedData.Lejlighed_No));
            return tempStatusRaportList;
        }
    }
}
