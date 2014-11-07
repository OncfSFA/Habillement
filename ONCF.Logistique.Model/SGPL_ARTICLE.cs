using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasse
{
    public class SGPL_ARTICLE
    {
        private int _Article_Id;
      
        private string _Article_CodeEffet	;
        private string _Article_CodeArticle	;
        private string _LibelleEffet;
        private int _Article_ModuleId;

        public SGPL_ARTICLE ()   { }

        public int Article_Id
        {
            get { return _Article_Id; }
            set { this._Article_Id = value; }
        }
       
        public int Article_ModuleId
        {
            get { return _Article_ModuleId; }
            set { this._Article_ModuleId = value; }
        }
        public string LibelleEffet
        {
            get { return _LibelleEffet; }
            set { this._LibelleEffet = value; }
        }
        public string Article_CodeEffet
        {
            get { return _Article_CodeEffet; }
            set { this._Article_CodeEffet = value; }
        }
        public string Article_CodeArticle
        {
            get { return _Article_CodeArticle; }
            set { this._Article_CodeArticle = value; }
        }
    }
}
