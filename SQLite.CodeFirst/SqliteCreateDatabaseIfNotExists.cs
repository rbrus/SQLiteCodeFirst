using System.Data.Entity;
using System.IO;

namespace SQLite.CodeFirst
{
    public class SqliteCreateDatabaseIfNotExists<TContext> : SqliteInitializerBase<TContext>
        where TContext : DbContext
    {
        public SqliteCreateDatabaseIfNotExists(DbModelBuilder modelBuilder)
            : base(modelBuilder) { }

        public override void InitializeDatabase(TContext context)
        {
            string databseFilePath = GetDatabasePathFromContext(context);

            bool dbExists = File.Exists(databseFilePath);
            var dbFileInfo = new FileInfo(databseFilePath);
            long dbFileSize = dbFileInfo.Length;

            if (dbExists)
            {
                if(dbFileSize != 0)
                    return;
            }

            base.InitializeDatabase(context);
        }
    }
}
