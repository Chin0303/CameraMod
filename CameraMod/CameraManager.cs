using UnityEngine;
using CameraMod.Base;
using CameraMod.Modules;
using System.Linq;
using CameraMod.Modules.Settings;
using System.Reflection;

namespace CameraMod
{
    public class CameraManager : MonoBehaviour
    {
        public static CameraModule[] cameraModules;

        private void Awake()
        {
            cameraModules = new CameraModule[]
            {
                gameObject.AddComponent<FirstPerson>(),
                gameObject.AddComponent<ThirdPerson>(),
                gameObject.AddComponent<FollowPlayer>(),

                // Settings
                gameObject.AddComponent<FollowSpeed>()
            };

            foreach (var item in cameraModules)
            {
                if (item.GetType().GetCustomAttribute(typeof(SettingModuleAttribute)) != null)
                {
                    SettingModuleAttribute settingAttribute = item.GetType().GetCustomAttributes(typeof(SettingModuleAttribute)) as SettingModuleAttribute;
                    Main.Logger.LogInfo($"{item.GetType().Name} is a setting module and modifies {settingAttribute.ModuleToModify.Name}");
                }
                else
                    Main.Logger.LogInfo($"{item.GetType().Name} is a normal module");
            }
        }
    }
}
