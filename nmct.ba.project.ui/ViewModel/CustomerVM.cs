using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using nmct.ba.project.model.Model;

namespace nmct.ba.project.ui.ViewModel
{
    class CustomerVM : ObservableObject, IPage
    {
        public CustomerVM()
        {
            if (ApplicationVM.token != null)
            {
                GetCustomers();
            }
        }

        private ObservableCollection<Customers> _customers;
        public ObservableCollection<Customers> Customers
        {
            get { return _customers; }
            set { _customers = value; OnPropertyChanged("Customers"); }
        }

        private async void GetCustomers()
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                HttpResponseMessage response = await client.GetAsync("http://localhost:31929/api/customer");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Customers = JsonConvert.DeserializeObject<ObservableCollection<Customers>>(json);
                }
            }
        }

        public string Name
        {
            get { return "Customer page"; }
        }
    }
}
