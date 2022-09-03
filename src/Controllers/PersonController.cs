using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C_pottencial_dev_week.src.Models;
using C_pottencial_dev_week.src.Persistence;
using System.Net;

namespace C_pottencial_dev_week.src.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoaController : ControllerBase
{
    private DataBaseContext _context { get; set; }

    public PessoaController(DataBaseContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public ActionResult<List<Person>> get()
    {
        var result = _context.Persons.Include(x => x.contratos).ToList();
        if (!result.Any())
        {
            return NoContent();
        }

        return Ok(result);
    }

    [HttpPost]
    public ActionResult<Person> Post(Person pessoa)
    {
        _context.Persons.Add(pessoa);
        _context.SaveChanges();

        try
        {
            _context.Persons.Update(pessoa);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {
            return BadRequest();
        }

        return Created("Criado", pessoa);
    }

    [HttpPut("{id}")]
    public ActionResult<Object> Update(int id,Person pessoa)
    {
        try
        {
            _context.Persons.Update(pessoa);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {
            return BadRequest(new
            {
                msg = "Houve um erro ao enviar a solicitação de atualiazção",
                status = HttpStatusCode.OK
            });
        }


        return Ok(new
        {
            msg = "Dados do id " + id + " atualizados",
            status = HttpStatusCode.OK
        });
    }

    [HttpDelete("{id}")]
    public ActionResult<Object> Delete(int id)
    {
        var result = _context.Persons.SingleOrDefault(x => x.Id == id);

        if (result is null)
        {
            return BadRequest(new
            {
                msg = "Conteúdo inexistente, não é possível prosseguir",
                status = "400"
            });
        }
        _context.Persons.Remove(result);
        _context.SaveChanges();

        return Ok("Pessoa do id " + id + " excluida!");
    }
}

