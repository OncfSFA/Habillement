using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasse
{
    public class SGPL_DIRECTION
    {
        private int _Direction_Id	;
        private string _Direction_Libelle	;
        private int _Direction_PoleId	;
        private int _Direction_MagasinId;

        public SGPL_DIRECTION()  { }

        public int Direction_Id
        {
            get { return _Direction_Id; }
            set { this._Direction_Id = value; }
        }
        public string Direction_Libelle
        {
            get { return _Direction_Libelle; }
            set { this._Direction_Libelle = value; }
        }
        public int Direction_PoleId
        {
            get { return _Direction_PoleId; }
            set { this._Direction_PoleId = value; }
        }
        public int Direction_MagasinId
        {
            get { return _Direction_MagasinId; }
            set { this._Direction_MagasinId = value; }
        }
    }
}
