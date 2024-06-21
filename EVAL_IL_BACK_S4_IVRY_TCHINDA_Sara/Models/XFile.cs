using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
namespace EVAL_IL_BACK_S4_IVRY_TCHINDA_Sara.Models
{
    public class XFile
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }

        public int Size { get; set; }
        public int FolderId { get; set; }
        public Folder Folder { get; set; }
    }
}

