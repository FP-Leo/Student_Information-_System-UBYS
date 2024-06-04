
using api.DTO;
using api.Models;

namespace api.Mappers
{
    public static class DocumentRequestMapper
    {
        public static DocumentRequestDto ToDocumentRequestDto(this DocumentRequest documentRequest){
            return new DocumentRequestDto{
                Id = documentRequest.Id,
                TC = documentRequest.TC,
                DocumentType = documentRequest.DocumentType,
                DocumentLanguage = documentRequest.DocumentLanguage,
                RequestDate = documentRequest.RequestDate,
                State = documentRequest.State,
            };
        }
    }
}