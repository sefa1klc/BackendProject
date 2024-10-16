using System.Reflection.Metadata.Ecma335;

namespace Business.Constans;

public static class Messages
{
    public static string CategoryLimitExceeded = "Category limit exceeded";
    public static string ProductNameAlreadyExist = "Product name already exist";
    public static string ProductAdded = "Product added";
    public static string ProductUpdated = "Product updated";
    public static string ProductDeleted = "Product deleted";
    public static string ProductNameInvalid = "Product name is invalid";
    public static string ProductNameTooShort = "Product name must be longer than 2";
    public static string ProductListed = "Product was listed";
    public static string MaintenanceTime = "The system is in maintenance";
    public static string ProductCountOfCategory = "There can be at most 10 products in a category";
}