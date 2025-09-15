using System.Net.Http.Headers;
using Blazored.LocalStorage;

public class TokenAuthorizationMessageHandler : DelegatingHandler
{
    private readonly ILocalStorageService _storage;

    public TokenAuthorizationMessageHandler(ILocalStorageService storage)
    {
        _storage = storage;
        InnerHandler = new HttpClientHandler();
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        var token = await _storage.GetItemAsStringAsync("authToken");
        if (!string.IsNullOrWhiteSpace(token))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return await base.SendAsync(request, ct);
    }
}
