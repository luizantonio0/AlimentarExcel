using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.Entities
{
    public class Pessoa
    {
        public string JobId { get; set; }
        public DateTime Admissão { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        //A Empresa Tomadora: BB, IPEM
        public string Contrato { get; set; }

        //Empresa dona do contrato: Minuta, UpIdeias
        public string Empresa { get; set; }
        public string Dispositivo { get; set; }
        public Status Status { get; set; }

        public Pessoa(
            string jobId,
            DateTime admissao,
            string nome,
            string telefone,
            string contrato,
            string empresa,
            string dispositivo,
            Status status)
        {
            JobId = jobId;
            Admissão = admissao;
            Nome = nome;
            Telefone = telefone;
            Contrato = contrato;
            Empresa = empresa;
            Dispositivo = dispositivo;
            Status = status;
        }

        public List<object> getDadosDeUmaPessoaTeste()
        {
            return new List<object>()
            {
                this.JobId,
                this.Admissão.ToString("dd/MM/yyyy"),
                this.Nome,
                this.Telefone,
                this.Empresa,
                this.Contrato,
                this.Dispositivo,
                this.Status.ToCustomString()
            };

        }

        public List<IList<object>> getDadosDeUmaPessoa()
        {
            var data = new List<object>()
            {
                this.JobId,
                this.Admissão.ToString("dd/MM/yyyy"),
                this.Nome,
                this.Telefone,
                this.Empresa,
                this.Contrato,
                this.Dispositivo,
                this.Status.ToCustomString()
            };

            return new List<IList<object>> { data };
        }

        public override string ToString()
        {
            return $"JobId: {JobId}, Admissão: {Admissão:dd/MM/yyyy}, Nome: {Nome}, Telefone: {Telefone}, Empresa: {Empresa}, Contrato: {Contrato}, Dispositivo: {Dispositivo}, Status: {Status.ToCustomString()}";
        }
    }
}