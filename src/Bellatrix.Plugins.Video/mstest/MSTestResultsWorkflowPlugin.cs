﻿// <copyright file="MSTestResultsWorkflowPlugin.cs" company="Automate The Planet Ltd.">
// Copyright 2020 Automate The Planet Ltd.
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// <author>Anton Angelov</author>
// <site>https://bellatrix.solutions/</site>
using Bellatrix.Plugins;
using Bellatrix.Plugins.Video.Plugins;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bellatrix.Results.MSTest;

public class MSTestResultsWorkflowPlugin : Plugin, IVideoPlugin
{
    public void SubscribeVideoPlugin(IVideoPluginProvider provider)
    {
        provider.VideoGeneratedEvent += VideoGenerated;
    }

    public void UnsubscribeVideoPlugin(IVideoPluginProvider provider)
    {
        provider.VideoGeneratedEvent -= VideoGenerated;
    }

    public void VideoGenerated(object sender, VideoPluginEventArgs args)
    {
        if (!string.IsNullOrEmpty(args.VideoPath))
        {
            try
            {
                var context = ServicesCollection.Current.Resolve<TestContext>();
                context?.AddResultFile(args.VideoPath);
            }
            catch
            {
                // ignore
            }
        }
    }
}