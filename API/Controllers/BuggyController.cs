using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {

            //Testing this encounter in the server
            var thing = _context.Products.Find(42); //does not exist

            if(thing == null)
            {
                return NotFound(new ApiResponse(404)); //This should be returned

            }

            return Ok();
        } 


        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _context.Products.Find(42); //does not exist

            var thingToReturn = thing.ToString();// Generates an exception on a toString() method

            return Ok();
        } 


        [HttpGet("badRequest")] //Returns a 400 Error
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        } 


        [HttpGet("badRequest/{id}")] 
        public ActionResult GetBadRequest(int id)
        {
            return Ok();
        } 
    
    }
}