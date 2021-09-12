﻿var dataTable; 

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/requestProduct",
            "type": "GET",
            "datatype" : "json"
        },

        "columns": [
          
            { "data": "requestProduct.applicationUser.fullName", "width": "15%" },
            { "data": "requestProduct.applicationUser.email", "width": "15%" },
            { "data": "productName", "width": "15%" },
            { "data": "productModel", "width": "20%" },
            { "data": "imgUrl", "width": "10%" },
           
            {
                "data": "id",
                "render": function (data) {
                    return `  <div class="text-center">
                                    <a class="btn btn-danger text-shite" style="cursor:pointer;width:100px;" onclick=Delete('/api/requestProduct/'+${data})>
                                       <i class="far fa-edit"></i> Delete
                                    </a>
                           </div>`;

                }, "width": "100%"
            }
        ],


        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%",
        //"order": [[2, "asc"]]

    
    });
   
}

function Delete(url) {
    swal({
        title: "Are you sure want to Delete?",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerModel: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}