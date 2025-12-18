public class CalculadoraAPI {
    // API
    private static string API = "https://intranet.pekus.com.br/calcapi/api/Calculadora";
    private static string API_KEY = "GUTV5945";

    // MOCK API
    private static bool USE_MOCK = false;
    private static string TEMP_API_GET = "https://apifastmock.com/mock/da2revIqlDbyEHTUPoq1ZVKCZqMnYOzpHb3NIKfjxRuxpV3MeCUuNKTrJ9vhiIqaChmjuAfGlwXVUez4beKxk4OCYST9RFpELmdB084ZRoFKASjPhNtaikHLgA5UihRf7I7pKGIso8dgYMP8TBCYgYzWtODbTRWrveBTQhZjMTndv6tfR00LqBbQeABbP2Ntrg_sVqu1XMHaRIW1Sv3n7MLaKwA";
    private static string TEMP_API_POST = "https://apifastmock.com/mock/9KYwKM6cFbyyJY6PiGIBBvT-jh7IFg0Qgo_9WD-6mF-_CGginl6CWyFDTJl7RolmOSQsu2uYNlfKwAJg0uUUaWbAztnkFGUSiBSl91ObMfmA";
    private static string TEMP_API_DELETE = "https://apifastmock.com/mock/wYd6fkiUZiqY7M1rzbiJCIYDu3W5WyUTcIUnZDwpaUATLS6BsiTa1zLFX5wi6C3vty6ZFqrpNMOancVZjCIZeY8JP-rJ69HIi51GZb6vt9-3ULZ5rg";

    // Métodos de acesso
    public enum Method {
        GET,
        POST,
        DELETE
    }

    // Acesso à API
    public static async Task<string> CallAPI_Async(Method method, string endpoint, FormUrlEncodedContent body = null) {
        Console.WriteLine("API: Endpoint " + endpoint);
        HttpClient client = new HttpClient();
        HttpResponseMessage response = null;
        switch (method) {
        case Method.GET:
            response = await client.GetAsync(endpoint);
            break;
        case Method.POST:
            response = await client.PostAsync(endpoint, body);
            break;
        case Method.DELETE:
            response = await client.DeleteAsync(endpoint);
            break;
        }
        if (response != null && response.IsSuccessStatusCode) {
            return await response.Content.ReadAsStringAsync();
        } else {
            Console.WriteLine($"Erro! Status code: {response.StatusCode}");
            return null;
        }
    }

    public static async Task<string> Add_Async(double valorA, double valorB) {
        double result = valorA + valorB;
        string currentDate = DateTime.Now.ToString("o");
        Calculadora calc = new Calculadora(0, valorA, valorB, "+", result, currentDate);
        if (USE_MOCK) return await CallAPI_Async(Method.POST, $"{TEMP_API_POST}", Calculadora.ToBody(calc));
        return await CallAPI_Async(Method.POST, $"{API}?apikey={API_KEY}", Calculadora.ToBody(calc));
    }

    public static async Task<string> Sub_Async(double valorA, double valorB) {
        double result = valorA - valorB;
        string currentDate = DateTime.Now.ToString("o");
        Calculadora calc = new Calculadora(0, valorA, valorB, "-", result, currentDate);
        if (USE_MOCK) return await CallAPI_Async(Method.POST, $"{TEMP_API_POST}", Calculadora.ToBody(calc));
        return await CallAPI_Async(Method.POST, $"{API}?apikey={API_KEY}", Calculadora.ToBody(calc));
    }

    public static async Task<string> Mul_Async(double valorA, double valorB) {
        double result = valorA * valorB;
        string currentDate = DateTime.Now.ToString("o");
        Calculadora calc = new Calculadora(0, valorA, valorB, "*", result, currentDate);
        if (USE_MOCK) return await CallAPI_Async(Method.POST, $"{TEMP_API_POST}", Calculadora.ToBody(calc));
        return await CallAPI_Async(Method.POST, $"{API}?apikey={API_KEY}", Calculadora.ToBody(calc));
    }

    public static async Task<string> Div_Async(double valorA, double valorB) {
        double result = valorA / valorB;
        string currentDate = DateTime.Now.ToString("o");
        Calculadora calc = new Calculadora(0, valorA, valorB, "/", result, currentDate);
        if (USE_MOCK) return await CallAPI_Async(Method.POST, $"{TEMP_API_POST}", Calculadora.ToBody(calc));
        return await CallAPI_Async(Method.POST, $"{API}?apikey={API_KEY}", Calculadora.ToBody(calc));
    }

    public static async Task<string> List_Async() {
        if (USE_MOCK) return await CallAPI_Async(Method.GET, $"{TEMP_API_GET}");
        return await CallAPI_Async(Method.GET, $"{API}?apikey={API_KEY}");
    }

    public static async Task<string> Del_Async(int id) {
        if (USE_MOCK) return await CallAPI_Async(Method.DELETE, $"{TEMP_API_DELETE}?id={id}");
        return await CallAPI_Async(Method.DELETE, $"{API}?apikey={API_KEY}&id={id}");
    }
}