namespace TaskManager.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ContextTypes : DbContext
    {
        // Контекст настроен для использования строки подключения "ContextTypes" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "TaskManager.Model.ContextTypes" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "ContextTypes" 
        // в файле конфигурации приложения.
        public ContextTypes()
            : base("name=ContextTypes")
        {
        }

        public DbSet<SendEmailInformation> SendEmail { get; set; }
        public DbSet<DownLoadInformation> DownLoad { get; set; }
        public DbSet<MoveInformation> Moving { get; set; }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}