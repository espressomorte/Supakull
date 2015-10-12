namespace Supakulltracker
{
    public interface ICredentialsProvider
    {
        CredentialInfo GetCredentialsInfo(string message);
    }
}
