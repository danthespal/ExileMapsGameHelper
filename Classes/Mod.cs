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
    public class Mod : INotifyPropertyChanged
    {
        private string modID;
        private string description = "";
        private float weight;
        private Color color = Color.FromArgb(255, 255, 255, 255);
        private float minValue1;
        private float maxValue1;
        private string name;
        private float minValue2;
        private float maxValue2;
        private string stat2;
        private bool showOnMap = true;

        private string requiredContent = "";

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return (minValue1 != maxValue1) ? description.Replace("$", $"{minValue1.ToString()}-{maxValue1.ToString()}") : description.Replace("$", minValue1.ToString());
        }

        public string ModID
        {
            get => modID;
            set
            {
                if (modID != value)
                {
                    modID = value;
                    OnPropertyChanged(nameof(ModID));
                }
            }
        }

        public string Description
        {
            get => description;
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public string RequiredContent
        {
            get => requiredContent;
            set
            {
                if (requiredContent != value)
                {
                    requiredContent = value;
                    OnPropertyChanged(nameof(RequiredContent));
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

        public float MinValue1
        {
            get => minValue1;
            set
            {
                if (minValue1 != value)
                {
                    minValue1 = value;
                    OnPropertyChanged(nameof(MinValue1));
                }
            }
        }

        public float MaxValue1
        {
            get => maxValue1;
            set
            {
                if (maxValue1 != value)
                {
                    maxValue1 = value;
                    OnPropertyChanged(nameof(MaxValue1));
                }
            }
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

        public float MinValue2
        {
            get => minValue2;
            set
            {
                if (minValue2 != value)
                {
                    minValue2 = value;
                    OnPropertyChanged(nameof(MinValue2));
                }
            }
        }

        public float MaxValue2
        {
            get => maxValue2;
            set
            {
                if (maxValue2 != value)
                {
                    maxValue2 = value;
                    OnPropertyChanged(nameof(MaxValue2));
                }
            }
        }

        public string Stat2
        {
            get => stat2;
            set
            {
                if (stat2 != value)
                {
                    stat2 = value;
                    OnPropertyChanged(nameof(Stat2));
                }
            }
        }

        public bool ShowOnMap
        {
            get => showOnMap;
            set
            {
                if (showOnMap != value)
                {
                    showOnMap = value;
                    OnPropertyChanged(nameof(ShowOnMap));
                }
            }
        }
    }
}
