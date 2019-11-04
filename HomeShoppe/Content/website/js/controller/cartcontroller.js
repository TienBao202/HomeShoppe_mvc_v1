var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btn_tieptucmuahang').off('click').on('click', function () {
            window.location.href = "/";
        });

        $('#btn_xemgiohang').off('click').on('click', function () {
            window.location.href = "/gio-hang";
        });

        $('#btn_ThanhToan').off('click').on('click', function () {
            window.location.href = "/thanh-toan";
        });

        $('.btn_Update').off('click').on('click', function () {
            var listproduct = $('.txt_quantity');
            var listcart = [];
            $.each(listproduct, function (i, item) {
                listcart.push({
                    Quantity: $(item).val(),
                    Product: {
                        ID: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/Cart/UpdateItem',
                data: { CartModel: JSON.stringify(listcart) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status) {
                        window.location.href = "/gio-hang";
                    }

                }
            })
        });

        $('#btn_DeleteAll').off('click').on('click', function () {
           
            $.ajax({
                url: '/Cart/DeleteAll',              
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status) {
                        window.location.href = "/gio-hang";
                    }

                }
            })
        });

        $('.btn_Delete').off('click').on('click', function () {

            $.ajax({
                url: '/Cart/Delete',
                data: { id: $(this).data('id') },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status) {
                        window.location.href = "/gio-hang";
                    }

                }
            })
        });

    }
}
cart.init();
