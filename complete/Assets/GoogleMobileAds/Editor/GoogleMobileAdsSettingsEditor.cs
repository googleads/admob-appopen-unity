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

    [InitializeOnLoad]
    [CustomEditor(typeof(GoogleMobileAdsSettings))]
    public class GoogleMobileAdsSettingsEditor : UnityEditor.Editor
    {
        [MenuItem("Assets/Google Mobile Ads/Settings...")]
        public static void OpenInspector()
        {
            Selection.activeObject = GoogleMobileAdsSettings.Instance;
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("Google Mobile Ads App ID", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;

            GoogleMobileAdsSettings.Instance.GoogleMobileAdsAndroidAppId =
                    EditorGUILayout.TextField("Android",
                            GoogleMobileAdsSettings.Instance.GoogleMobileAdsAndroidAppId);

            GoogleMobileAdsSettings.Instance.GoogleMobileAdsIOSAppId =
                    EditorGUILayout.TextField("iOS",
                            GoogleMobileAdsSettings.Instance.GoogleMobileAdsIOSAppId);

            EditorGUILayout.HelpBox(
                    "Google Mobile  Ads App ID will look similar to this sample ID: ca-app-pub-3940256099942544~3347511713",
                    MessageType.Info);

            EditorGUI.indentLevel--;
            EditorGUILayout.Separator();

            EditorGUILayout.LabelField("AdMob-specific settings", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;

            EditorGUI.BeginChangeCheck();

            GoogleMobileAdsSettings.Instance.DelayAppMeasurementInit =
                    EditorGUILayout.Toggle(new GUIContent("Delay app measurement"),
                    GoogleMobileAdsSettings.Instance.DelayAppMeasurementInit);

            if (GoogleMobileAdsSettings.Instance.DelayAppMeasurementInit) {
                EditorGUILayout.HelpBox(
                        "Delays app measurement until you explicitly initialize the Mobile Ads SDK or load an ad.",
                        MessageType.Info);
            }

            EditorGUI.indentLevel--;
            EditorGUILayout.Separator();

            if (GUI.changed)
            {
                OnSettingsChanged();
            }
        }

        private void OnSettingsChanged()
        {
            EditorUtility.SetDirty((GoogleMobileAdsSettings) target);
            GoogleMobileAdsSettings.Instance.WriteSettingsToFile();
        }
    }
}
