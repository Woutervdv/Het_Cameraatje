using System;
using System.Collections.Generic;
using System.Text;

namespace CleanProject.Contracts
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
