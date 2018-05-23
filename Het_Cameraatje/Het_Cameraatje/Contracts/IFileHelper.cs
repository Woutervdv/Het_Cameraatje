using System;
using System.Collections.Generic;
using System.Text;

namespace Het_Cameraatje.Contracts
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
