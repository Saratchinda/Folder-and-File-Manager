using EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.DTO;
using EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Models;
using EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Repositories;
using System.Threading.Tasks;

namespace EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Services
{
    public class FolderService
    {
        private readonly IRepository<Folder> _folderRepository;
        private readonly IRepository<XFile> _xfileRepository;

        public FolderService(IRepository<Folder> folderRepository, IRepository<XFile> xfileRepository)
        {
            _folderRepository = folderRepository;
            _xfileRepository = xfileRepository;
        }

        public async Task<Folder> CreateFolderAsync(FolderDTO folderDTO)
        {
            var folder = new Folder
            {
                FolderName = folderDTO.FolderName,
                Size = folderDTO.Size
            };

            await _folderRepository.Create(folder);

            var xfile = new XFile
            {
                Name = "default.txt",
                Type = "text/plain",
                Content = "This is a default file.",
                Size = 0,
                FolderId = folder.FolderId
            };

            await _xfileRepository.Create(xfile);

            return folder;
        }

        public Folder SetFolder(FolderDTO folderDTO)
        {
            return new Folder
            {
                FolderName = folderDTO.FolderName,
                Size = folderDTO.Size
            };
        }
    }
}
