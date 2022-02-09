(function () {
    //window.scrollTo(0, 50); // values are x,y-offset

    document.documentElement.scrollTop = document.getElementById("pageTop").value;
    //debugger;
})()

function SetSession(setName, setValue) {
    var obj = JSON.stringify({
        name: setName,
        value: setValue
    });

    $.ajax({
        type: "POST",
        url: "/Admin/SetSession",
        data: obj,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    });
}

function SuaSach() {
    SetSession("AdminIndex_ScrollTop", String(pageYOffset));
    SetSession("AdminIndex_action", "edit");
}

function XoaSach(MaSach) {
    var result = confirm("Xóa sách vĩnh viễn khỏi danh mục Sách?");
    //debugger;
    //$.ajax({
    //    type: "POST",
    //    url: "/Admin/SetSession",
    //    data: '{name: "' + pageYOffset + '" }',
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json",
    //});

    SetSession("AdminIndex_ScrollTop", String(pageYOffset));

    if (result) {
        window.location.pathname = "/Admin/Delete/" + MaSach;

        //var obj = JSON.stringify({
        //    id: MaSach,
        //    ic: '1234',
        //    ie: '5678'
        //});

        //$.ajax({
        //    type: "post",
        //    url: '/Admin/Delete',
        //    data: obj,
        //    contentType: "application/json; charset=utf-8",
        //    dataType: "json",
        //});
    }
}

function XemThem(hang) {
    //debugger;
    var MoTa = $(hang).closest('td').find('.GetMoTa').val();
    $(hang).closest("td").text(MoTa);
}















