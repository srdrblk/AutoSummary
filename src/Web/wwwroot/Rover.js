
function setInfos() {


    var request = {};

    request.InputInfos = document.getElementById("inputInfos").value;

    $.ajax({
        url: '/Home/SetInfos',
        async: true,
        data: request,
        type: "POST",

        success: function (result) {
            $('#outputInfos').empty();
            var listElement = document.getElementById("outputInfos");
            var numberOfListItems = result.endPoints.length;
            for (var i = 0; i < numberOfListItems; ++i) {

                listItem = document.createElement("li");
                listItem.innerHTML = result.endPoints[i];
                listElement.appendChild(listItem);
            }
        },
        error: function (error) {
              alert('error; ' + eval(error));
        }
    });

}