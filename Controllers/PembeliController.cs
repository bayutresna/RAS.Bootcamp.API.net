using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.API.net.Datas.Entities;
using RAS.Bootcamp.API.net.Datas.Entities.Request;

namespace RAS.Bootcamp.API.net.Controllers;

[ApiController]
[Route("[controller]")]

public class PembeliController : ControllerBase{
    private readonly IRepository<Pembeli> _pembeli;

    public PembeliController (IRepository<Pembeli> pembeli){
        _pembeli = pembeli;
    }
    
    [HttpGet]
    public IActionResult Pembeli(){
        var pembeli = _pembeli.GetList();
        return Ok(pembeli);
    }
    [HttpPost]
    public IActionResult InputPembeli(RequestPembeli req){
        var pembeli = new Pembeli()
        {
            NamaPembeli = req.NamaPembeli,
            AlamatPembeli = req.AlamatPembeli,
            IdUser = 1
        };

        _pembeli.Add(pembeli);
        return Created("",pembeli);
    }
    [HttpGet("{id}")]
    public IActionResult DetailPembeli(int id){
        var pembeli = _pembeli.Get(id);
        return Ok(pembeli);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePembeli(int id, RequestPembeli req){
        var pembeli = _pembeli.Get(id);
        if (pembeli == null){
            return NotFound();
        };
        pembeli.NamaPembeli = req.NamaPembeli;
        pembeli.AlamatPembeli = req.AlamatPembeli;
        _pembeli.Update(pembeli);
        return Ok(pembeli);    
    }
    [HttpDelete("{id}")]
    public IActionResult DeletePembeli(int id){
        _pembeli.Remove(id);
        return Ok();    
    }
}