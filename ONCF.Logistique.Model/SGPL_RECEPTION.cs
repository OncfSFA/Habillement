using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasse
{
    public class SGPL_RECEPTION
    {
        private int _Reception_Id	;
        private string _Reception_ArticleId;
        private int _Reception_OrdreLivraison_Id	;
        private int _Reception_QtePrevision	;
        private int _Reception_EstLivre	;
        private DateTime _Reception_Date	;


        public SGPL_RECEPTION() { }
        public int Reception_Id
        {
            get { return _Reception_Id; }
            set { this._Reception_Id = value; }
        }
        public string Reception_ArticleId
        {
            get { return _Reception_ArticleId; }
            set { this._Reception_ArticleId = value; }
        }
        public int Reception_OrdreLivraison_Id
        {
            get { return _Reception_OrdreLivraison_Id; }
            set { this._Reception_OrdreLivraison_Id = value; }
        }
        public int Reception_QtePrevision
        {
            get { return _Reception_QtePrevision; }
            set { this._Reception_QtePrevision = value; }
        }
        public int Reception_EstLivre
        {
            get { return _Reception_EstLivre; }
            set { this._Reception_EstLivre = value; }
        }
        public DateTime Reception_Date
        {
            get { return _Reception_Date; }
            set { this._Reception_Date = value; }
        }
    }
}
