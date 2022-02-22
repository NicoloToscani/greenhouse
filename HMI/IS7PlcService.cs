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
        

        void Connect(string ipAddress, int rack, int slot);
        void Disconnect();

        Task Start_BT_1();
        Task Stop_BT_1();

        void Connect();
    }
}
