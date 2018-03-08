using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Drones
{
    /// <summary>
    /// Reads input data from file
    /// </summary>
    public class CommandFileReader : IDisposable
    {
        private System.IO.StreamReader _fileReader;
        public CommandFileReader(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
                throw new System.IO.FileNotFoundException(filePath + " could not be found.");
            _fileReader = System.IO.File.OpenText(filePath);
        }

        public IEnumerable<CommandLine> Readline()
        {
            var line = "";
            while((line = _fileReader.ReadLine())!=null)
            {
                yield return CommandInterpreter.GetCommandFromString(line);
            }
        }

        public void Dispose()
        {
            _fileReader?.Dispose();
        }
    }
}
