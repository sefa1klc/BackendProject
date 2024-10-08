namespace Core.Utilities.Results;
//for base void functions  
public interface IResult
{
    public bool Success{ get;}
    public string Massage { get; }
}