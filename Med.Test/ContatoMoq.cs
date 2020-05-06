using System;
using System.Collections.Generic;
using System.Linq;
using med.domain;
using med.service;


namespace med.test
{

    public class ContatoMoq : IContatoService
    {
        
        private readonly List<Contato> lista ;

        public ContatoMoq()
        {
            
            lista = new List<Contato>(){
                new Contato()
                {   Id =1,
                    Nome="Germano",
                    Sexo="M",
                    DataNascimento=new DateTime(1978,12,11)
                },
                new Contato()
                {   Id =2,
                    Nome="Fabianne",
                    Sexo="F",
                    DataNascimento=new DateTime(1983,10,15)
                },
                new Contato()
                {   Id =3,
                    Nome="Mariana",
                    Sexo="F",
                    DataNascimento=new DateTime(2011,08,08)
                },
                new Contato()
                {   Id=4,
                    Nome="Maria Carolinne",
                    Sexo="F",
                    DataNascimento=new DateTime(2017,09,19)
                }
            };
        }
        public void Delete(Contato model)
        {
            lista.Remove(model);
        }

        public List<Contato> GetAll()
        {
            return lista;
        }

        public Contato GetById(int id)
        {
            return lista.Where(x => x.Id == id).FirstOrDefault();
        }

        public void SalvarContato(Contato model)
        {
             if(!model.VerificaSexo())
            {
                throw  new Exception("O Sexo deve conter apenas 'M' para Masculino  ou 'F'  para Feminino.");
            }
            lista.Add(model);
        }

        public void Update(Contato model)
        {
            var x = lista.FindIndex(0, 1, x => x.Id == model.Id);
			lista[x] = model;
        }
    }
}