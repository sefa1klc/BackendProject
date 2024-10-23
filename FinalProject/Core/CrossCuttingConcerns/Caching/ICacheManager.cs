namespace Core.CrossCuttingConcerns.Caching;

public interface ICacheManager
{
    T Get<T>(string key);
    void Add(string key, object value, int cacheTime);
    bool IsAdd(string key); // is there in memory check
    void Remove(string key);
    void RemoveByPattern(string pattern);
}