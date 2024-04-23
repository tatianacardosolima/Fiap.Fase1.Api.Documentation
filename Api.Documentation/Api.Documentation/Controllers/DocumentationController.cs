using Microsoft.AspNetCore.Mvc;

namespace Api.Documentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentationController : ControllerBase
    {
        private  readonly string[] Customers = new[]
        {
            "Ana", "Paulo", "Jo�o", "Felipe", "Heitor", "Katia", "Marcos", "Rafaela", "Vinicius", "Mariana"
        };

        private readonly ILogger<DocumentationController> _logger;

        public DocumentationController(ILogger<DocumentationController> logger)
        {
            _logger = logger;
        }


        ///<summary>Endpoint de exemplo de como podemos fazer uma documenta��o</summary>
        ///<param name="filter">Nome ou parte do nome do cliente que voc� est� procurando</param>
        ///<returns>Lista de clientes encontrados</returns>
        ///<remarks>
        ///Esse c�digo � uma exemplo de como podemos documentar nossa api
        ///
        /// Aqui podemos colocar mais informa��es importantes para o entendimeto do endpoint
        ///</remarks>
        ///
        ///<response code = "404">N�o foi encontrado clientes na base</response>
        ///<response code = "200">Consulta realizado com sucesso</response>
        [HttpGet("customers")]
        public ActionResult GetCustomers(string filter)
        {
            var customersFiltered = Customers.Where(x => x.Contains( filter));
            if (customersFiltered==null) NotFound();

            return Ok(customersFiltered);
        }
    }
}
