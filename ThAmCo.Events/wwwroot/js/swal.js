
// Provider from Sweetalert library!
const swAllert = Swal.mixin({
    customClass: {
        confirmButton: "btn btn-danger mx-2",
        cancelButton: "btn btn-light"
    },
    buttonsStyling: false,

});

// Reuseable functions for alerting!
function fireAllert(titleWated, textWanted, iconWanted, confirmTitle, cancelTitle, titleColor = "white") {

    return swAllert.fire({
        title: `<h5 style='color:${titleColor}'>  ${titleWated}  </h5>`,
        text: textWanted,
        icon: iconWanted,
        showCancelButton: true,
        confirmButtonText: confirmTitle,
        cancelButtonText: cancelTitle,
        reverseButtons: true,
        confirmButtonColor: "#d33",
        cancelButtonColor: "#3085d6",
    })
}

function alertInfo(titleWated = "Oops!", textWanted = "Something went wrong.", iconWanted = "error", titleColor = "white") {
    // Handle error
    return Swal.fire({
        title: `<h5 style='color:${titleColor}'>  ${titleWated}  </h5>`,
        text: textWanted,
        icon: iconWanted,
    });
}

function noteInfoTopRight(titleWated = "Oops!", iconWanted = "success") {
    return Swal.fire({
        position: "top-end",
        icon: iconWanted,
        title: titleWated,
        showConfirmButton: false,
        timer: 2000
    })
}

export { fireAllert, alertInfo, noteInfoTopRight }
