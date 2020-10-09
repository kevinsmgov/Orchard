using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSM.WhatsHappening.Models;
using Orchard.ContentManagement.Drivers;


namespace CSM.WhatsHappening.Drivers {
    public class WhatsHappeningListPartDriver : ContentPartDriver<WhatsHappeningListPart> {
        protected override DriverResult Display(WhatsHappeningListPart part, string displayType, dynamic shapeHelper) =>
            Combined(
                ContentShape("Parts_WhatsHappeningList",
                () => shapeHelper.Parts_WhatsHappeningList(part)),
                ContentShape("Parts_WhatsHappeningList_Summary",
                () => shapeHelper.Parts_WhatsHappeningList_Summary(part))
            );

    }
}