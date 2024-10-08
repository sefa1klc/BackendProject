namespace Core.Utilities.Results;

public class ErrorResult : Result
{
    public ErrorResult() : base(false)
    {
    }

    public ErrorResult(string massage) : base(false)
    {
    }
}