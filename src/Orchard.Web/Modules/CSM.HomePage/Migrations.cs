using System;
using System.Collections.Generic;
using System.Data;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace CSM.HomePage {
    public class Migrations : DataMigrationImpl {

        public int Create() {

            ContentDefinitionManager.AlterTypeDefinition("HomePage", type => type
                .Creatable(false)
                .Listable(true)
                .Draftable(true)
                .Securable(false)
                .DisplayedAs("Home Page")
                .WithIdentity()
                .WithPart("AutoroutePart", part => part
                    .WithSetting("AutorouteSettings.Alias", "home-page")
                    .WithSetting("AutorouteSettings.UseCustomPattern", "False")
                    .WithSetting("AutorouteSettings.UseCulturePattern", "False")
                    .WithSetting("AutorouteSettings.PromoteToHomePage", "True")
                )
                .WithPart("CommonPart", part => part
                    .WithSetting("DateEditorSettings.ShowDateEditor", "False")
                    .WithSetting("OwnerEditorSettings.ShowOwnerEditor", "False")
                )
                .WithPart("PublishLaterPart")
                .WithPart("TitlePart")
            );

            return 1;
        }
        public int UpdateFrom1() {
            ContentDefinitionManager.AlterTypeDefinition("HomePage", type => type
                .WithPart("WhatsHappeningListPart")
            );

            return 2;
        }

    }
}