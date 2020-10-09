using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSM.WhatsHappening.Models;
using Orchard.ContentManagement.Drivers;

namespace CSM.WhatsHappening.Drivers {
    public class WhatsHappeningDriver : ContentPartDriver<Models.WhatsHappening> {
        protected override DriverResult Display(Models.WhatsHappening part, string displayType, dynamic shapeHelper) =>
            Combined(
                ContentShape(
                    "WhatsHappening",
                    () => shapeHelper.WhatsHappening(part)
                ),
                ContentShape(
                    "WhatsHappening_Summary",
                    () => shapeHelper.WhatsHappening_Summary(part)
                )
            );
    }
}
