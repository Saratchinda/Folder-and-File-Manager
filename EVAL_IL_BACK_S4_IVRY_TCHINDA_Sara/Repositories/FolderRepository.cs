using EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Data;
using EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Repositories
{
    public class FolderRepository : IRepository<Folder>
    {
        private readonly AppDbContext _context;

        public FolderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Folder folder)
        {
            _context.Folders.Add(folder);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Folder folder)
        {
            _context.Folders.Remove(folder);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Folder>> GetAll()
        {
            return await _context.Folders.ToListAsync();
        }

        public async Task<Folder> GetById(int id)
        {
            return await _context.Folders.FindAsync(id);
        }

        public async Task Update(Folder folder)
        {
            _context.Folders.Update(folder);
            await _context.SaveChangesAsync();
        }
    }
}
