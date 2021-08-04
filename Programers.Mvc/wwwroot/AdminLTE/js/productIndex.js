$(document).ready(function () {

    /* DataTables start here. */

    const dataTable = $('#productsTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Ekle',
                attr: {
                    id: "btnAdd",
                },
                className: 'btn btn-success',
                action: function (e, dt, node, config) {
                }
            },
            {
                text: 'Yenile',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/Admin/Product/GetAllProducts/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#productsTable').hide();
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
                                        console.log(newProduct);
                                        console.log(newCategory);
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
                                <a class="btn btn-primary btn-sm btn-update" href="/Admin/Product/Update?productId=${newProduct.Id}"><span class="fas fa-edit"></span></a>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${newProduct.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                                        ]).node();
                                        const jqueryTableRow = $(newTableRow);
                                        jqueryTableRow.attr('name', `${newProduct.Id}`);
                                    });
                                dataTable.draw();
                                $('.spinner-border').hide();
                                $('#productsTable').fadeIn(1400);
                            } else {
                                toastr.error(`${productResult.Data.Message}`, 'İşlem Başarısız!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#productsTable').fadeIn(1000);
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

    /* Ajax POST / Deleting a User starts from here */

    $(document).on('click',
        '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            const productTitle = tableRow.find('td:eq(2)').text();
            Swal.fire({
                title: 'Silmek istediğinize emin misiniz?',
                text: `${productTitle} başlıklı ürün silinicektir!`,
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet, silmek istiyorum.',
                cancelButtonText: 'Hayır, silmek istemiyorum.'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { productId: id },
                        url: '/Admin/Product/Delete/',
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

});