﻿using System;
using UnityEngine;

namespace RealismOverhaul
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class StartupPopup : MonoBehaviour
    {
        public void Start()
        {
            bool hasPR = false;
            bool hasMRCS = false;
            foreach (var a in AssemblyLoader.loadedAssemblies)
            {
                if (a.name == "PersistentRotation")
                {
                    hasPR = true;
                }
                if (a.name == "MandatoryRCS")
                {
                    hasMRCS = true;
                }
            }

            

             if (hasPR || hasMRCS)
            {
                String message = "Realism Overhaul now contains its own, light, implementation of continuing vessel rotation during timewarp for when Principia is not installed. We've detected you have:\n\n";
                if (hasPR)
                    message += "* Persistent Rotation\n";
                if (hasMRCS)
                    message += "* MandatoryRCS\n";
                message += "\ninstalled. Please quit, remove " + ((hasPR && hasMRCS) ? "them" : "it") + ", and relaunch KSP.\n\nBut don't worry, RO's own implementation will be disabled until you do.";

                PopupDialog.SpawnPopupDialog(new Vector2(0, 0), new Vector2(0, 0), "ROStartupDialog", "Realism Overhaul", message, "OK", true, HighLogic.UISkin);
            }
        }
    }
}
