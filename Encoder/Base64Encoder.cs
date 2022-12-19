namespace JrAPI.Encoder;

public static class Base64Encoder
{
    public static string Get(string buffer)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(buffer);
        return System.Convert.ToBase64String(plainTextBytes);
    }
}