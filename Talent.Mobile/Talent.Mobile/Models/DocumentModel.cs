using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Mobile.Models
{
    public class DocumentModel
    {
        public DocumentModel()
        {
            docList = new List<DocumentModel>();
        }
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? AttachmentType { get; set; }

        public string Attachment { get; set; }

        public byte? IsDelete { get; set; }

        public List<DocumentModel> docList { get; set; }
    }
}
