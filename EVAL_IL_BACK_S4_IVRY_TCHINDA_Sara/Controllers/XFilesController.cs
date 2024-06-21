using EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.DTO;
using EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Models;
using EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class XFilesController : ControllerBase
{
    private readonly XFileService _xFileService;

    public XFilesController(XFileService xFileService)
    {
        _xFileService = xFileService;
    }

    [HttpGet("fromParent/{parentId}")]
    public async Task<IActionResult> GetFilesFromParent(int parentId)
    {
        var files = await _xFileService.GetFilesByFolderId(parentId);
        return Ok(files);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<XFile>> GetXFile(int id)
    {
        var xfile = await _xFileService.GetFileById(id);
        if (xfile == null)
        {
            return NotFound();
        }
        return Ok(xfile);
    }

    [HttpPost]
    public async Task<IActionResult> CreateXFile([FromBody] XFileDTO xfileDto)
    {
        var xfile = await _xFileService.CreateFileAsync(xfileDto);
        return CreatedAtAction(nameof(GetXFile), new { id = xfile.Id }, xfile);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateXFile(int id, [FromBody] XFileDTO xfileDto)
    {
        var existingXFile = await _xFileService.GetFileById(id);
        if (existingXFile == null)
        {
            return NotFound();
        }

        existingXFile.Name = xfileDto.Name;
        existingXFile.Type = xfileDto.Type;
        existingXFile.Content = xfileDto.Content;
        existingXFile.Size = xfileDto.Size;

        await _xFileService.UpdateFile(existingXFile);
        return Ok(existingXFile);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteXFile(int id)
    {
        var xfile = await _xFileService.GetFileById(id);
        if (xfile == null)
        {
            return NotFound();
        }

        await _xFileService.DeleteFile(id);
        return NoContent();
    }
}
