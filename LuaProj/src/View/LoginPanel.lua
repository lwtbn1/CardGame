LoginPanel = {};
local this = LoginPanel;
this.ui = {};
this.gameObject = nil;
this.transform = nil;

function LoginPanel.Awake(obj)
    this.gameObject = obj;
    this.transform = obj.transform;

    this.ui.confirmToggle = this.transform:FindChild("ConfirmToggle"):GetComponent("Toggle");
    this.ui.SdkLoginButton = this.transform:FindChild("SdkLoginButton"):GetComponent("Button");
    --print("LoginPanel.Awake.................");
    
end


function LoginPanel.OnEnable(obj)


end
function LoginPanel.Start(obj)


end

function LoginPanel.Update(obj)

end
function LoginPanel.LateUpdate(obj)

end

function LoginPanel.OnDisable(obj)
    --print("mainPanel OnDisable ......");
end


function LoginPanel.OnDestroy(obj)
    --print("mainPanel OnDisable ......");
end

return this;
--endregion
