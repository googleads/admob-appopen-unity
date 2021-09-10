// Copyright 2021 Google LLC
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEditor;
using UnityEngine;

namespace GoogleMobileAds.Editor
{

    internal class GoogleMobileAdsSettings : ScriptableObject
    {
        private const string MobileAdsSettingsDir = "Assets/GoogleMobileAds";

        private const string MobileAdsSettingsResDir = "Assets/GoogleMobileAds/Resources";

        private const string MobileAdsSettingsFile =
            "Assets/GoogleMobileAds/Resources/GoogleMobileAdsSettings.asset";

        private static GoogleMobileAdsSettings instance;

        [SerializeField]
        private string adMobAndroidAppId = string.Empty;

        [SerializeField]
        private string adMobIOSAppId = string.Empty;

        [SerializeField]
        private bool delayAppMeasurementInit = false;

        public string GoogleMobileAdsAndroidAppId
        {
            get
            {
                return Instance.adMobAndroidAppId;
            }

            set
            {
                Instance.adMobAndroidAppId = value;
            }
        }

        public string GoogleMobileAdsIOSAppId
        {
            get
            {
                return Instance.adMobIOSAppId;
            }

            set
            {
                Instance.adMobIOSAppId = value;
            }
        }

        public bool DelayAppMeasurementInit
        {
            get
            {
                return Instance.delayAppMeasurementInit;
            }

            set
            {
                Instance.delayAppMeasurementInit = value;
            }
        }

        public static GoogleMobileAdsSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    if (!AssetDatabase.IsValidFolder(MobileAdsSettingsDir))
                    {
                        AssetDatabase.CreateFolder("Assets", "GoogleMobileAds");
                    }

                    if (!AssetDatabase.IsValidFolder(MobileAdsSettingsResDir))
                    {
                        AssetDatabase.CreateFolder(MobileAdsSettingsDir, "Resources");
                    }

                    instance = (GoogleMobileAdsSettings) AssetDatabase.LoadAssetAtPath(
                        MobileAdsSettingsFile, typeof(GoogleMobileAdsSettings));

                    if (instance == null)
                    {
                        instance = ScriptableObject.CreateInstance<GoogleMobileAdsSettings>();
                        AssetDatabase.CreateAsset(instance, MobileAdsSettingsFile);
                    }
                }
                return instance;
            }
        }

        internal void WriteSettingsToFile()
        {
            AssetDatabase.SaveAssets();
        }
    }
}
