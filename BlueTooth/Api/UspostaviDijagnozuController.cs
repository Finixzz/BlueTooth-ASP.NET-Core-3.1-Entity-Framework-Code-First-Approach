using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueTooth.Models;
using BlueTooth.Models.Interfaces;
using BlueTooth.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlueTooth.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UspostaviDijagnozuController : ControllerBase
    {
        private IUspostaviDijagnozu uspostaviDijagnozu;

        public UspostaviDijagnozuController(IUspostaviDijagnozu uspostaviDijagnozu)
        {
            this.uspostaviDijagnozu = uspostaviDijagnozu;
        }

        [HttpGet]
        public IActionResult OK()
        {
            return Ok("[1,2,3]");
        }
        [HttpPost]
        public IActionResult UspostaviDijagnozu(UspostaviDijagnozuModel model)
        {
            model = uspostaviDijagnozu.UspostaviDijagnozu(model);
            return CreatedAtAction(nameof(model), new { model.DijagnozaId }, model);
        }

    }
}