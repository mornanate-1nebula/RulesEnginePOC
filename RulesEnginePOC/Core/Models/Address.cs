namespace RulesEnginePOC.Core.Models;

public class Address
{
    public int ID { get; set; }
    
    /// <summary>
    /// The street address of the user.
    /// </summary>
    public string Street { get; set; }

    /// <summary>
    /// The city of the user.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// The state or province of the user.
    /// </summary>
    public string State { get; set; }

    /// <summary>
    /// The postal code of the user.
    /// </summary>
    public string PostalCode { get; set; }

    /// <summary>
    /// The country of the user.
    /// </summary>
    public string Country { get; set; }
}