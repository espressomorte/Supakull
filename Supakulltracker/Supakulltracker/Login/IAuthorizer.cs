namespace Supakulltracker
{
    public interface IAuthorizer
    {
        AuthorizationResult Authorize(CredentialInfo credentiolInfo);
    }
}