require "Define"
require "Common/Util"
require "Manager/CtrlMgr"
require "Manager/ViewMgr"

function Main()
    CtrlMgr.Init();
    ViewMgr.Init();


    local loginCtrl = CtrlMgr.GetCtrl(CtrlNames.Login);
    loginCtrl.PushPanel();
    

end

