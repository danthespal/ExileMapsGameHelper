using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.Json.Serialization;
using System.Linq;

namespace ExileMaps.Classes
{
    public class Biome : INotifyPropertyChanged
    {
        private string name;
        private float weight = 1.0f;
        private Color color = Color.FromArgb(255, 255, 255, 255);
        private bool highlight = true;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(name));
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
                    OnPropertyChanged(nameof(weight));
                }
            }
        }

        [JsonConverter(typeof(JsonColorConverter))]
        public Color Color
        {
            get => color;
            set
            {
                if (color != value)
                {
                    color = value;
                    OnPropertyChanged(nameof(color));
                }
            }
        }

        public bool Highlight
        {
            get => highlight;
            set
            {
                if (highlight != value)
                {
                    highlight = value;
                    OnPropertyChanged(nameof(highlight));
                }
            }
        }
    }
}
