using BepInEx;
using BepInEx.Logging;
using UnityEngine;

namespace CameraMod
{
    [BepInPlugin("chin.cameramod", "Camera Mod", "1.0")]
    public class Main : BaseUnityPlugin
    {
        public static ManualLogSource Logger;
        public Main()
        {
            Logger = base.Logger;

            GorillaTagger.OnPlayerSpawned(delegate
            {
                new GameObject("CameraManager").AddComponent<CameraManager>();
            });
        }
    }
}
