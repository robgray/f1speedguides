function actionSwapMasterDocType() {
    UmbClientMgr.openModalWindow('theoutfield/doctypeextensions/dialogs/SwapMasterDocType.aspx?id=' + UmbClientMgr.mainTree().getActionNode().nodeId, 'Swap Master Doc Type', true, 500, 480);
}

function actionExtractMasterDocType() {
    UmbClientMgr.openModalWindow('theoutfield/doctypeextensions/dialogs/ExtractMasterDocType.aspx?id=' + UmbClientMgr.mainTree().getActionNode().nodeId, 'Extract Master Doc Type', true, 500, 480);
}