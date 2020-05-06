using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using med.domain;
using Med.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace med.service
{
    public class ContatoService : IContatoService
    {
	private readonly DataContext context;
    public ContatoService(DataContext _context )
    {
        context = _context;

    }
    public ContatoService( )
    {


    }
    public void SalvarContato(Contato model )
    {   
        try
        {
            if(!model.VerificaSexo())
            {
                throw  new Exception("O Sexo deve conter apenas 'M' para Masculino  ou 'F'  para Feminino.");
            }
            context.Contatos.Add(model);
            context.SaveChanges();
        }
        catch(Exception ex)
        {
               throw ex; 
        }
    }

    public List<Contato> GetAll()
    {
        var contatos =  context.Contatos.ToList();
        return contatos;
    }

    public Contato GetById(int id)
    {
        var contatos =  context.Contatos.FirstOrDefault(x => x.Id ==id);
        return contatos;
    }

    public void Update(Contato model)
    {
        try
        {  
            if(!model.VerificaSexo())
            {
                throw  new Exception("O Sexo deve conter apenas 'M' para Masculino  ou 'F'  para Feminino.");
            }

            context.Contatos.Update(model);
            context.SaveChanges();
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
    public void Delete(Contato model)
    {
        try
        {
            context.Contatos.Remove(model);
            context.SaveChanges();
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    public void VerificaDataNascimnto(DateTime dataNascimento)
    {
        // try
        // {
        //     if(dataNascimento >= DateTime.Now())
        //       throw "w";   
        // }

    }

    }
}
