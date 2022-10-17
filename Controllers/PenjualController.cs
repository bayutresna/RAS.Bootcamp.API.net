using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.API.net.Datas.Entities;

namespace RAS.Bootcamp.API.net.Controllers;

[ApiController]
[Route("[controller]")]

public class PenjualController : ControllerBase{
    private readonly dbmarketContext _dbcontext;

    public PenjualController (dbmarketContext dbcontext){
        _dbcontext = dbcontext;
    }
    
    [HttpGet]
    public IActionResult Penjual(){
        var penjual = _dbcontext.Penjuals.ToList();
        return Ok(penjual);
    }
       [HttpPost]
    public IActionResult InputPenjual(RequestPenjual req){
        var penjual = new Penjual()
        {
            NamaToko = req.NamaToko,
            Alamat = req.Alamat
        };

        _dbcontext.Penjuals.Add(penjual);
        _dbcontext.SaveChanges();
        return Created("",penjual);
    }
    [HttpGet("{id}")]
    public IActionResult DetailPenjual(int id){
        var penjual = _dbcontext.Penjuals.FirstOrDefault(x => x.Id == id);
        return Ok(penjual);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePenjual(int id, RequestPenjual req){
        var penjual = _dbcontext.Penjuals.FirstOrDefault(x => x.Id == id);
        if (penjual == null){
            return NotFound();
        };
        penjual.NamaToko = req.NamaToko;
        penjual.Alamat = req.Alamat;
        _dbcontext.SaveChanges();
        return Ok(penjual);    
    }
    [HttpDelete("{id}")]
    public IActionResult DeletePenjual(int id){
        var penjual = _dbcontext.Penjuals.FirstOrDefault(x => x.Id == id);
        if (penjual == null){
            return NotFound();
        };
        _dbcontext.Penjuals.Remove(penjual);
        _dbcontext.SaveChanges();
        return Ok();    
    }


}