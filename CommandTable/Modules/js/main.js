$(function() {
    //Not using new declaration/"this" so that the functions in CommandTable can be called without context.
    window.CommandTable = (function(self) {
        self.SendMessage = function(message) {
            if (_.isString(message) === false) {
                message = JSON.stringify(message);
            }
            
            window.external.ReceiveMessage(message);
        };
        
        self.ReceiveMessage = function(message) {
            alert("Client received: " + message);
        };
        
        self.Log = function(message) {
            self.SendMessage({"module": "log", "message": message});
        };
        
        window.ReceiveMessage = self.ReceiveMessage;
        
        return self;
    })({});
    
    CommandTable.SendMessage("ready");
    CommandTable.Log("Test Log.");
});