namespace ExileMaps
{
    using GameHelper.Plugin;
    using GameHelper.Utils;
    using ImGuiNET;
    using Newtonsoft.Json;
    using System.IO;

    public sealed class ExileMaps : PCore<ExileMapsSettings>
    {
        public override void DrawSettings()
        {
            if (ImGui.CollapsingHeader("Toggle Features"))
            {
                ImGui.Text("Range (from your current viewpoint) to process atlas nodes.");
                ImGui.DragInt("Atlas Range", ref base.Settings.AtlasRange, 100, 1500, 20000);
                ImGui.Checkbox("Use Atlas Range for Node Connections", ref base.Settings.UseAtlasRange);
                ImGuiHelper.ToolTip("Drawing node connections is performance intensive. By default it uses a range of 1000, but you can change it to use the Atlas range.");
                ImGui.Checkbox("Process Unlocked Map Nodes", ref base.Settings.ProcessUnlockedNodes);
                ImGui.Checkbox("Process Locked Map Nodes", ref base.Settings.ProcessLockedNodes);
                ImGui.Checkbox("Draw Connections for Visible Map Nodes", ref base.Settings.DrawVisibleNodeConnections);

                // Sync ProcessHiddenNodes with DrawHiddenNodeConnections
                bool processHiddenNodes = base.Settings.ProcessHiddenNodes;
                bool drawHiddenNodeConnections = base.Settings.DrawHiddenNodeConnections;

                ImGui.Checkbox("Process Hidden Map Nodes", ref processHiddenNodes);

                // Synchronize ProcessHiddenNodes with DrawHiddenNodeConnections state
                if (processHiddenNodes != base.Settings.ProcessHiddenNodes)
                {
                    base.Settings.ProcessHiddenNodes = processHiddenNodes;
                }

                if (!base.Settings.ProcessHiddenNodes)
                {
                    base.Settings.DrawHiddenNodeConnections = false;
                }
                else
                {
                    ImGui.Checkbox("Draw Connections for Hidden Map Nodes", ref drawHiddenNodeConnections);

                    if (drawHiddenNodeConnections != base.Settings.DrawHiddenNodeConnections)
                    {
                        base.Settings.DrawHiddenNodeConnections = drawHiddenNodeConnections;
                    }
                }

                // Sync WaypointsUseAtlasRange and DrawLineLabels with DrawLines
                bool drawLines = base.Settings.DrawLines;
                bool waypointsUseAtlasRange = base.Settings.WaypointsUseAtlasRange;
                bool drawLineLabels = base.Settings.DrawLineLabels;

                ImGui.Checkbox("Draw Waypoint Lines.", ref drawLines);
                ImGuiHelper.ToolTip("Draw a line from your current screen position to selected map nodes.");

                // Synchronize DrawLines state
                if (drawLines != base.Settings.DrawLines)
                {
                    base.Settings.DrawLines = drawLines;
                }

                // Ensure WaypointsUseAtlasRange and DrawLineLabels are synchronized with DrawLines
                if (!base.Settings.DrawLines)
                {
                    base.Settings.WaypointsUseAtlasRange = false;
                    base.Settings.DrawLineLabels = false;
                }
                else
                {
                    ImGui.Checkbox("Limit Waypoints to Atlas range", ref waypointsUseAtlasRange);
                    ImGuiHelper.ToolTip("If enabled, Waypoints will only be drawn if they are within your Atlas range, otherwise all waypoints will be drawn. Disabling this may cause performance issues.");

                    ImGui.Checkbox("Draw Labels on Waypoint Lines", ref drawLineLabels);
                    ImGuiHelper.ToolTip("Draw the name and distance to the node on the indicator lines, if enabled");

                    // Synchronize WaypointsUseAtlasRange and DrawLineLabels states
                    if (waypointsUseAtlasRange != base.Settings.WaypointsUseAtlasRange)
                    {
                        base.Settings.WaypointsUseAtlasRange = waypointsUseAtlasRange;
                    }

                    if (drawLineLabels != base.Settings.DrawLineLabels)
                    {
                        base.Settings.DrawLineLabels = drawLineLabels;
                    }
                }
            }

            if (ImGui.CollapsingHeader("Map Node Labelling"))
            {
                ImGui.Checkbox("Draw Labels on Nodes", ref base.Settings.DrawNodeLabels);
                ImGuiHelper.ToolTip("Draw the name of map nodes on top of the node.");
                ImGui.Checkbox("Label Unlocked Map Nodes", ref base.Settings.LabelUnlockedNodes);
                ImGui.Checkbox("Label Locked Map Nodes", ref base.Settings.LabelLockedNodes);
                ImGui.Checkbox("Label Hidden Map Nodes", ref base.Settings.LabelHiddenNodes);
                ImGui.Checkbox("Highlight Map Names", ref base.Settings.NameHighlighting);
                ImGuiHelper.ToolTip("Use custom text and background colors for selected map types.");
            }

            if (ImGui.CollapsingHeader("Graphics, Colors, and Performance Settings"))
            {
                ImGui.TextWrapped("Throttle the render to only re-render every Nth thick - can improve performance.");
                ImGui.SliderInt("Render every N Ticks", ref base.Settings.RenderNTicks, 2, 20);
                ImGui.TextWrapped("Throttle the map cache refresh rate. Default is 5 seconds");
                ImGui.SliderInt("Map Cache Refresh Rate", ref base.Settings.MapCacheRefreshRate, 5, 60);
                ImGui.ColorEdit4("Font Color", ref base.Settings.FontColor);
                ImGuiHelper.ToolTip("Color of text on the Atlas");
                ImGui.ColorEdit4("Background Color", ref base.Settings.BackgroundColor);
                ImGuiHelper.ToolTip("Color of the background on the Atlas");
                ImGui.SliderFloat("Distance Marker Scale", ref base.Settings.LabelInterpolationScale, .2f, 1f);
                ImGuiHelper.ToolTip("Interpolation factor for distance markers on lines");
                ImGui.ColorEdit4("Line Color", ref base.Settings.LineColor);
                ImGuiHelper.ToolTip("Color of the map connection lines and waypoint lines when no map specific color is set");
            }

            if (ImGui.CollapsingHeader("Map Settings"))
            {

            }

            if (ImGui.CollapsingHeader("Biome Settings"))
            {

            }

            if (ImGui.CollapsingHeader("Content Settings"))
            {

            }

            if (ImGui.CollapsingHeader("Atlas Mod Settings"))
            {

            }
        }

        public override void DrawUI()
        {
            
        }

        public override void OnDisable()
        {
            
        }

        public override void SaveSettings()
        {
            
        }

        public override void OnEnable(bool isGameOpened)
        {
            
        }
    }
}
