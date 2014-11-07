using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasse
{
    public class SGPL_KIT_HABILLEMENT
    {
        private int _KitHabillement_Id	;
        private string _KitHabillement_Libelle;
        private string _KitHabillement_Sexe;
        private int _KitHabillement_ModuleId;

        public SGPL_KIT_HABILLEMENT()   { }

        public int KitHabillement_Id
        {
            get { return _KitHabillement_Id; }
            set { this._KitHabillement_Id = value; }
        }
        public string KitHabillement_Libelle
        {
            get { return _KitHabillement_Libelle; }
            set { this._KitHabillement_Libelle = value; }
        }
        public string KitHabillement_Sexe
        {
            get { return _KitHabillement_Sexe; }
            set { this._KitHabillement_Sexe = value; }
        }
        public int KitHabillement_ModuleId
        {
            get { return _KitHabillement_ModuleId; }
            set { this._KitHabillement_ModuleId = value; }
        }
    
    }
}
