namespace Supakulltracker
{
    public interface IAuthorizer
    {
        bool Authorize(CredentialInfo credentiolInfo);
    }
}