using System.ComponentModel;
using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class ViewModel : MonoBehaviour, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private float healthScrollBarSize = 1;

    [Binding]
    public float HealthScrollBarSize
    {
        get => healthScrollBarSize;
        set 
        { 
            healthScrollBarSize = value;
            OnPropertyChanged("HealthScrollBarSize");
        }
    }

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
