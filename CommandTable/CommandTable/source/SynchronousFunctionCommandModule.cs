using System;
using System.Threading.Tasks;
using SimpleJSON;

namespace CommandTable
{
    public class SynchronousFunctionCommandModule : CommandModule
    {
        Func<JSONNode, JSONNode> _action;

        JSONNode DoAction(object arg)
        {
            return _action(arg as JSONNode);
        }

        public override Task<JSONNode> RunCommand(JSONNode command)
        {
            var task = new Task<JSONNode>(DoAction, command);
            task.RunSynchronously();
            return task;
        }

        public SynchronousFunctionCommandModule(Func<JSONNode, JSONNode> action)
        {
            _action = action;
        }
    }
}
