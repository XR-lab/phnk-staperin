﻿//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Valve.VR
{
    public class SteamVR_Settings : ScriptableObject
    {
        private static SteamVR_Settings _instance;
        public static SteamVR_Settings instance
        {
            get
            {
                LoadInstance();

                return _instance;
            }
        }

        public bool pauseGameWhenDashboardVisible = true;
        public bool lockPhysicsUpdateRateToRenderFrequency = true;
        public Valve.VR.ETrackingUniverseOrigin trackingSpace = Valve.VR.ETrackingUniverseOrigin.TrackingUniverseStanding;

        [Tooltip("Filename local to the project root (or executable, in a build)")]
        public string actionsFilePath = "actions.json";

        [Tooltip("Path local to the Assets folder")]
        public string steamVRInputPath = "SteamVR_Input";

        public SteamVR_UpdateModes inputUpdateMode = SteamVR_UpdateModes.OnUpdate;
        public SteamVR_UpdateModes poseUpdateMode = SteamVR_UpdateModes.OnPreCull;

        public bool activateFirstActionSetOnStart = true;

        [Tooltip("This is the app key the unity editor will use to identify your application. (can be \"steam.app.[appid]\" to persist bindings between editor steam)")]
        public string editorAppKey;

        [Tooltip("The SteamVR Plugin can automatically make sure VR is enabled in your player settings and if not, enable it.")]
        public bool autoEnableVR = true;

        public bool IsInputUpdateMode(SteamVR_UpdateModes tocheck)
        {
            return (inputUpdateMode & tocheck) == tocheck;
        }
        public bool IsPoseUpdateMode(SteamVR_UpdateModes tocheck)
        {
            return (poseUpdateMode & tocheck) == tocheck;
        }

        public static void VerifyScriptableObject()
        {
            LoadInstance();
        }

        private static void LoadInstance()
        {
            if (_instance == null)
            {
                _instance = Resources.Load<SteamVR_Settings>("SteamVR_Settings");

                if (_instance == null)
                {
                    _instance = SteamVR_Settings.CreateInstance<SteamVR_Settings>();

#if UNITY_EDITOR
                    string folderPath = SteamVR.GetResourcesFolderPath(true);
                    string assetPath = System.IO.Path.Combine(folderPath, "SteamVR_Settings.asset");

                    UnityEditor.AssetDatabase.CreateAsset(_instance, assetPath);
                    UnityEditor.AssetDatabase.SaveAssets();
#endif
                }

                if (string.IsNullOrEmpty(_instance.editorAppKey))
                {
                    _instance.editorAppKey = SteamVR.GenerateAppKey();
                    Debug.Log("<b>[SteamVR]</b> Generated you an editor app key of: " + _instance.editorAppKey + ". This lets the editor tell SteamVR what project this is. Has no effect on builds. This can be changed in Assets/SteamVR/Resources/SteamVR_Settings");
#if UNITY_EDITOR
                    UnityEditor.EditorUtility.SetDirty(_instance);
                    UnityEditor.AssetDatabase.SaveAssets();
#endif
                }
            }
        }

        protected const string openVRString = "OpenVR";
        protected const string openVRPackageString = "com.unity.xr.openvr.standalone";

        public static void AutoEnableVR()
        {
#if UNITY_EDITOR
            if (instance.autoEnableVR)
            {
                // Switch to native OpenVR support.
                var updated = false;

                if (!UnityEditor.PlayerSettings.virtualRealitySupported)
                {
                    UnityEditor.PlayerSettings.virtualRealitySupported = true;
                    updated = true;
                }

                UnityEditor.BuildTargetGroup currentTarget = UnityEditor.EditorUserBuildSettings.selectedBuildTargetGroup;

#if (UNITY_5_4 || UNITY_5_3 || UNITY_5_2 || UNITY_5_1 || UNITY_5_0)
                var devices = UnityEditorInternal.VR.VREditor.GetVREnabledDevices(currentTarget);
#else
			    var devices = UnityEditorInternal.VR.VREditor.GetVREnabledDevicesOnTargetGroup(currentTarget);
#endif
                var hasOpenVR = false;
                foreach (var device in devices)
                    if (device.ToLower() == "openvr")
                        hasOpenVR = true;


                if (!hasOpenVR)
                {
                    string[] newDevices;
                    if (updated)
                    {
                        newDevices = new string[] { openVRString };
                    }
                    else
                    {
                        newDevices = new string[devices.Length + 1];
                        for (int i = 0; i < devices.Length; i++)
                            newDevices[i] = devices[i];
                        newDevices[devices.Length] = openVRString;
                        updated = true;
                    }
#if (UNITY_5_6 || UNITY_5_4 || UNITY_5_3 || UNITY_5_2 || UNITY_5_1 || UNITY_5_0)
                    UnityEditorInternal.VR.VREditor.SetVREnabledDevices(currentTarget, newDevices);
#else
                    UnityEditorInternal.VR.VREditor.SetVREnabledDevicesOnTargetGroup(currentTarget, newDevices);
#endif
                }

#if UNITY_2018_1_OR_NEWER
                UnityEditor.PackageManager.Client.Add(openVRPackageString);
#endif

                if (updated)
                    Debug.Log("<b>[SteamVR]</b> Enabling VR in player settings.");
            }
#endif
                }
    }
}