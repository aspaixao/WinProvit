function getCandidates() {
    var request;
    var $candidates = $('#candidates');

    request = $.ajax({
        url: 'https://localhost:44379/candidate',
        type: "GET",
        success: function (candidates) {
            $.each(candidates, function (i, candidate) {
                $candidates.append(fCandidate(candidate));
            });
        }
    });
}

function fCandidate(c) {
    var div = '<div class="card me-auto" style = "width: 15rem; height: 10rem">';
    div += '<div class="card-body">';
    div += '<h5 class="card-title">'+c.email+'</h5>';
    div += '<h6 class="card-subtitle mb-2 text-muted">'+c.name+'</h6>';
    div += '<p class="card-text">'+c.phone+'</p>';
    div += '<p class="card-text">'+c.address+'</p>';
    div += '</div>';
    div += '</div >';

    return div;
}