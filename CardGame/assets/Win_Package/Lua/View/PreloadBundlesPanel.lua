PreloadBundlesPanel = {};
local this = PreloadBundlesPanel;
this.ui = {};
this.gameObject = nil;
this.transform = nil;
function PreloadBundlesPanel.Awake(obj)
    this.gameObject = obj;
    this.transform = obj.transform;
    this.ui.infoText = this.transform:FindChild("infoText"):GetComponent("Text");
    this.ui.slider = this.transform:FindChild("slider"):GetComponent("Slider");
    
    --print("PreloadBundlesPanel.Awake.................");
    
end


function PreloadBundlesPanel.OnEnable(obj)


end
function PreloadBundlesPanel.Start(obj)


end

function PreloadBundlesPanel.Update(obj)

end
function PreloadBundlesPanel.LateUpdate(obj)

end

function PreloadBundlesPanel.OnDisable(obj)
    --print("PreloadBundlesPanel OnDisable ......");
end


function PreloadBundlesPanel.OnDestroy(obj)
    --print("PreloadBundlesPanel OnDisable ......");
end

return this;
--endregion
