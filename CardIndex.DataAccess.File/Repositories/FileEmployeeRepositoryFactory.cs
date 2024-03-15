using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using CardIndex.Core.Repositories;

namespace CardIndex.DataAccess.File.Repositories
{
    public class FileEmployeeRepositoryFactory
    {

        public IEmployeeRepository CreateRepository(string filename)
        {
            string filenameExtension = Path.GetExtension(filename);

            switch(filenameExtension)
            {
                case ".crdtxt":
                    return new TextFileEmployeeRepository { FileName = filename };

                case ".crdbin":
                    return new BinaryFileEmployeeRepository { FileName = filename };

                case ".crdxml":
                    return new XmlFileEmployeeRepository { FileName = filename };

                case ".crdjson":
                    return new JsonFileEmployeeRepository { FileName = filename };

                default:
                    return null;
            }
        }
    }
}
