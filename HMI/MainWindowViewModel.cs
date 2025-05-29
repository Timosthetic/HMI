using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace HMI
{
   public partial  class MainWindowViewModel: ObservableObject
    {
        [ObservableProperty] private int _angle = 0;
        List<string> products = new List<string>()
        {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",

        };
        [ObservableProperty] private ObservableCollection<string> _upLine = new ObservableCollection<string>();
        [ObservableProperty] private ObservableCollection<string> _downLine = new();
        [ObservableProperty] private string? _m01;
        [ObservableProperty] private string? _m02;
        [ObservableProperty] private string? _m03;
        [ObservableProperty] private string? _m04;
        private int currentIndex = 0; // 用于循环覆盖 M01~M04

        void Next()
        {
            if (Angle == 0)
            {
                Angle = 1;
            }
            else
            {
                switch (Angle)
                {
                    case 1:
                        Angle = 2;
                        break;
                    case 2:
                        Angle = 3;
                        break;
                    case 3:
                        Angle = 4;
                        break;
                    case 4:
                        Angle = 1;
                        break;
                    default:
                        break;
                }
            }
        }




        [RelayCommand]
        void Feeding()
        {
            if (products?.Count > 0)
            {
                var pro = products.FirstOrDefault();

                // 如果 M01~M04 都已填充，则循环覆盖
                switch (currentIndex % 4)
                {
                    case 0:

                        M01 = pro;
                        break;
                    case 1:

                        M02 = pro;
                        break;
                    case 2:

                        M03 = pro;
                        break;
                    case 3:

                        M04 = pro;
                        break;
                }
                currentIndex++;
                products.Remove(pro);
                Next();
            }

        }


        partial void OnM01Changed(string oldValue, string newValue)
        {
            if (string.IsNullOrEmpty(oldValue))
            {
                UpLine.Add(newValue);
            }
            else if (oldValue != newValue)
            {
                DownLine.Add(oldValue);
                UpLine.Add(newValue);
            }
        }

        partial void OnM02Changed(string oldValue, string newValue)
        {
            if (string.IsNullOrEmpty(oldValue))
            {
                UpLine.Add(newValue);
            }
            else if (oldValue != newValue)
            {
                DownLine.Add(oldValue);
                UpLine.Add(newValue);
            }
        }
        partial void OnM03Changed(string oldValue, string newValue)
        {
            if (string.IsNullOrEmpty(oldValue))
            {
                UpLine.Add(newValue);
            }
            else if (oldValue != newValue)
            {
                DownLine.Add(oldValue);
                UpLine.Add(newValue);
            }
        }

        partial void OnM04Changed(string oldValue, string newValue)
        {
            if (string.IsNullOrEmpty(oldValue))
            {
                UpLine.Add(newValue);
            }
            else if (oldValue != newValue)
            {
                DownLine.Add(oldValue);
                UpLine.Add(newValue);
            }
        }
    }
}
