var dataTable; 

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/reviews",
            "type": "GET",
            "datatype" : "json"
        },

        "columns": [

           
            { "data": "reviews.addDate", "width": "15%" },
            { "data": "productImage", "width": "25%" },
            { "data": "description", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `  <div class="text-center">
                               <a href="/Admin/reviews/Upsert?id=${data}"  class="btn btn-success text-white" style="cussor:pointer;width:100px;">
                                       <i class="far fa-edit"></i> Edit
                                    </a>
                          
                                    <a class="btn btn-danger text-shite" style="cursor:pointer;width:100px;" onclick=Delete('/api/reviews/'+${data})>
                                       <i class="far fa-edit"></i> Delete
                                    </a>
                           </div>`;

                }, "width": "30%"
            }
        ],


        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%",
        "order": [[2, "asc"]]

    
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