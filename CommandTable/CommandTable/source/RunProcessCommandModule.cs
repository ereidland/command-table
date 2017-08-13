using System.Threading.Tasks;
using SimpleJSON;

namespace CommandTable
{
    public class RunProcessCommandModule : CommandModule
    {
        JSONNode RunProcessTask(object arg)
        {
            JSONNode command = arg as JSONNode;
            if (command == null)
                return null;

            var processId = command["target"];
            var args = command["args"];

            Log.MessageFormat(Log.Level.Debug, "Running: {0} {1}", processId, args);
            
            //TODO: Actually start the process, wait for it to finish, then return the result.
            return command;
        }
        public override Task<JSONNode> RunCommand(JSONNode command)
        {
            var task = new Task<JSONNode>(RunProcessTask, command);
            task.Start();
            return task;
        }
    }
}
