using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    [Serializable]
    public class DocumentContent
    {

        public byte[] Content { get; set; }
        public string Extention { get; set; }

        public DocumentContent() { }
        public DocumentContent(byte[] toContent, string toExtention)
        {
            Content = toContent;
            Extention = toExtention;
        }


    }
}
