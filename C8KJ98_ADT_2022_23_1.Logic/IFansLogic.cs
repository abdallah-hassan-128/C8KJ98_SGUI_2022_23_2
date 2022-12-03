using C8KJ98_ADT_2022_23_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C8KJ98_ADT_2022_23_1.Logic
{
    public interface IFansLogic
    {
        void UpdateCity(int id, string newCity);
        
        public Fans AddNewFan(Fans fan);
        public void DeleteFan(int id);
        Fans GetFan(int id);
        IEnumerable<Fans> GetAllFans();

        KeyValuePair<string, int> BestFan();
        KeyValuePair<string, int> WorstFan();

        int ReservationsNumber(int id);
    }
}
