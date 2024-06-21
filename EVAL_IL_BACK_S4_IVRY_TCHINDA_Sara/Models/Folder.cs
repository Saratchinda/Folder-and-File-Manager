using System.ComponentModel.DataAnnotations;

namespace EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Models
{
    public class Folder
    {
       
        public int FolderId { get; set; }
        public string FolderName { get; set; }

        public int Size { get; set; }
        public ICollection<XFile> XFiles { get; set; }

       
    }
    }

