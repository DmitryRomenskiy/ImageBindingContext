using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace MauiApp4;

public partial class MainPage : ContentPage
{
	public class DataModel : ObservableObject
    {
		public int id { get; set; }
        public string NAME { get; set; }
        public bool IsImageVisible => ImageSource != null;
        public ImageSource ImageSource
        {
            get
            {
                if (id % 2 == 1)
                {
                    return ImageSource.FromFile("dotnet_bot.png");
                }
                else
                {
                    return null;
                }
            }
        }
    }
    public List<DataModel> viewmodel = null;

    public MainPage()
	{
        viewmodel = Enumerable.Range(0, 100).Select((i) => new DataModel() { id = i, NAME = string.Format("{0}", i) }).ToList();
        InitializeComponent();
		this.BindingContext = viewmodel;
	}

    int i = 0;
    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        this.grid.BindingContext = viewmodel[i];
        i++;
    }
}