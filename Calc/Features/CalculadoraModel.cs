using System.Text.Json;
using System.Text.Json.Serialization;

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
    public static FormUrlEncodedContent ToBody(Calculadora calc) {
        return new FormUrlEncodedContent(new Dictionary<string, string> {
            { "id", calc.Id.ToString() },
            { "valorA", calc.ValorA.ToString() },
            { "valorB", calc.ValorB.ToString() },
            { "operacao", calc.Operacao },
            { "resultado", calc.Resultado.ToString() },
            { "dataCalculo", calc.DataCalculo }
        });
    }

    // JSON body -> Objeto
    public static Calculadora[] ToCalcList(string json) {
        return JsonSerializer.Deserialize<Calculadora[]>(json);
    }

  }