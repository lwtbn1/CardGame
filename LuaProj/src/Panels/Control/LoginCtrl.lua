--region *.lua
--Date
--此文件由[BabeLua]插件自动生成
LoginCtrl = {};
local this = LoginCtrl;
this.panelName = "LoginPanel";
this.luaBehaviour = nil;
this.panel = require "Panels/View/LoginPanel";

function LoginCtrl.New()
    return this;
end

function LoginCtrl.PushPanel()
    uiMgr:PushPanel("LoginPanel",this.panelName, this);
    
end

function LoginCtrl.SdkLogin()
    --print("LoginCtrl.SdkLogin ................." .. this.panelName);
    local isOn = this.panel.ui.confirmToggle.isOn;
    if isOn then
        --net...这里向服务器发起登录请求,回调后，进入游戏界面
        --if Application.isMobilePlatform then
            --SdkAdapter.Authorize_Wei_Xin(LoginCtrl.SdkLoginCb);
        --else
            LoginCtrl.SdkLoginCb(200);
        --end
        
    else
        uiMgr:ShowTextTips("未选中同意协议");
    end
    
    
end
function LoginCtrl.SdkLoginCb(code)
    if code == 200 then
        CtrlMgr.GetCtrl(CtrlNames.Main).PushPanel();
    end
end
--启动事件--
function LoginCtrl.OnCreate(obj)
    --print(obj.name)
    this.luaBehaviour = obj:GetComponent(typeof(LuaBehaviour))
    this.luaBehaviour:AddClick(this.panel.ui.SdkLoginButton.gameObject, LoginCtrl.OnSdkLoginButtonClick);
    
    LoginCtrl.Enable();
end

function LoginCtrl.OnSdkLoginButtonClick(obj)
    LoginCtrl.SdkLogin();
end

function LoginCtrl.Enable()

end

function LoginCtrl.Update()
    --print("LoginCtrl.Update  ......");
end

function LoginCtrl.OnDisable()
    --print("LoginCtrl.OnDisable...");
end
--endregion
