using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.API.net.Datas.Entities;

namespace RAS.Bootcamp.API.net.Controllers;

[ApiController]
[Route("[controller]")]

public class PenjualController : ControllerBase{
    private readonly IRepository<Penjual> _penjual;

    public PenjualController (IRepository<Penjual> penjual){
        _penjual = penjual;
    }
    
    [HttpGet]
    public IActionResult Penjual(){
        var penjual = _penjual.GetList();
        return Ok(penjual);
    }
       [HttpPost]
    public IActionResult InputPenjual(RequestPenjual req){
        var penjual = new Penjual()
        {
            NamaToko = req.NamaToko,
            Alamat = req.Alamat,
            IdUser = 1
        };

        _penjual.Add(penjual);
        return Created("",penjual);
    }
    [HttpGet("{id}")]
    public IActionResult DetailPenjual(int id){
        var penjual = _penjual.Get(id);
        return Ok(penjual);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePenjual(int id, RequestPenjual req){
        var penjual = _penjual.Get(id);
        if (penjual == null){
            return NotFound();
        };
        penjual.NamaToko = req.NamaToko;
        penjual.Alamat = req.Alamat;
        _penjual.Update(penjual);
        return Ok(penjual);    
    }
    [HttpDelete("{id}")]
    public IActionResult DeletePenjual(int id){
        _penjual.Remove(id);
        return Ok();    
    }


}