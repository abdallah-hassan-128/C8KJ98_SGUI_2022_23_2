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
        void UpdateCity(Fans fan);
        
        public Fans AddNewFan(Fans fan);
        public void DeleteFan(int id);
        Fans GetFan(int id);
        IEnumerable<Fans> GetAllFans();

        List<KeyValuePair<int, int>> BestFan();
        List<KeyValuePair<int, int>> WorstFan();

        int ReservationsNumber(int id);
    }
}
