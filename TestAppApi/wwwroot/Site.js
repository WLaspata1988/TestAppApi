const uri = "api/Team/GetTeams";
let teams = null;
function getCount(data) {
    const el = $("#counter");
    let name = "Team";
    if (data) {
        if (data > 1) {
            name = "Teams";
        }
        el.text(data + " " + name);
    } else {
        el.text("No " + name);
    }
}

$(document).ready(function () {
    getData();
});

function getData() {
    $.ajax({
        type: "GET",
        url: uri,
        cache: false,
        success: function (data) {
            const tBody = $("#Teams");

            $(tBody).empty();

            getCount(data.length);

            $.each(data, function (key, item) {
                const tr = $("<tr></tr>")
                    .append($("<td></td>").text(item.id))
                    .append($("<td></td>").text(item.name))
                    .append($("<td></td>").text(item.location))
                    .append($("<td></td>").text(item.players))                    
                    .append(
                        $("<td></td>").append(
                            $("<button>Edit</button>").on("click", function () {
                                editItem(item.id);
                            })
                        )
                    )
                    .append(
                        $("<td></td>").append(
                            $("<button>Delete</button>").on("click", function () {
                                deleteItem(item.id);
                            })
                        )
                    );

                tr.appendTo(tBody);
            });

            teams = data;
        }
    });
}

function addItem() {
    const item = {
        name: $("#add-name").val(),
        location: $("#add-location").val()
        
    };

    $.ajax({
        type: "POST",
        accepts: "application/json",
        url: "api/Team",
        contentType: "application/json",
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Something went wrong!");
        },
        success: function (result) {
            getData();
            $("#add-name").val(""),
                $("#add-location").val("");
        }
    });
}

function deleteItem(id) {
    $.ajax({
        url: "api/Team/" + id,
        type: "DELETE",
        success: function (result) {
            getData();
        }
    });
}

function editItem(id) {
    $.each(teams, function (key, item) {
        if (item.id === id) {
            $("#edit-name").val(item.name);
            $("#edit-id").val(item.id);
            $("#edit-location").val(item.location);
            $("#edit-players").val(item.players);
        }
    });
    $("#spoiler").css({ display: "block" });
}

$(".my-form").on("submit", function () {
    const item = {
        name: $("#edit-name").val(),
        location: $("#edit-location").val(),
        players: $("#edit-players").val(),
        id: $("#edit-id").val()
    };

    $.ajax({
        url: "api/Team/" + $("#edit-id").val(),
        type: "PUT",
        accepts: "application/json",
        contentType: "application/json",
        data: JSON.stringify(item),
        success: function (result) {
            getData();
        }
    });

    closeInput();
    return false;
});

function closeInput() {
    $("#spoiler").css({ display: "none" });
}

const uri2 = "api/Players/GetPlayers";
let players = null;
function getCount2(data) {
    const el = $("#counter2");
    let name = "Players";
    if (data) {
        if (data > 1) {
            name = "Players";
        }
        el.text(data + " " + name);
    } else {
        el.text("No " + name);
    }
}

$(document).ready(function () {
    getData2();
});

function getData2() {
    $.ajax({
        type: "GET",
        url: uri2,
        cache: false,
        success: function (data) {
            const tBody2 = $("#Teams2");
            var fileId = $("#fileId");
            fileId.empty().append('<option selected="selected" value="0" disabled = "disabled">Loading.....</option>');

            $(tBody2).empty();

            getCount2(data.length);

            $.each(data, function (key, item) {
                const tr = $("<tr></tr>")
                    .append($("<td></td>").text(item.id))
                    .append($("<td></td>").text(item.firstName))
                    .append($("<td></td>").text(item.lastName))
                    .append($("<td></td>").text(item.number))
                    .append($("<td></td>").text(item.position))
                    .append($("<td></td>").append(fileId.append($("<option></option>").val
                                (item.teams).html(item.teams))))
                    .append(
                        $("<td></td>").append(
                            $("<button>Edit</button>").on("click", function () {
                                editItem2(item.id);
                            })
                        )
                    )
                    .append(
                        $("<td></td>").append(
                            $("<button>Delete</button>").on("click", function () {
                                deleteItem2(item.id);
                            })
                        )
                    );

                tr.appendTo(tBody2);
            });

            players = data;
        }
    });
}

function addItem2() {
    const item2 = {
        firstName: $("#add-firstName").val(),
        lastName: $("#add-lastName").val(),
        number: $("#add-playerNumber").val(),
        position: $("#add-playerPosition").val(),

    };

    $.ajax({
        type: "POST",
        accepts: "application/json",
        url: "api/Players",
        contentType: "application/json",
        data: JSON.stringify(item2),
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Something went wrong!");
        },
        success: function (result) {
            getData2();
            $("#add-firstName").val(""),
                $("#add-lastName").val(""),
                $("#add-playerNumber").val(""),
                $("#add-playerPosition").val("");
        }
    });
}

function deleteItem2(id) {
    $.ajax({
        url: "api/Players/" + id,
        type: "DELETE",
        success: function (result) {
            getData2();
        }
    });
}

function editItem2(id) {
    $.each(players, function (key, item) {
        if (item.id === id) {
            $("#edit-firstName").val(item.firstName);
            $("#edit-lastName").val(item.lastName);
            $("#edit-id2").val(item.id);
            $("#edit-playerNumber").val(item.number);
            $("#edit-playerPosition").val(item.position);
        }
    });
    $("#spoiler2").css({ display: "block" });
}

$(".my-form2").on("submit", function () {
    const item2 = {
        firstName: $("#edit-firstName").val(),
        lastName: $("#edit-lastName").val(),
        position: $("#edit-playerPosition").val(),
        number: $("#edit-playerNumber").val(),
        id: $("#edit-id2").val()
    };

    $.ajax({
        url: "api/Players/" + $("#edit-id2").val(),
        type: "PUT",
        accepts: "application/json",
        contentType: "application/json",
        data: JSON.stringify(item2),
        success: function (result) {
            getData2();
        }
    });

    closeInput2();
    return false;
});

function closeInput2() {
    $("#spoiler2").css({ display: "none" });
}