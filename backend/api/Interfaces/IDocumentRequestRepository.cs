using api.Models;

namespace api.Interfaces
{
    public interface IDocumentRequestRepository
    {
        Task<ICollection<DocumentRequest>?> GetRequestedDocumentsAsync(String TC);
        Task<DocumentRequest?> AddDocumentRequestAsync(DocumentRequest requestedDocument);
        Task<ICollection<DocumentRequest>?> DeleteDocumentRequestsAsync(String TC);
    }
}