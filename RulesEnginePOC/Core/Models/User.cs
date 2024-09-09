namespace RulesEnginePOC.Core.Models;

public class User
{
    
    public int ID { get; set; }
    
    /// <summary>
    /// The first name of the user.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// The last name of the user.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// The email address of the user.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// The addresses of the user.
    /// </summary>
    public List<Address> Addresses { get; set; }

    /// <summary>
    /// The phone number of the user.
    /// </summary>
    public string PhoneNumber { get; set; }

}