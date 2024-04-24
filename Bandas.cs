public class Bandas
{
    //public FIELDS//
    public Dictionary<string, List<int>> listaDasBandas;

    //CONSTRUCTORS//
    /// <summary>
    /// Initializes a new instance of the <see cref="Bandas"/> class.
    /// </summary>
    /// <param name="defa">The default value.</param>
    public Bandas(string defa)
    {
        List<string> dummy = new List<string> { "U2", "The Beatles", "Calypso" };
        this.listaDasBandas = new Dictionary<string, List<int>>();
        foreach (string banda in dummy)
        {
            this.listaDasBandas.Add(banda, new List<int> { 1 });
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Bandas"/> class.
    /// </summary>
    public Bandas()
    {
        this.listaDasBandas = new Dictionary<string, List<int>>();
    }

    //PUBLIC METHODS//

    /// <summary>
    /// Adds a new band to the list of bands.
    /// </summary>
    /// <param name="nomeDaBanda">The name of the band to add.</param>
    public void adicionarBanda(string nomeDaBanda)
    {
        this.listaDasBandas.Add(nomeDaBanda, new List<int>());
        Console.WriteLine($"Banda {nomeDaBanda} adicionada com sucesso");
    }

    /// <summary>
    /// Lists all the bands in the collection.
    /// </summary>
    public void listarBandas()
    {
        foreach (string banda in this.listaDasBandas.Keys)
        {
            Console.WriteLine(banda);
        }
    }
    
    /// <summary>
    /// Avalia uma banda, adicionando uma nota à lista de avaliações da banda.
    /// </summary>
    /// <param name="nomeDaBanda">O nome da banda a ser avaliada.</param>
    /// <param name="nota">A nota a ser atribuída à banda.</param>
    public void avaliarBanda(string nomeDaBanda, int nota)
    {
        if (this.listaDasBandas.ContainsKey(nomeDaBanda))
        {
            this.listaDasBandas[nomeDaBanda].Add(nota);
            Console.WriteLine($"Banda {nomeDaBanda} avaliada com sucesso");
        }
        else
        {
            Console.WriteLine($"Banda {nomeDaBanda} não encontrada");
        }
    }
    
    /// <summary>
    /// Exclui uma banda da lista de bandas.
    /// </summary>
    /// <param name="nomeDaBanda">O nome da banda a ser excluída.</param>
    public void excluirBanda(string nomeDaBanda)
    {
        if (this.listaDasBandas.ContainsKey(nomeDaBanda))
        {
            this.listaDasBandas.Remove(nomeDaBanda);
            Console.WriteLine($"Banda {nomeDaBanda} excluída com sucesso");
        }
        else
        {
            Console.WriteLine($"Banda {nomeDaBanda} não encontrada");
        }
    }
}