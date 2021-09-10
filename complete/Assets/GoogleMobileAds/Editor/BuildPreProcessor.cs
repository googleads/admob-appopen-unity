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

using System;
using UnityEditor;
using UnityEditor.Build;
#if UNITY_2018_1_OR_NEWER
using UnityEditor.Build.Reporting;
#endif
using UnityEditor.Callbacks;

using GoogleMobileAds.Editor;

#if UNITY_2018_1_OR_NEWER
public class BuildPreProcessor : IPreprocessBuildWithReport
#else
public class BuildPreProcessor : IPreprocessBuild
#endif
{

    public int callbackOrder { get { return 1; } }

#if UNITY_2018_1_OR_NEWER
    public void OnPreprocessBuild(BuildReport report)
#else
    public void OnPreprocessBuild(BuildTarget target, string path)
#endif
    {
        if (!AssetDatabase.IsValidFolder("Assets/GoogleMobileAds"))
        {
            AssetDatabase.CreateFolder("Assets", "GoogleMobileAds");
        }

        if (AssetDatabase.IsValidFolder("Packages/com.google.ads.mobile"))
        {
            AssetDatabase.CopyAsset("Packages/com.google.ads.mobile/GoogleMobileAds/link.xml", "Assets/GoogleMobileAds/link.xml");
        }
    }
}
