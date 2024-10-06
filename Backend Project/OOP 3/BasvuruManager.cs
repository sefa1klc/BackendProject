namespace OOP_3;

public class BasvuruManager
{
    //to calculate for one
    //Method injection
    public void BasvuruYap(IKrediManager kredi, List<ILoggerService> loggerService)
    {
        kredi.KrediHesapla();
        foreach (var logger in loggerService)
        {
            logger.Log();
        }
    }
    
    //to calculate for several
    public void KrediOnBilgilendirmeYap(List<IKrediManager> krediListesi)
    {
        foreach (var kredi in krediListesi)
        {
           kredi.KrediHesapla(); 
        }
    }
}