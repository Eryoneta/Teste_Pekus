using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Headers;

public class Calculadora {

    // Vars
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("valorA")] public double ValorA { get; set; }
    [JsonPropertyName("valorB")] public double ValorB { get; set; }
    [JsonPropertyName("operacao")] public string Operacao { get; set; }
    [JsonPropertyName("resultado")] public double Resultado { get; set; }
    [JsonPropertyName("dataCalculo")] public string DataCalculo { get; set; }

    // Main
    public Calculadora(int Id, double ValorA, double ValorB, string Operacao, double Resultado, string DataCalculo) {
        this.Id = Id;
        this.ValorA = ValorA;
        this.ValorB = ValorB;
        this.Operacao = Operacao;
        this.Resultado = Resultado;
        this.DataCalculo = DataCalculo;
    }

    // Objeto -> JSON body
    public static HttpContent ToBody(Calculadora calc) {
        var jsonContent = JsonSerializer.Serialize(calc);
        var buffer = System.Text.Encoding.UTF8.GetBytes(jsonContent);
        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        return byteContent;
    }

    // JSON body -> Objeto
    public static Calculadora[] ToCalcList(string json) {
        return JsonSerializer.Deserialize<Calculadora[]>(json);
    }

  }