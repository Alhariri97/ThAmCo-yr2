namespace ThAmCo.Events.Models;


/// <summary>
/// This an error model will print the error message passed and the status code if passed
/// </summary>
public class ErrorViewModel
{
    /// <summary>
    /// first constroctor for a message only
    /// </summary>
    /// <param name="error"></param>
    public ErrorViewModel(string error)
    {
        ErrorMsg = error;
    }
    /// <summary>
    /// Second constroctor for a message and status code!
    /// </summary>
    /// <param name="error"></param>
    /// <param name="statuscode"></param>
    public ErrorViewModel(string error, int statuscode)
    {
        ErrorMsg = error;
        Statuscode = statuscode; 
    }
    public int Statuscode { get; set; } = 0;
    public string ErrorMsg { get; set; }

}