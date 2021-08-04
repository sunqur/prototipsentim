$(document).ready(function () {

    /* DataTables start here. */

   const dataTable = $('#deletedProductsTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Yenile',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/Admin/Product/GetAllDeletedProducts/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#deletedProductsTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const productResult = jQuery.parseJSON(data);
                            dataTable.clear();
                            console.log(productResult);
                            if (productResult.Data.ResultStatus === 0) {
                                let categoriesArray = [];
                                $.each(productResult.Data.Products.$values,
                                    function (index, product) {
                                        const newProduct = getJsonNetObject(product, productResult.Data.Products.$values);
                                        let newCategory = getJsonNetObject(newProduct.Category, newProduct);
                                        if (newCategory !== null) {
                                            categoriesArray.push(newCategory);
                                        }
                                        if (newCategory === null) {
                                            newCategory = categoriesArray.find((category) => {
                                                return category.$id === newProduct.Category.$ref;
                                            });
                                        }
                                        const newTableRow = dataTable.row.add([
                                            newProduct.Id,
                                            newCategory.Name,
                                            newProduct.Title,
                                            `<img src="/img/${newProduct.Thumbnail}" alt="${newProduct.Title}" class="my-image-table" />`,
                                            `${convertToShortDate(newProduct.Date)}`,
                                            newProduct.ViewCount,
                                            newProduct.CommentCount,
                                            `${newProduct.IsActive ? "Evet" : "Hayır"}`,
                                            `${newProduct.IsDeleted ? "Evet" : "Hayır"}`,
                                            `${convertToShortDate(newProduct.CreatedDate)}`,
                                            newProduct.CreatedByName,
                                            `${convertToShortDate(newProduct.ModifiedDate)}`,
                                            newProduct.ModifiedByName,
                                            `
                                <button class="btn btn-primary btn-sm btn-undo" data-id="${newProduct.Id}"><span class="fas fa-undo"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${newProduct.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                                        ]).node();
                                        const jqueryTableRow = $(newTableRow);
                                        jqueryTableRow.attr('name', `${newProduct.Id}`);
                                    });
                                dataTable.draw();
                                $('.spinner-border').hide();
                                $('#deletedProductsTable').fadeIn(1400);
                            } else {
                                toastr.error(`${productResult.Data.Message}`, 'İşlem Başarısız!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#deletedProductsTable').fadeIn(1000);
                            toastr.error(`${err.responseText}`, 'Hata!');
                        }
                    });
                }
            }
        ],
        language: {
            "sDecimal": ",",
            "sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
            "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
            "sInfoEmpty": "Kayıt yok",
            "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Sayfada _MENU_ kayıt göster",
            "sLoadingRecords": "Yükleniyor...",
            "sProcessing": "İşleniyor...",
            "sSearch": "Ara:",
            "sZeroRecords": "Eşleşen kayıt bulunamadı",
            "oPaginate": {
                "sFirst": "İlk",
                "sLast": "Son",
                "sNext": "Sonraki",
                "sPrevious": "Önceki"
            },
            "oAria": {
                "sSortAscending": ": artan sütun sıralamasını aktifleştir",
                "sSortDescending": ": azalan sütun sıralamasını aktifleştir"
            },
            "select": {
                "rows": {
                    "_": "%d kayıt seçildi",
                    "0": "",
                    "1": "1 kayıt seçildi"
                }
            }
        }
    });

    /* DataTables end here */

    /* Ajax POST / HardDeleting a produtc starts from here */

    $(document).on('click',
        '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            const productTitle = tableRow.find('td:eq(2)').text();
            Swal.fire({
                title: 'Kalıcı olarak silmek istediğinize emin misiniz?',
                text: `${productTitle} başlıklı ürün kalıcı olarak silinicektir!`,
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet, kalıcı olarak silmek istiyorum.',
                cancelButtonText: 'Hayır, istemiyorum.'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { productId: id },
                        url: '/Admin/Product/HardDelete/',
                        success: function (data) {
                            const productResult = jQuery.parseJSON(data);
                            if (productResult.ResultStatus === 0) {
                                Swal.fire(
                                    'Silindi!',
                                    `${productResult.Message}`,
                                    'success'
                                );

                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${productResult.Message}`,
                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}`, "Hata!");
                        }
                    });
                }
            });
        });

    /* Ajax POST / HardDeleting a Product ends here */

    /* Ajax POST / UndoDeleting a Product starts from here */

    $(document).on('click',
        '.btn-undo',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            let productTitle = tableRow.find('td:eq(2)').text();
            Swal.fire({
                title: 'Arşivden geri getirmek istediğinize emin misiniz?',
                text: `${productTitle} başlıklı ürün arşivden geri getirilecektir!`,
                icon: 'question',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet, arşivden geri getirmek istiyorum.',
                cancelButtonText: 'Hayır, istemiyorum.'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { productId: id },
                        url: '/Admin/Product/UndoDelete/',
                        success: function (data) {
                            const productUndoDeleteResult = jQuery.parseJSON(data);
                            console.log(productUndoDeleteResult);
                            if (productUndoDeleteResult.ResultStatus === 0) {
                                Swal.fire(
                                    'Arşivden Geri Getirildi!',
                                    `${productUndoDeleteResult.Message}`,
                                    'success'
                                );

                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${productUndoDeleteResult.Message}`,
                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}`, "Hata!");
                        }
                    });
                }
            });
        });
/* Ajax POST / UndoDeleting a Product ends here */

});