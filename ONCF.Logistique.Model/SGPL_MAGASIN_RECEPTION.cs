using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasse
{
    public class SGPL_MAGASIN_RECEPTION
    {
        private int _MagasinReception_MagasinId ;
		private int _MagasinReception_QtePrevision ;
		private int _MagasinReception_QteRecue ;
        private int _MagasinReception_ReceptionId;

        public SGPL_MAGASIN_RECEPTION() { }

        public int MagasinReception_MagasinId
        {
            get { return _MagasinReception_MagasinId; }
            set { this._MagasinReception_MagasinId = value; }
        }
        public int MagasinReception_QtePrevision
        {
            get { return _MagasinReception_QtePrevision; }
            set { this._MagasinReception_QtePrevision = value; }
        }
        public int MagasinReception_QteRecue
        {
            get { return _MagasinReception_QteRecue; }
            set { this._MagasinReception_QteRecue = value; }
        }
        public int MagasinReception_ReceptionId
        {
            get { return _MagasinReception_ReceptionId; }
            set { this._MagasinReception_ReceptionId = value; }
        }
    }
}
