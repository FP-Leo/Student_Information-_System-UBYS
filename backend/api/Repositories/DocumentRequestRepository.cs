using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class DocumentRequestRepository : IDocumentRequestRepository
    {
        private readonly ApplicationDBContext _context;
        public DocumentRequestRepository(ApplicationDBContext context){
            _context = context;
        }

        public async Task<DocumentRequest?> AddDocumentRequestAsync(DocumentRequest requestedDocument)
        {
            await _context.AddAsync(requestedDocument);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return requestedDocument;
        }
        public async Task<ICollection<DocumentRequest>?> DeleteDocumentRequestsAsync(string TC)
        {
            var requestedDocuments = await GetRequestedDocumentsAsync(TC);

            if (requestedDocuments == null){
                return null;
            }

            _context.Remove(requestedDocuments);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return requestedDocuments;
        }

        public async Task<ICollection<DocumentRequest>?> GetRequestedDocumentsAsync(string TC)
        {
            var requestedDocuments = await _context.DocumentRequests.Where(d => d.TC == TC).ToListAsync();

            return requestedDocuments;
        }
    }
}