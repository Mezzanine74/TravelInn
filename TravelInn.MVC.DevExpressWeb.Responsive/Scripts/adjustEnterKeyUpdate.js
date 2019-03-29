'use strict';

var gridObject;
var AdjustEnterKeyUpdate = function (s, e) {
    gridObject = s;
};

// Update with Enter .........................

var prevOnLoad = window.onload;
window.onload = myOnLoad;
function myOnLoad() {
    if (prevOnLoad != null)
        prevOnLoad();
    document.onkeydown = myOnKeyDown;
}

function myOnKeyDown() {
    if (event.keyCode == 27)
        cancelGrid(gridObject);
    if (event.keyCode == 13)
        updateGrid(gridObject);
}

function updateGrid(grid) {
    if (ASPxClientEdit.ValidateEditorsInContainer(grid.GetMainElement())) {
        grid.UpdateEdit();
    }
}

function cancelGrid(grid) {
    grid.CancelEdit();
}
// ......................... Update with Enter