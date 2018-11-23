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

        public bool Criar<T>() where T : new()
        {
            try
            {
                Db.DropTable<T>();
                Db.CreateTable<T>(CreateFlags.ImplicitPK);
                return true;
            }
            catch (SQLiteException ex)
            {
                Erro = ex.Message;
                return false;
            }
        }

        public bool Gravar<T>(T obj)
        {
            try
            {
                Db.Insert(obj);
                return true;
            }
            catch (SQLiteException ex)
            {
                Erro = ex.Message;
                return false;
            }
        }

        public T Ler<T>() where T : new()
        {
            try
            {
                return Db.Table<T>().First();            
            }
            catch (SQLiteException ex)
            {
                Erro = ex.Message;
                return default(T);
            }
        }

        public bool Apagar<T>(T obj)
        {
            try
            {
                //TODO: acertar isso aqui!!!
                Db.Delete(obj);                
                return true;
            }
            catch (SQLiteException ex)
            {
                Erro = ex.Message;
                return false;
            }
        }

        public bool Atualizar<T>(T obj)
        {
            try
            {
                //TODO: acertar isso aqui!!!
                Db.Update(obj);
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

        public bool GravaDados<T>(T obj) where T : new()
        {            
            bool ret = Conectar();            

            if (ret == true)
            {
                ret = Criar<T>();
            }

            if (ret == true)
            {
                ret = Gravar(obj);                
            }

            return ret;
        }

        public T LeDados<T>() where T : new()
        {
            bool ret = Conectar();

            if (ret == true)
            {
                return Ler<T>();
            }
            else { return default(T); }
        }
    }
}
