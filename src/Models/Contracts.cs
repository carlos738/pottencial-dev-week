using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C_pottencial_dev_week;
namespace C_pottencial_dev_week.src.Models
{
    public class Contracts
    {
        public Contracts(){
            this.DataCriacao = DateTime.Now;
            this.Valor = 0;
            this.TokenId = "000000";
            this.Pago = false;
        }
        public Contracts(string TokenId,double Valor){
            this.DataCriacao = DateTime.Now;
            this.TokenId = TokenId;
            this.Valor = Valor;
            this.Pago = false;
        }
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public string TokenId { get; set; }
        public double Valor { get; set; }
        public bool Pago { get; set; }
        public int PessoaId { get; set; }
    }
}