--region *.lua
--Date
--此文件由[BabeLua]插件自动生成
require "Control/MainCtrl"
require "Control/LoginCtrl"
require "Control/PreloadBundlesCtrl"
CtrlMgr = {};
local this = CtrlMgr;
local ctrlList = {};
function CtrlMgr.Init()
    ctrlList[CtrlNames.Main] = MainCtrl.New();
    ctrlList[CtrlNames.Login] = LoginCtrl.New();
    ctrlList[CtrlNames.PreloadBundles] = PreloadBundlesCtrl.New();
end

function CtrlMgr.GetCtrl(name)
    --print("getCtrl ".. name)
    return ctrlList[name]
end
--endregion
