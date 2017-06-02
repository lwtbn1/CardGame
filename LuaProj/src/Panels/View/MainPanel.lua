--region *.lua
--Date
--此文件由[BabeLua]插件自动生成
MainPanel = {};
local this = MainPanel;
this.ui = {};
this.gameObject = nil;
this.transform = nil;


function MainPanel.Awake(obj)
    this.gameObject = obj;
    this.transform = obj.transform;

    this.ui.NoticeGrid = this.transform:FindChild("Notice/NoticeGrid");
    this.ui.NoticeGridLayoutGroup = this.ui.NoticeGrid:GetComponent("GridLayoutGroup")
    this.ui.NoticeItemTemp = this.transform:FindChild("Notice/NoticeItemTemp").gameObject;
    this.ui.NoticeDrag = this.transform:FindChild("Notice/NoticeDrag").gameObject;
    this.eventTriggerListener = EventTriggerListener.Get(this.ui.NoticeDrag);
    this.ui.CreateRoomButton = this.transform:FindChild("CreateRoomButton"):GetComponent("Button");
    this.ui.JoinRoomButton = this.transform:FindChild("JoinRoomButton"):GetComponent("Button");
    this.ui.infoText = this.transform:FindChild("Infos/Notice/Text"):GetComponent("Text");
    this.ui.InfosRect = this.transform:FindChild("Infos"):GetComponent("RectTransform");
    
    print("MainPanel.Awake.................");
    print(this.eventTriggerListener);
end


function MainPanel.OnEnable(obj)


end
function MainPanel.Start(obj)


end
function MainPanel.OnDisable(obj)
    --print("mainPanel OnDisable ......");
end


function MainPanel.OnDestroy(obj)
    --print("mainPanel OnDisable ......");
end

function MainPanel.Update(obj)

end
function MainPanel.LateUpdate(obj)

end
return this;
--endregion
