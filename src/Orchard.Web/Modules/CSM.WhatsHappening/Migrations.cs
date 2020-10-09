using System;
using System.Collections.Generic;
using System.Data;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace CSM.WhatsHappening {
    public class Migrations : DataMigrationImpl {

        public int Create() {
            ContentDefinitionManager.AlterPartDefinition("WhatsHappening", part => part
            .Attachable(false)
            .WithField("ImagePicker", field => field
                .OfType("MediaLibraryPickerField")
                .WithDisplayName("Image")
                .WithSetting("MediaLibraryPickerFieldSettings.DisplayedContentTypes", "Image")
                .WithSetting("MediaLibraryPickerFieldSettings.Multiple", "False")
                .WithSetting("MediaLibraryPickerFieldSettings.Required", "False")
                )
            .WithField("Subtitle", field => field
                .OfType("TextField")
                .WithDisplayName("Subtitle")
                .WithSetting("TextFieldSettings.Flavor", "large")
                .WithSetting("TextFieldSettings.Required", "False")
                )
            .WithField("URL", field => field
                .OfType("LinkField")
                .WithDisplayName("URL")
                .WithSetting("LinkFieldSettings.LinkText", "Url")
                .WithSetting("LinkFieldSettings.Required", "True")
                .WithSetting("LinkFieldSettings.TargetMode", "Open link in new window")
                .WithSetting("LinkFieldSettings.Hint", "Enter Full URL e.g. https://www.google.com")
                )
            );

            ContentDefinitionManager.AlterPartDefinition("WhatsHappeningListPart", part => part
            .Attachable(false)
            .WithField("WhatsHappeningList", field => field
                .OfType("ContentPickerField")
                .WithDisplayName("What's Happening")
                .WithSetting("ContentPickerFieldSettings.Required", "False")
                .WithSetting("ContentPickerFieldSettings.Multiple", "True")
                .WithSetting("ContentPickerFieldSettings.DisplayedContentTypes", "WhatsHappening")
                )
            );

            ContentDefinitionManager.AlterTypeDefinition("WhatsHappening", type => type
                .Creatable()
                .Listable()
                .Draftable()
                .Securable(true)
                .DisplayedAs("What's Happening")
                .WithPart("CommonPart")
                .WithPart("IdentityPart")
                .WithPart("TitlePart")
                .WithPart("WhatsHappening")
            );

            return 1;
        }
    }
}