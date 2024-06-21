using EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Data;
using EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Repositories
{
    public class XFileRepository : IRepository<XFile>
    {
        private readonly AppDbContext _context;

        public XFileRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(XFile xFile)
        {
            _context.XFiles.Add(xFile);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(XFile xFile)
        {
            _context.XFiles.Remove(xFile);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<XFile>> GetAll()
        {
            return await _context.XFiles.ToListAsync();
        }

        public async Task<XFile> GetById(int id)
        {
            return await _context.XFiles.FindAsync(id);
        }

        public async Task Update(XFile xFile)
        {
            _context.XFiles.Update(xFile);
            await _context.SaveChangesAsync();
        }
    }
}
