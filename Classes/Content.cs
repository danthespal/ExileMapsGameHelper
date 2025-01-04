using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExileMaps.Classes
{
    public class Content : INotifyPropertyChanged
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

        public override string ToString()
        {
            return Name;
        }

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
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

        [JsonConverter(typeof(JsonColorConverter))]
        public Color Color
        {
            get => color;
            set
            {
                if (color != value)
                {
                    color = value;
                    OnPropertyChanged(nameof(Color));
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
                    OnPropertyChanged(nameof(Highlight));
                }
            }
        }
    }
}
