--region *.lua
--Date
--此文件由[BabeLua]插件自动生成


ViewMgr = {};
local this = ViewMgr;

function ViewMgr.Init()
    require ("Panels/View/" .. tostring(PanelNames.Main));
    require ("Panels/View/" .. tostring(PanelNames.Login));
    require ("Panels/View/" .. tostring(PanelNames.PreloadBundles));
end

--endregion
