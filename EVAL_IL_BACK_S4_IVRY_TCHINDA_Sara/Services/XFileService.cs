using EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Data;
using EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.DTO;
using EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Services
{
    public class XFileService
    {
        private readonly AppDbContext _appDbContext;

        public XFileService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<XFile> CreateFileAsync(XFileDTO xFileDTO)
        {
            var folder = await _appDbContext.Folders.FindAsync(xFileDTO.FolderId);

            if (folder == null)
            {
                throw new Exception("Folder not found");
            }

            var xFile = new XFile
            {
                Name = xFileDTO.Name,
                Type = xFileDTO.Type,
                Content = xFileDTO.Content,
                Size = xFileDTO.Size,
                FolderId = xFileDTO.FolderId
            };

            _appDbContext.XFiles.Add(xFile);
            await _appDbContext.SaveChangesAsync();

            return xFile;
        }

        public async Task<IEnumerable<XFile>> GetFilesByFolderId(int folderId)
        {
            return await _appDbContext.XFiles
                .Where(x => x.FolderId == folderId)
                .ToListAsync();
        }

        public async Task<XFile> GetFileById(int id)
        {
            return await _appDbContext.XFiles.FindAsync(id);
        }

        public async Task UpdateFile(XFile xFile)
        {
            _appDbContext.XFiles.Update(xFile);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteFile(int id)
        {
            var xFile = await _appDbContext.XFiles.FindAsync(id);
            if (xFile != null)
            {
                _appDbContext.XFiles.Remove(xFile);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
