using Newtonsoft.Json;
using MAUIGestorDeTareasDM.Models;
namespace MAUIGestorDeTareasDM;

public partial class MainPageDM : ContentPage
{
	public MainPageDM()
	{
		InitializeComponent();
	}

    private void Button_Clicked_DM(object sender, EventArgs e)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://localhost:7136/api/");
        var response = client.GetAsync("tareas").Result;
        if (response.IsSuccessStatusCode)
        {
            var tareasJson = response.Content.ReadAsStringAsync().Result;
            var tareasList = JsonConvert.DeserializeObject<List<DMTarea>>(tareasJson);
            listView.ItemsSource = tareasList;
        }
    }
}
