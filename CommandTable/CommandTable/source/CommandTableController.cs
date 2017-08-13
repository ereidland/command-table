using SimpleJSON;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommandTable
{
    public class CommandTableController : CommandModule
    {
        Dictionary<string, CommandModule> _modulesById = new Dictionary<string, CommandModule>();

        public override Task<JSONNode> RunCommand(JSONNode args)
        {
            if (args == null)
            {
                Log.Message(Log.Level.Error, "No command args!");
                return null;
            }
            
            var module = args["module"];
            if (module == null || string.IsNullOrEmpty(module.Value)) 
            {
                Log.Message(Log.Level.Error, "Tried to run task with no module specified!");
                return null;
            }

            CommandModule moduleInstance = null;
            _modulesById.TryGetValue(module.Value, out moduleInstance);

            if (moduleInstance == null)
            {
                Log.MessageFormat(Log.Level.Error, "No such module, {0}", module.Value);
                return null;
            }

            Log.MessageFormat(Log.Level.Debug, "Running command module {0} with args {1}", module.Value, args);
            return moduleInstance.RunCommand(args);
        }

        public void RegisterCommand(string id, CommandModule module)
        {
            _modulesById[id] = module;
        }
    }
}
