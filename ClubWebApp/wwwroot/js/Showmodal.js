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

    //        < !--Código de JQuery para validar el formulario de contacto-- >
    //@section Script {
    //<script type="text/javascript">
        var iNumber = Math.floor(1000+ Math.random() * 9000);

        $(document).ready(function (){
            $("#btnSubmit").prop("disabled", true);
        $("#divGenerateRandomValues").html(("<input id='txtNewInput' value='" + iNumber + "' disabled />");

        //Validar la cahe
        $("#btnSubmit").click(function (e){
            e.preventDefault();
        if($("#textInput").val() != iNumber){
            $('errCap').text('Invalid Captcha!');

                  } else{
            $('.errCap').text('');
        submitForm();

                  }
              });

        var wrongInput = function(){

                  return $("#textInput").val() != iNumber;
              };

        $("#textInput").bind('input', function(){

            $("#btnSubmit").prop('disabeld', wrongInput);
              
              });

        });


        function submitForm(){

            $('#booking_form').validate({
                rules: {
                    name: { required: true, minlength: 10 },




                }



            })



        }
//    </script>

//}