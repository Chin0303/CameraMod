using System;

namespace CameraMod.Base
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SettingModuleAttribute : Attribute
    {
        public Type ModuleToModify;

        public SettingModuleAttribute(Type moduleToModify) 
        {
            ModuleToModify = moduleToModify;
        }
    }
}
