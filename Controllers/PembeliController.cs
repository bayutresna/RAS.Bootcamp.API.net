using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.API.net.Datas.Entities;
using RAS.Bootcamp.API.net.Datas.Entities.Request;

namespace RAS.Bootcamp.API.net.Controllers;

[ApiController]
[Route("[controller]")]

public class PembeliController : ControllerBase{
    private readonly dbmarketContext _dbcontext;

    public PembeliController (dbmarketContext dbcontext){
        _dbcontext = dbcontext;
    }
    
    [HttpGet]
    public IActionResult Pembeli(){
        var pembeli = _dbcontext.Pembelis.ToList();
        return Ok(pembeli);
    }
    [HttpPost]
    public IActionResult InputPembeli(RequestPembeli req){
        var pembeli = new Pembeli()
        {
            NamaPembeli = req.NamaPembeli,
            AlamatPembeli = req.AlamatPembeli
        };

        _dbcontext.Pembelis.Add(pembeli);
        _dbcontext.SaveChanges();
        return Created("",pembeli);
    }
    [HttpGet("{id}")]
    public IActionResult DetailPembeli(int id){
        var pembeli = _dbcontext.Pembelis.FirstOrDefault(x => x.Id == id);
        return Ok(pembeli);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePembeli(int id, RequestPembeli req){
        var pembeli = _dbcontext.Pembelis.FirstOrDefault(x => x.Id == id);
        if (pembeli == null){
            return NotFound();
        };
        pembeli.NamaPembeli = req.NamaPembeli;
        pembeli.AlamatPembeli = req.AlamatPembeli;
        _dbcontext.SaveChanges();
        return Ok(pembeli);    
    }
    [HttpDelete("{id}")]
    public IActionResult DeletePembeli(int id){
        var pembeli = _dbcontext.Pembelis.FirstOrDefault(x => x.Id == id);
        if (pembeli == null){
            return NotFound();
        };
        _dbcontext.Pembelis.Remove(pembeli);
        _dbcontext.SaveChanges();
        return Ok();    
    }
}