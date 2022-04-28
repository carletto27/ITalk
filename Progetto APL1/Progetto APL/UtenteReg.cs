using System;
using System.Collections.Generic;
using System.Text;

namespace Progetto_APL
{
    [Serializable]
    struct UtenteReg
    {
        public int id;
        public string nome;
        public string cognome;
        public string email;
        public string pass;
        public string ip;
    }
}
