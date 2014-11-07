using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClasse
{
    public class SGPL_UTILISATEUR
    {
        private int _Id;
        private string _Login;
        private string _Password;
        private string _Email;
        private string _Matricule;
        private int _Module;
        private int _Etablissement;
        private int _Flag;
        private string _Nom;
        private string _Prenom;
        private int _Role;

        public SGPL_UTILISATEUR() { }

        public int Id
        {
            get { return _Id; }
            set { this._Id = value; }
        }
        public int Role
        {
            get { return _Role; }
            set { this._Role = value; }
        }
        public int Flag
        {
            get { return _Flag; }
            set { this._Flag = value; }
        }
        public string Nom
        {
            get { return _Nom; }
            set { this._Nom = value; }
        }
        public string Prenom
        {
            get { return _Prenom; }
            set { this._Prenom = value; }
        }
        public string Login
        {
            get { return _Login; }
            set { this._Login = value; }
        }
        public string Password
        {
            get { return _Password; }
            set { this._Password = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { this._Email = value; }
        }
        public int Module
        {
            get { return _Module; }
            set { this._Module = value; }
        }
        public string Matricule
        {
            get { return _Matricule; }
            set { this._Matricule = value; }
        }
        public int Etablissement 
        {
            get { return _Etablissement; }
            set { this._Etablissement = value; }
        }
    }
}
