using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.API.net.Datas.Entities;
using RAS.Bootcamp.API.net.Datas.Entities.Request;

namespace RAS.Bootcamp.API.net.Controllers;

[ApiController]
[Route("[controller]")]

public class BarangController : Controller{
 private readonly IRepository<Barang> _barang;


    public BarangController (IRepository<Barang> barang){
        _barang = barang;
    }
    [HttpGet]
    public IActionResult Barang(){
        var product = _barang.GetList();
        return Ok(product);
    }
    [HttpPost]
    public IActionResult InputBarang(RequestBarang req){
        var barang = new Barang()
        {
            Kode = req.Kode,
            Nama = req.Nama,
            Harga = req.Harga,
            Description = req.Description,
            Stok = req.Stok,
            // IdPenjual = req.IdPenjual
            IdPenjual = 5
        };

        _barang.Add(barang);
        return Created("",barang);
    }

    [HttpGet("{id}")]
    public IActionResult DetailBarang(int id){
        var product = _barang.Get(id);
        return Ok(product);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBarang(int id, RequestBarang req){
        var product = _barang.Get(id);
        if (product == null){
            return NotFound();
        };
        product.Kode = req.Kode;
        product.Nama = req.Nama;
        product.Harga = req.Harga;
        product.Description = req.Description;
        product.Stok = req.Stok;
        _barang.Update(product);
        return Ok(product);    
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteBarang(int id){ 
        _barang.Remove(id);
        return Ok();    
    }
}
