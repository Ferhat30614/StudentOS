using System.Net.Http.Json;

public class AuthService
{
    private readonly HttpClient _http;
    private readonly JwtAuthStateProvider _auth;

    public AuthService(HttpClient http, JwtAuthStateProvider auth)
    {
        _http = http;
        _auth = auth;
    }

    public async Task<(bool ok, string? error)> LoginAsync(string email, string password)
    {
        var res = await _http.PostAsJsonAsync("api/auth/login", new { email, password });
        if (!res.IsSuccessStatusCode)
            return (false, "Email veya şifre hatalı.");

        var obj = await res.Content.ReadFromJsonAsync<LoginResponse>();
        if (obj is null || string.IsNullOrWhiteSpace(obj.token))
            return (false, "Token alınamadı.");

        await _auth.MarkUserAsAuthenticatedAsync(obj.token);
        return (true, null);
    }

    public async Task<(bool ok, string? error, string? userId)> RegisterAsync(string fullName, string email, string password, string role)
    {
        var res = await _http.PostAsJsonAsync("api/auth/register", new { fullName, email, password, role });
        if (!res.IsSuccessStatusCode)
        {
            var err = await res.Content.ReadAsStringAsync();
            return (false, err, null);
        }
        var obj = await res.Content.ReadFromJsonAsync<RegisterResponse>();
        return (true, null, obj?.userId);
    }

    public async Task LogoutAsync() => await _auth.LogoutAsync();

    private record LoginResponse(string token, string role);
    private record RegisterResponse(bool ok, string? userId);
}
