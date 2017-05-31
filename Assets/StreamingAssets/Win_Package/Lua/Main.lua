require "Define"
require "Common/Util"
require "Manager/CtrlMgr"
require "Manager/ViewMgr"

function Main()
    CtrlMgr.Init();
    ViewMgr.Init();


    local preloadBundlesCtrl = CtrlMgr.GetCtrl(CtrlNames.PreloadBundles);
    preloadBundlesCtrl.PushPanel();
    

end

