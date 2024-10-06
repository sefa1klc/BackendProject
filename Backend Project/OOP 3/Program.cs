namespace OOP_3;

class Program
{
    public static void Main(string[] args)
    {
        IKrediManager konutKrediManager = new KonuKrediManager();
        IKrediManager ihtiyacKrediManager = new IhtiyaKrediManager();
        IKrediManager tasitKrediManager = new TasitKrediManager();
        BasvuruManager basvuruManager = new BasvuruManager();

        ILoggerService databaseLogger = new DatabaseLoggerService(); // databaseLogger == new DatabaseLoggerService(). what is important are the references
        List<IKrediManager> krediListesi = new List<IKrediManager>(){konutKrediManager, ihtiyacKrediManager, tasitKrediManager, new EsnafKrediManager()};
        
        //konutKrediManager.KrediHesapla();
        
        basvuruManager.BasvuruYap(new EsnafKrediManager(),
            new List<ILoggerService>
            {
                new DatabaseLoggerService(), 
                new SmsLoggerService()
            });
        //basvuruManager.KrediOnBilgilendirmeYap(krediListesi);
        
    }
}