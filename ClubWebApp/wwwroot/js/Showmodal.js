showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');

        }

    })
}

jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view-all').html(res.html);
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                    location.reload();
                }
                else {

                    $('#form-modal modal-body').html(res.html);
                }
            },
            error: function (err) {

                console.log(err);
            }
        })
        return false;

    } catch (ex) {

        console.log(ex);
    }

}

(function (modalDeleteDialog) {

    var methods = {
        "openModal": openModal,
        "deleteItem": deleteItem

    };

    var item_to_delete;

    function openModal(modalName, classOrId, sourceEvent, deletePath, eventClassOrId) {
        var textEvent;
        if (classOrId) {
            textEvent = "." + modalName;

        } else {
            textEvent = "#" + modalName;
        }

        $(textEvent).click((e) => {
            item_to_delete = e.currentTarget.dataset.id;
            deleteItem(sourceEvent, deletePath, eventClassOrId);

        });

    }

    function deleteItem(sourceEvent, deletePath, eventClassOrId) {
        var textEvent;
        if (eventClassOrId) {
            textEvent = "." + sourceEvent;

        } else {
            textEvent = "#" + sourceEvent;
        }
        $(textEvent).click(function () {
            window.location.href = deletePath + item_to_delete;

        });

    }

    modalDeleteDialog.sc_deleteDialog = methods;

})(window);