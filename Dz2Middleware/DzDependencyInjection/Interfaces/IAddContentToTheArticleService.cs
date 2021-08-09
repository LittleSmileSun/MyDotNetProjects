using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IAddContentToTheArticleService
    {
        List<string> Paragraphs { get; set; }
        void DownloadInfo();
        void SetDownloadedInfo();
        void AddContent();
    }
}
