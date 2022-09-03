using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C_pottencial_dev_week.src.Persistence;
using System.Threading.Tasks;
using C_pottencial_dev_week;

namespace C_pottencial_dev_week.src.Models
{
    public class Person
    {
        public Person(){
            this.Nome = "template";
            this.Idade = 0;
            this.contratos = new List<Contracts>();
            this.Ativado = true;
        }
        public Person(string nome,int idade,string cpf){
           this.Nome = nome;
           this.Idade = idade;
           this.Cpf = cpf;
           this.contratos = new List<Contracts>();
           this.Ativado = true; 
        }
        public int Id{get;set;}
        public string Nome {get; set;}
        public int Idade { get; set; }
        public string? Cpf { get; set; }
        public bool Ativado { get; set; }
        public List<Contracts> contratos { get; set; }
    }
}