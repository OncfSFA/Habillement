using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasse
{
    public class SGLP_HISTORIQUE_FONCTION_PERSONNEL
    {
        private int _HistoriqueFonction_Id	;
        private int _HistoriqueFonction_PersonnelId	;
        private int _HistoriqueFonction_FonctionId	;
        private DateTime _HistoriqueFonction_DateAffectation;
        public SGLP_HISTORIQUE_FONCTION_PERSONNEL() { }
        public int HistoriqueFonction_Id
        {
            get { return _HistoriqueFonction_Id; }
            set { this._HistoriqueFonction_Id = value; }
        }
        public int HistoriqueFonction_PersonnelId
        {
            get { return _HistoriqueFonction_PersonnelId; }
            set { this._HistoriqueFonction_PersonnelId = value; }
        }
        public int HistoriqueFonction_FonctionId
        {
            get { return _HistoriqueFonction_FonctionId; }
            set { this._HistoriqueFonction_FonctionId = value; }
        }
        public DateTime HistoriqueFonction_DateAffectation
        {
            get { return _HistoriqueFonction_DateAffectation; }
            set { this._HistoriqueFonction_DateAffectation = value; }
        }
       
    }
}
