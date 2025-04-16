namespace System.Security.Principal
{
    public enum PrincipalPolicy
    {
        // Note: it's important that the default policy has the value 0.
        UnauthenticatedPrincipal = 0,
        NoPrincipal = 1,
        WindowsPrincipal = 2,
    }
}
