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
    internal sealed partial class MigrationSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static MigrationSettings defaultInstance = ((MigrationSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new MigrationSettings())));
        
        public static MigrationSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("SqlServer")]
        public string Provider {
            get {
                return ((string)(this["Provider"]));
            }
            set {
                this["Provider"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\SQLEXPRESS;Initial Catalog=VirariumData;Integrated Security=True;Po" +
            "oling=False;")]
        public string DEBUG {
            get {
                return ((string)(this["DEBUG"]));
            }
            set {
                this["DEBUG"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\SQLEXPRESS;Initial Catalog=VirariumData;User ID=sa-Data;Password=ab" +
            "cd1234;Trusted_Connection=False;")]
        public string PRODUCTION {
            get {
                return ((string)(this["PRODUCTION"]));
            }
            set {
                this["PRODUCTION"] = value;
            }
        }
    }
}
