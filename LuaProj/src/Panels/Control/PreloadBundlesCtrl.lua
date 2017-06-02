--region *.lua
--Date
--此文件由[BabeLua]插件自动生成
PreloadBundlesCtrl = {};
local this = PreloadBundlesCtrl;
this.panelName = "PreloadBundlesPanel";
this.luaBehaviour = nil;
this.panel = require "Panels/View/PreloadBundlesPanel";
local bundles = {
    "panel/tips",
    "panel/loginpanel",
    "panel/mainpanel",
};
function PreloadBundlesCtrl.New()
    return this;
end

function PreloadBundlesCtrl.PushPanel()
    uiMgr:PushPanel("PreloadBundlesPanel",this.panelName, this);
end

--启动事件--
function PreloadBundlesCtrl.OnCreate(obj)
    --print(obj.name)
    this.luaBehaviour = obj:GetComponent(typeof(LuaBehaviour))
    
    PreloadBundlesCtrl.Enable();
end


function PreloadBundlesCtrl.Enable()
    --print("PreloadBundlesCtrl.Enable....");
    resMgr:LoadBundles(bundles,
    function ()
        this.panel.ui.infoText.text = "加载资源...";
    end,
    function (val)
        this.panel.ui.slider.value = val;
    end,
    function (val)
        this.panel.ui.slider.value = 1;
        CtrlMgr.GetCtrl(CtrlNames.Login).PushPanel();
    end
    );
end

function PreloadBundlesCtrl.Update()
    --print("PreloadBundlesCtrl.Update  ......");
end


function PreloadBundlesCtrl.OnDisable()
    --print("PreloadBundlesCtrl.OnDisable...");
end
--endregion
