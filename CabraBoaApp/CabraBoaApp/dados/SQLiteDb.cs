using SQLite;
using Xamarin.Forms.Internals;

namespace CabraBoaApp.dados
{
    class SQLiteDb
    {
        private string DatabasePath { get; set; }
        private SQLiteConnection Db { get; set; }
        public string Erro { get; set; }

        public SQLiteDb()
        {
            // Get an absolute path to the database file = .Personal .MyDocuments
            //DatabasePath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "CabraBoa.db");            
            DatabasePath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "CabraBoa.db");
            
            Erro = "Sem Erros!";
        }

        public string GetPath()
        {
            return DatabasePath;
        }

        public bool CheckDb()
        {
            return System.IO.File.Exists(DatabasePath);
        }

        public bool Conectar()
        {
            try
            {
                Db = new SQLiteConnection(DatabasePath);
                return true;
            }
            catch (SQLiteException ex)
            {
                Erro = ex.Message;
                return false;
            }
        }

        public bool Criar()
        {
            try
            {
                Db.DropTable<Alertas>();
                Db.CreateTable<Alertas>(CreateFlags.ImplicitPK);
                return true;
            }
            catch (SQLiteException ex)
            {
                Erro = ex.Message;
                return false;
            }
        }

        public bool Gravar(Alertas alertas)
        {
            try
            {
                Db.Insert(alertas);
                return true;
            }
            catch (SQLiteException ex)
            {
                Erro = ex.Message;
                return false;
            }
        }

        public Alertas Ler()
        {
            try
            {
                return Db.Table<Alertas>().First();            
            }
            catch (SQLiteException ex)
            {
                Erro = ex.Message;
                return null;
            }
        }

        public bool Apagar(Alertas alertas)
        {
            try
            {
                Db.Delete(alertas);                
                return true;
            }
            catch (SQLiteException ex)
            {
                Erro = ex.Message;
                return false;
            }
        }

        public bool Atualizar(Alertas alertas)
        {
            try
            {
                //TODO: acertar isso aqui!!!
                Db.Update(alertas);
                return true;
            }
            catch (SQLiteException ex)
            {
                Erro = ex.Message;
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
