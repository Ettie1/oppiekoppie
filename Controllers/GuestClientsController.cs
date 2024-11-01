using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using oppiekoppie.Models;

namespace oppiekoppie.Controllers;

public class GuestClientsController: Controller
{
    private OppieKoppieContext db;
    public GuestClientsController(OppieKoppieContext _db)
    {
        db = _db;
    }
    public DbSet<GuestClient> GuestClients{get;set;}
    
}