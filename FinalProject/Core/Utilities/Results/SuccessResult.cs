namespace Core.Utilities.Results;

public class SuccessResult : Result
{
    public SuccessResult() : base(true)
    {
    }

    public SuccessResult(string massage) : base(true)
    {
    }
}