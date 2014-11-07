using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasse
{
    public class SGPL_HISTO_STATUT_PREVISION
    {
        private int _HistoStatutPrevision_Id	;
        private int _HistoStatutPrevision_PrevisionId	;
        private int _HistoStatutPrevision_StatutPrevisionId	;
        private int _HistoStatutPrevision_UtilisateurId	;
        private DateTime _HistoStatutPrevision_Date	;
        private int _HistoStatutPrevision_Flag;

        public SGPL_HISTO_STATUT_PREVISION() { }

        public int HistoStatutPrevision_Id
        {
            get { return _HistoStatutPrevision_Id; }
            set { this._HistoStatutPrevision_Id = value; }
        }
        public int HistoStatutPrevision_PrevisionId
        {
            get { return _HistoStatutPrevision_PrevisionId; }
            set { this._HistoStatutPrevision_PrevisionId = value; }
        }
        public int HistoStatutPrevision_StatutPrevisionId
        {
            get { return _HistoStatutPrevision_StatutPrevisionId; }
            set { this._HistoStatutPrevision_StatutPrevisionId = value; }
        }
        public int HistoStatutPrevision_UtilisateurId
        {
            get { return _HistoStatutPrevision_UtilisateurId; }
            set { this._HistoStatutPrevision_UtilisateurId = value; }
        }
        public DateTime HistoStatutPrevision_Date
        {
            get { return _HistoStatutPrevision_Date; }
            set { this._HistoStatutPrevision_Date = value; }
        }
        public int HistoStatutPrevision_Flag
        {
            get { return _HistoStatutPrevision_Flag; }
            set { this._HistoStatutPrevision_Flag = value; }
        }
    }
}
