

using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using med.domain;
using med.service;


//http://localhost:5000/contato
[Route("contatos")]

public class ContatoController : ControllerBase
{

    private readonly IContatoService _service ;
    
    public ContatoController(IContatoService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("")]
    public  IActionResult Get()
    {
        var contatos = _service.GetAll();
            return Ok(contatos);
        
    }

     [HttpGet]
    [Route("{id:int}")]
    public IActionResult GetById(int id)
    {
        var contato =   _service.GetById(id);
        
        return Ok(contato);
    }

    [HttpPost]
    [Route("")]
    public IActionResult  Post([FromBody]Contato model)
    {
        // verifica se os dados são váliddos
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
    
        try 
        {

            _service.SalvarContato(model);

        }
        catch(Exception ex )
        {   
            return BadRequest(new {message="Não foi possivel criar um Contato"} + ex.Message);
        }

        return Ok(model);
    }
    
    [HttpPut]
    [Route("{id:int}")]
    public IActionResult  Put(int id, 
    [FromBody]Contato model)
    {
        //Verifica se o ID é o mesmo do modelo
        if (model.Id!=id) 
            return NotFound(new {message="Contato não Encontrado"});

        //verifica se os dados são váliddos
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        try{

            _service.Update(model);

            return Ok(model);
        }
        catch(DbUpdateConcurrencyException)
        {
            return BadRequest(new {message="Este registro já foi atualizado"} );
        }
        catch(Exception ex)
        {
            return BadRequest(new {message="Não foi possivel atualizar o Contato"} + ex.Message);
        }
        
    }

    [HttpDelete]
    [Route("{id:int}")]
    public ActionResult Delete(int id)
    {
        var contato = _service.GetById(id);
        if(contato ==null)
            return  NotFound(new{Message="Contato não encontrado"});
            try
            {
                _service.Delete(contato);
                return Ok(new {message="Contato removido com sucesso!"});
            }
            catch(Exception)
            {
                return BadRequest(new {message="Não foi possível remover o Contato"});
            }
            
    }
}