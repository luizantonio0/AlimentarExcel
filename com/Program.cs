using System.Threading.Tasks;
using com.Entities;
using com.Services;

class Program{
    public static async Task Main(string[] args)
    {
        var resquest = new PessoaServices();
        var ps = await resquest.GetListPessoaAsync();

        var dados = new List<IList<object>>();

        foreach (Pessoa p in ps) {
            dados.Add(p.getDadosDeUmaPessoaTeste());
        }

        var Excel = new GerarExcel();
        Excel.Update(dados);

    }
}