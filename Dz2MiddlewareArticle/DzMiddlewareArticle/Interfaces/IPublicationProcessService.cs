using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IPublicationProcessService
    {
        void StartPublishingProcess();
        void PublicationProcess(string content);
        void EndPublishingProcess();
    }
}
