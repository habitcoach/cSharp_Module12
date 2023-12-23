


[AttributeUsage(AttributeTargets.All)]
public class AuthorAttribute : Attribute

{

    public string Email { get; }

    public int Revision { get; }

    public AuthorAttribute(string email, int revision)

    {

        Email = email;

        Revision = revision;

    }

}