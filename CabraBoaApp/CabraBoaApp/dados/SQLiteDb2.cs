using SQLite;
using Xamarin.Forms.Internals;

namespace CabraBoaApp.dados
{
    class SQLiteDb2
    {
        private string DatabasePath { get; set; }
        private SQLiteConnection Db { get; set; }
        public string Erro { get; set; }

        public SQLiteDb2()
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
    }
}
