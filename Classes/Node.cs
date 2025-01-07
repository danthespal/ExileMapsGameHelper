using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOffsets.Natives;

namespace ExileMaps.Classes
{
    public class Node : INotifyPropertyChanged
    {
        private bool isUnlocked;
        private bool isVisible;
        private bool isHighlighted;
        private bool isActive;
        private bool isVisited;
        private (Vector2i, Vector2i, Vector2i, Vector2i, Vector2i) point;
        private Dictionary<Vector2i, Node> neighbors = new Dictionary<Vector2i, Node>();
        private Vector2i coordinate;
        private List<Biome> biomes = new List<Biome>();
        private List<Content> mapContent = new List<Content>();
        private bool isWaypoint;
        private float weight;
        private Dictionary<string, Effect> effects = new Dictionary<string, Effect>();
        private RectangleF cachedClientRect;
        private RectangleF cachedScreenRect;
        private bool FlaggedForRemoval { get; set; }

        public long Address { get; set; }
        public long ParentAddress { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsUnlocked
        {
            get => isUnlocked;
            set
            {
                if (isUnlocked != value)
                {
                    isUnlocked = value;
                    OnPropertyChanged(nameof(IsUnlocked));
                }
            }
        }

        public bool IsVisible
        {
            get => isVisible;
            set
            {
                if (isVisible != value)
                {
                    isVisible = value;
                    OnPropertyChanged(nameof(IsVisible));
                }
            }
        }

        public bool IsVisited
        {
            get => isVisited;
            set
            {
                if (isVisible != value)
                {
                    isVisible = value;
                    OnPropertyChanged(nameof(IsVisible));
                }
            }
        }

        public bool IsHighlighted
        {
            get => isHighlighted;
            set
            {
                if (isHighlighted != value)
                {
                    isHighlighted = value;
                    OnPropertyChanged(nameof(IsHighlighted));
                }
            }
        }

        public bool IsActive
        {
            get => isActive;
            set
            {
                if (isActive != value)
                {
                    isActive = value;
                    OnPropertyChanged(nameof(IsActive));
                }
            }
        }

        public (Vector2i, Vector2i, Vector2i, Vector2i, Vector2i) Point
        {
            get => point;
            set
            {
                if (point != value)
                {
                    point = value;
                    OnPropertyChanged(nameof(Point));
                }
            }
        }

        public Dictionary<Vector2i, Node> Neighbors
        {
            get => neighbors;
            set
            {
                if (neighbors != value)
                {
                    neighbors = value;
                    OnPropertyChanged(nameof(Neighbors));
                }
            }
        }

        public Vector2i Coordinate
        {
            get => coordinate;
            set
            {
                if (coordinate != value)
                {
                    coordinate = value;
                    OnPropertyChanged(nameof(Coordinate));
                }
            }
        }

        public List<Biome> Biomes
        {
            get => biomes;
            set
            {
                if (biomes != value)
                {
                    biomes = value;
                    OnPropertyChanged(nameof(Biomes));
                }
            }
        }

        public List<Content> MapContent
        {
            get => mapContent;
            set
            {
                if (mapContent != value)
                {
                    mapContent = value;
                    OnPropertyChanged(nameof(MapContent));
                }
            }
        }

        public bool IsWaypoint
        {
            get => isWaypoint;
            set
            {
                if (isWaypoint != value)
                {
                    isWaypoint = value;
                    OnPropertyChanged(nameof(IsWaypoint));
                }
            }
        }

        public Dictionary<string, Effect> Effects
        {
            get => effects;
            set
            {
                if (effects != value)
                {
                    effects = value;
                    OnPropertyChanged(nameof(Effects));
                }
            }
        }

        public float Weight
        {
            get => weight;
            set
            {
                if (weight != value)
                {
                    weight = value;
                    OnPropertyChanged(nameof(Weight));
                }
            }
        }

        public RectangleF CachedClientRect
        {
            get => cachedClientRect;
            protected set => cachedClientRect = value;
        }

        public RectangleF CachedScreenRect
        {
            get => cachedScreenRect;
            protected set => cachedScreenRect = value;
        }

        /*
         * TODO: rewrite for GameHelper
        public RectangleF GetClientRect()
        {
            try
            {
                if (!Main.Game.IngameState.IngameUi.WorldMap.AtlasPanel.IsVisible)
                    return cachedClientRect;

            }
            catch (Exception e)
            {
                cachedClientRect = RectangleF.Empty;
                return RectangleF.Empty;
            }

            AtlasNodeDescription thisNode = Main.Game.IngameState.IngameUi.WorldMap.AtlasPanel.Descriptions.FirstOrDefault(x => x.Address == Address);

            if (thisNode == null)
            {
                FlaggedForRemoval = true;
                return RectangleF.Empty;
            }

            cachedClientRect = thisNode.Element.GetClientRect();

            return cachedClientRect;
        }
        */

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Id: {Id}");
            sb.AppendLine($"Address: {Address}");
            sb.AppendLine($"IsVisited: {IsVisited}");
            sb.AppendLine($"IsUnlocked: {IsUnlocked}");
            sb.AppendLine($"IsVisible: {IsVisible}");
            sb.AppendLine($"IsHighlighted: {IsHighlighted}");
            sb.AppendLine($"IsActive: {IsActive}");
            sb.AppendLine($"IsWaypoint: {IsWaypoint}");
            sb.AppendLine($"Coordinate: {Coordinate}");
            sb.AppendLine($"Weight: {Weight}");
            sb.AppendLine($"Neighbors: {Point.Item1}, {Point.Item3}, {Point.Item4}, {Point.Item5}");
            sb.AppendLine($"Biomes: {string.Join(", ", Biomes.Where(x => x != null).Select(x => x.Name))}");
            sb.AppendLine($"Content: {string.Join(", ", MapContent.Select(x => x.Name))}");
            sb.AppendLine($"Effects: {string.Join(", ", Effects.Select(x => x.ToString()))}");

            return sb.ToString();
        }
    }
}
