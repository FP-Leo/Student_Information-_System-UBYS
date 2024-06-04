using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using api.DTO;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DocumentRequestController : ControllerBase
    {
        private readonly IDocumentRequestRepository _documentRequestRepository;
        public DocumentRequestController(IDocumentRequestRepository documentRequestRepository){
            _documentRequestRepository = documentRequestRepository;
        }
        [HttpGet("University/User/Document/Requests")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetRequestedDocuments(){
            var TC =  User.FindFirstValue(JwtRegisteredClaimNames.Name);

            var documents = await _documentRequestRepository.GetRequestedDocumentsAsync(TC);

            if(documents == null){
                return NotFound();
            }

            ICollection<DocumentRequestDto> documentsDto = [];

            foreach(var document in documents){
                documentsDto.Add(document.ToDocumentRequestDto());
            }

            return Ok(documentsDto);
        }
        [HttpDelete("University/User/Document/Requests")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRequestedDocuments([FromQuery] String TC){
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _documentRequestRepository.DeleteDocumentRequestsAsync(TC);

            if(result == null){
                return BadRequest();
            }

            return NoContent();
        }
    }
}