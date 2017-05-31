--region *.lua
--Date
--此文件由[BabeLua]插件自动生成
MainCtrl = {};
local this = MainCtrl;
this.panelName = "MainPanel";
this.luaBehaviour = nil;
this.panel = require "View/MainPanel";
local noticeItemX = 0;
local noticeCount = 0;
local dragMinX = 0;
local dragIx = 0;
local dragDeta = 0;

local infosRectLen = 0;   --跑马灯显式宽度
local infoTextMinX = 0;
local infoTextStartX = 0;
function MainCtrl.New()
    return this;
end

function MainCtrl.PushPanel()
    uiMgr:PushPanel("MainPanel",this.panelName, this);
    
end

function MainCtrl.HidePanel()
    --print("MainCtrl.HidePanel ................." .. this.panelName);
    uiMgr:HidePanel(panelName);
end
--启动事件--
function MainCtrl.OnCreate(obj)
    --print(obj.name)
    this.luaBehaviour = obj:GetComponent(typeof(LuaBehaviour))
    this.panel.eventTriggerListener:RegOnDrag(MainCtrl.OnDragNotice);
    this.panel.eventTriggerListener:RegOnEndDrag(MainCtrl.OnEndDragNotice);
    MainCtrl.Enable();
end

function MainCtrl.OnDragNotice(eventData)
    --print(eventData.delta.x);
    dragDeta = dragDeta + eventData.delta.x;
end
function MainCtrl.OnEndDragNotice(eventData)
    print("OnEndDragNotice ...");
    if Mathf.Abs(dragDeta) > 20 then
        if dragDeta < 0 then
            dragIx = dragIx -1;
        else
            dragIx = dragIx + 1;
        end
        dragIx = Mathf.Clamp(dragIx, -(noticeCount - 1),0);
        local endValue = dragIx * noticeItemX;
        local duration = 0.2;
        local dotweenDelegate = DOTweenDelegate.GetDelegate();
        dotweenDelegate:DOLocalMoveX(this.panel.ui.NoticeGrid,endValue,duration,nil,nil);
    end
    dragDeta = 0;
end

function MainCtrl.Enable()
    MainCtrl.InitNotice();
    MainCtrl.InitInfos();
end
function MainCtrl.InitNotice()
    --生成一个个公告
    noticeItemX = this.panel.ui.NoticeGridLayoutGroup.cellSize.x
    noticeCount = this.panel.ui.NoticeGrid.childCount;
    dragMinX = -noticeItemX * (noticeCount - 1);
    print(noticeItemX .. "  " .. noticeCount .. "  " .. dragMinX);
end

function MainCtrl.InitInfos()
    --填充Text
    local info = "玩家xxx刚刚充值100元宝，恭喜该玩家；    玩家xxx在神秘副本中获得一个至尊武器... ;    活动中心新开了活动，请各位勇士前往。。 "
    this.panel.ui.infoText.text = info;
    infosRectLen = this.panel.ui.InfosRect.sizeDelta.x;
    local textLen = UIUtil.TextLen(info,this.panel.ui.infoText);
    infoTextStartX = infosRectLen + 10;
    infoTextMinX = -textLen-20;
    infosMoveCoroutine = coroutine.start(MainCtrl.InfosMove);
end
local infosMoveCoroutine;
function MainCtrl.InfosMove()
    local startX = infoTextStartX;
    this.panel.ui.infoText.transform.localPosition = Vector3.New(startX,0,0);
    local moveDelta = 0;
    while startX > infoTextMinX do
        moveDelta = 40 * Time.deltaTime;
        startX = startX - moveDelta;
        this.panel.ui.infoText.transform.localPosition = Vector3.New(startX,0,0);
        coroutine.step();
    end
end
function MainCtrl.Update()
    --print("MainCtrl.Update  ......");
end

function MainCtrl.OnDisable()
    --print("MainCtrl.OnDisable...");
end
--endregion
