using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.Core.Common.Fields;
using Orchard.Core.Common.Models;
using Orchard.Core.Title.Models;
using Orchard.MediaLibrary.Fields;
using Orchard.Fields.Fields;


namespace CSM.WhatsHappening.Models {
    public class WhatsHappening : ContentPart {
        public string Image {
            get {
                var image = Get(typeof(MediaLibraryPickerField), "ImagePicker") as MediaLibraryPickerField;

                return image.FirstMediaUrl;
            }
        }
        public string Subtitle {
            get {

                var field = Get(typeof(TextField), "Subtitle") as TextField;

                if (field == null)
                    return String.Empty;

                return field.Value;
            }
        }
        public string Title {
            get {
                return this.As<TitlePart>().Title;
            }
        }

        public string URL {
            get {
                var venueLink = Get(typeof(LinkField), "URL") as LinkField;

                return venueLink.Value;
            }
        }
    }
}