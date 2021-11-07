/* Index Blog js */

/**
 *  Delete blog by id
 * @param {any} id
 */
function deleteBlog(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/Home/Delete',
                type: 'POST',
                data: JSON.stringify({ Id: id }),
                contentType: "application/json;",
                dataType: "json",
                success: function (result) {
                    // Do something with the result
                    if (result) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Xóa thành công !',
                            showConfirmButton: false,
                            timer: 1500
                        }).then(() => {
                            location.reload(true);
                        })
                    } else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Xóa thất bại !',
                            showConfirmButton: false,
                            timer: 1500
                        }
                        )
                    }
                }
            });
        }
    })
}