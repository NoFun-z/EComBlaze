﻿window.ShowToastr = (type, message) => {
    if (type == "success") {
        toastr.success(message, 'Operation Successfull', { timeOut: 5000 })
    }
    if (type == "error") {
        toastr.success(message, 'Operation Failed', { timeOut: 5000 })
    }
}

window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire(
            'Success Notification!',
            message,
            'success'
        )
    }
    if (type === "error") {
        Swal.fire(
            'Failed Notification!',
            message,
            'error'
        )
    }
}