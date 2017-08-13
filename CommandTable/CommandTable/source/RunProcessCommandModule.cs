using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleJSON;

namespace CommandTable.source
{
    public class RunProcessCommandModule : CommandModule
    {

        JSONNode RunProcessTask(object arg)
        {
            JSONNode command = arg as JSONNode;
            if (command == null)
                return null;

            //TODO: Actually start the process, wait for it to finish, then return the result.
            return command;
        }
        public override Task<JSONNode> RunCommand(JSONNode command)
        {
            return new Task<JSONNode>(RunProcessTask, command);
        }
    }
}
