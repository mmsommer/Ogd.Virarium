﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ogd.Virarium.Data.Migrations {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    public sealed partial class MigrationSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static MigrationSettings defaultInstance = ((MigrationSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new MigrationSettings())));
        
        public static MigrationSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\SQLEXPRESS;Initial Catalog=VirariumData;Integrated Security=True;Po" +
            "oling=False;")]
        public string Debug {
            get {
                return ((string)(this["Debug"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("SqlServer")]
        public string Provider {
            get {
                return ((string)(this["Provider"]));
            }
        }
    }
}
