using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentPicker.Fields;

namespace CSM.WhatsHappening.Models {
    public class WhatsHappeningListPart : ContentPart {
        public IEnumerable<ContentItem> WhatsHappeningList {
            get {
                var field = Get(typeof(ContentPickerField), "WhatsHappeningList") as ContentPickerField;

                if (field == null)
                    return Enumerable.Empty<ContentItem>();

                return field.ContentItems;
            }
        }
    }
}