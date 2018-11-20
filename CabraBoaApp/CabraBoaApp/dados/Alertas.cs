using SQLite;
using Xamarin.Forms.Internals;

namespace CabraBoaApp.dados
{
    class Alertas
    {
        public string Habilitar { get; set; }
        public string Notificacoes { get; set; }
        public string Visual { get; set; }
        public string Sonoro { get; set; }
        public string Email { get; set; }       
    }

    class DbAlertas
    {
        private string DatabasePath { get; set; }
        private SQLiteConnection Db { get; set; }
        public string Erro { get; set; }

        public DbAlertas()
        {
            // Get an absolute path to the database file = .Personal .MyDocuments
            DatabasePath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "CabraBoa.db");
            //DatabasePath = "C:\\cabraboa\\CabraBoa.db";
            Erro = "";            
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
                Db.CreateTable<Alertas>();
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

        public void Ler()
        {
        }

        public void Apagar()
        {
        }       
    }
}
