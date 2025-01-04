using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using GameHelper.Plugin;

namespace ExileMaps;  

public sealed class ExileMapsSettings : IPSettings
{
    // FeatureSettings
    public int AtlasRange = 1500;
    public bool UseAtlasRange = false;
    public bool ProcessUnlockedNodes = true;
    public bool ProcessLockedNodes = true;
    public bool DrawVisibleNodeConnections = true;
    public bool ProcessHiddenNodes = true;
    public bool DrawHiddenNodeConnections = true;
    public bool DrawLines = true;
    public bool WaypointsUseAtlasRange = false;
    public bool DrawLineLabels = true;

    // LabelSettings
    public bool DrawNodeLabels = true;
    public bool LabelUnlockedNodes = true;
    public bool LabelLockedNodes = true;
    public bool LabelHiddenNodes = true;
    public bool NameHighlighting = true;

    // GraphicsSettings
    public int RenderNTicks = 2;
    public int MapCacheRefreshRate = 5;
    public Vector4 FontColor = new Vector4(1f, 1f, 1f, .5f);
    public Vector4 BackgroundColor = new Vector4(.667f, 0f, 0f, 0f);
    public float LabelInterpolationScale = 0.2f;
    public Vector4 LineColor = new Vector4(.784f, 1f, .871f, .871f);
}
