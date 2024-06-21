using EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.DTO;
using EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Models;
using EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Repositories;
using EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class FoldersController : ControllerBase
{
    private readonly IRepository<Folder> _folderRepository;
    private readonly FolderService _folderService;

    public FoldersController(IRepository<Folder> folderRepository, FolderService folderService)
    {
        _folderRepository = folderRepository;
        _folderService = folderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFoldersAsync()
    {
        var allFolders = await _folderRepository.GetAll();
        return Ok(allFolders);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetFolder(int id)
    {
        if (id < 0)
        {
            return BadRequest();
        }
        var folder = await _folderRepository.GetById(id);
        if (folder == null)
        {
            return NotFound();
        }
        return Ok(folder);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFolderAsync([FromBody] FolderDTO folderDto)
    {
        var folder = await _folderService.CreateFolderAsync(folderDto);
        return CreatedAtAction(nameof(GetFolder), new { id = folder.FolderId }, folder);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFolder(int id, [FromBody] FolderDTO folderDto)
    {
        var existingFolder = await _folderRepository.GetById(id);
        if (existingFolder == null)
        {
            return NotFound();
        }

        existingFolder.FolderName = folderDto.FolderName;

        await _folderRepository.Update(existingFolder);
        return Ok(existingFolder);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFolder(int id)
    {
        var folder = await _folderRepository.GetById(id);
        if (folder == null)
        {
            return NotFound();
        }

        await _folderRepository.Delete(folder);
        return NoContent();
    }
}
