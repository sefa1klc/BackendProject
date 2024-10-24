namespace Core.CrossCuttingConcerns.Caching;

public interface ICacheManager
{
    T Get<T>(string key);
    void Add(string key, object value, int cacheTime);
    bool IsAdd(string key); //check that is there in memory 
    void Remove(string key);
    void RemoveByPattern(string pattern);
}