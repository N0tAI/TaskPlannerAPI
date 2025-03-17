using Microsoft.AspNetCore.Mvc;
using Thayen.WebPlanner.Data;

namespace Thayen.WebPlanner.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(PlannerDatabaseContext context) : ControllerBase
{
    private readonly PlannerDatabaseContext _context = context;
}