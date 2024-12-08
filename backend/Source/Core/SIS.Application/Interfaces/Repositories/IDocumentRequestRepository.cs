using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Repositories
{
    public interface IDocumentRequestRepository
    {
        Task<ICollection<DocumentRequest>?> GetRequestedDocumentsAsync(string TC);
        Task<DocumentRequest?> AddDocumentRequestAsync(DocumentRequest requestedDocument);
        Task<ICollection<DocumentRequest>?> DeleteDocumentRequestsAsync(string TC);
    }
}