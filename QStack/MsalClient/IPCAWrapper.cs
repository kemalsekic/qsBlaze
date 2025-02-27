﻿using Microsoft.Identity.Client;

namespace QStack.MsalClient
{
    public interface IPCAWrapper
    {
        string[] Scopes { get; set; }
        Task<AuthenticationResult> AcquireTokenInteractiveAsync(string[] scopes);
        Task<AuthenticationResult> AcquireTokenSilentAsync(string[] scopes);
        Task SignOutAsync();
    }
}