using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTable
{
    public abstract class CommandModule
    {
        public abstract Task<JSONNode> RunCommand(JSONNode command);
    }
}
