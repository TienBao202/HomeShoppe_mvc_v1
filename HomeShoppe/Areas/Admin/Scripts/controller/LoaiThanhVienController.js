var loaithanhvienController = {
    init: function () {
        loaithanhvienController.LoadData();
        loaithanhvienController.registerEvent();
    },
    registerEvent: function () {
        
    },
    LoadData: function () {
        $.ajax({
            url: '/LoaiThanhVien/LoadData',
            type: 'Get',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            ID: item.ID,
                            Name: item.Name,
                        });
                    });
                    $('#tblUserGroup').html(html);
                }
            }
        })
    },
}
loaithanhvienController.init();