using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_Supervisione_ITIS
{
    public interface IS7PlcService
    {
        ConnectionStates ConnectionState { get; }
        TimeSpan ScanTime { get; }
        event EventHandler ValuesRefreshed;

        bool TBX_segnalazione { get; }
        bool TBX_segnalazione_2 { get; }


        void Connect(string ipAddress, int rack, int slot);
        void Disconnect();

        Task Start_BT_1();
        Task Stop_BT_1();
        Task Start_BT_2();
        Task Stop_BT_2();

        void Connect();
    }
}
