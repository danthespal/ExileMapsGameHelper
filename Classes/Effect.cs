﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOffsets.Natives;

namespace ExileMaps.Classes
{
    public class Effect : INotifyPropertyChanged
    {
        private string name;
        private string description;
        private bool showOnMap;
        private int value1;
        private int value2;
        private long id;
        private float weight;
        private List<Vector2i> sources = new List<Vector2i>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return Description.Replace("$", Value1.ToString());
        }

        public string GetSources() => string.Join(", ", Sources.Select(x => $"({x.X}, {x.Y})"));

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

        public int Value1
        {
            get => value1;
            set
            {
                if (value1 != value)
                {
                    value1 = value;
                    OnPropertyChanged(nameof(Value1));
                }
            }
        }

        public int Value2
        {
            get => value2;
            set
            {
                if (value2 != value)
                {
                    value2 = value;
                    OnPropertyChanged(nameof(Value2));
                }
            }
        }

        public long ID
        {
            get => id;
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(ID));
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

        public List<Vector2i> Sources
        {
            get => sources;
            set
            {
                if (sources != value)
                {
                    sources = value;
                    OnPropertyChanged(nameof(Sources));
                }
            }
        }
    }
}
